using Microsoft.AspNetCore.Mvc;
using ODataBookStore.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ODataBookStoreWebClient.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient client = null;
        private string BookApiUrl = "";

        public BookController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookApiUrl = "https://localhost:7033/odata/Books";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(BookApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            using (JsonDocument jsonDocument = JsonDocument.Parse(strData))
            {
                var jsonElement = jsonDocument.RootElement.GetProperty("value");
                var items = JsonSerializer.Deserialize<List<Book>>(jsonElement.GetRawText());

                return View(items);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{BookApiUrl}({id})");
            var bookJson = await response.Content.ReadAsStringAsync();

            using (JsonDocument jsonDocument = JsonDocument.Parse(bookJson))
            {
                var jsonElement = jsonDocument.RootElement;
                var book = JsonSerializer.Deserialize<Book>(jsonElement.GetRawText());
                return View(book);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            var jsonBook = JsonSerializer.Serialize(book);
            var content = new StringContent(jsonBook, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(BookApiUrl, content);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{BookApiUrl}({id})");
            var bookJson = await response.Content.ReadAsStringAsync();

            using (JsonDocument jsonDocument = JsonDocument.Parse(bookJson))
            {
                var jsonElement = jsonDocument.RootElement;
                var book = JsonSerializer.Deserialize<Book>(jsonElement.GetRawText());
                return View(book);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            var jsonBook = JsonSerializer.Serialize(book);
            var content = new StringContent(jsonBook, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"{BookApiUrl}({id})", content);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{BookApiUrl}({id})");
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
