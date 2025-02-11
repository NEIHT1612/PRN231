using BusinessObject.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace eStoreClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        private string CategoryApiUrl = "";
        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7200/api/products";
            CategoryApiUrl = "https://localhost:7200/api/categories";

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage productResponse = await client.GetAsync(ProductApiUrl);
            List<Product> listProducts = await productResponse.Content.ReadFromJsonAsync<List<Product>>();

            HttpResponseMessage categoryResponse = await client.GetAsync(CategoryApiUrl);
            List<Category> listCategories = await categoryResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = listCategories;

            return View(listProducts);
        }

        public async Task<IActionResult> Search(string keyword)
        {
            List<Product> listProducts = new List<Product>();
            List<Category> listCategories = new List<Category>();

            string searchUrl = string.IsNullOrWhiteSpace(keyword) ? ProductApiUrl : $"{ProductApiUrl}/Search/{keyword}";
            HttpResponseMessage productResponse = await client.GetAsync(searchUrl);
            listProducts = await productResponse.Content.ReadFromJsonAsync<List<Product>>();

            HttpResponseMessage categoryResponse = await client.GetAsync(CategoryApiUrl);
            listCategories = await categoryResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = listCategories;

            ViewData["keyword"] = keyword;

            return View("Index", listProducts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            HttpResponseMessage categoryResponse = await client.GetAsync(CategoryApiUrl);
            List<Category> listCategories = await categoryResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = listCategories;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            HttpResponseMessage productResponse = await client.PostAsJsonAsync(ProductApiUrl, p);
            productResponse.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage productResponse = await client.GetAsync($"{ProductApiUrl}/{id}");
            Product product = await productResponse.Content.ReadFromJsonAsync<Product>();

            HttpResponseMessage categoryResponse = await client.GetAsync(CategoryApiUrl);
            List<Category> listCategories = await categoryResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = listCategories;

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product p)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"{ProductApiUrl}/{id}", p);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage productResponse = await client.GetAsync($"{ProductApiUrl}/{id}");
            Product product = await productResponse.Content.ReadFromJsonAsync<Product>();

            HttpResponseMessage categoryResponse = await client.GetAsync(CategoryApiUrl);
            List<Category> listCategories = await categoryResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = listCategories;

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{ProductApiUrl}/{id}");
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
