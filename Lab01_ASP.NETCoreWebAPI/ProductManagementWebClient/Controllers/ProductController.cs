using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ProductManagementWebClient.Controllers
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
            ProductApiUrl = "https://localhost:7243/api/products";
            CategoryApiUrl = "https://localhost:7243/api/categories";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            List<Product> listProducts = await response.Content.ReadFromJsonAsync<List<Product>>();
            return View(listProducts);
        }

        //GET: ProductController/Details/5
        public async Task<IActionResult> DetailsAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{id}");
            Product product = await response.Content.ReadFromJsonAsync<Product>();

            HttpResponseMessage cateResponse = await client.GetAsync(CategoryApiUrl);
            List<Category> listCategories = await cateResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = listCategories;

            return View(product);
        }

        //GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            HttpResponseMessage cateResponse = await client.GetAsync(CategoryApiUrl);
            List<Category> listCategories = await cateResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = listCategories;
            return View();

        }

        //POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(ProductApiUrl, p);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        //GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{id}");
            Product product = await response.Content.ReadFromJsonAsync<Product>();

            HttpResponseMessage cateResponse = await client.GetAsync(CategoryApiUrl);
            List<Category> categories = await cateResponse.Content.ReadFromJsonAsync<List<Category>>();
            ViewData["Categories"] = categories;
            return View(product);
        }

        //PUT: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product p)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"{ProductApiUrl}/{id}", p);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        //GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{id}");
            Product product = await response.Content.ReadFromJsonAsync<Product>();
            return View(product);
        }

        //POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{ProductApiUrl}/{id}");
            return RedirectToAction("Index");
        }
    }
}
