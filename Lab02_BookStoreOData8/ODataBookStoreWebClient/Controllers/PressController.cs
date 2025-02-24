using Microsoft.AspNetCore.Mvc;
using ODataBookStore.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ODataBookStoreWebClient.Controllers
{
    public class PressController : Controller
    {
        private readonly HttpClient client = null;
        public string PressApiUrl = "";

        public PressController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PressApiUrl = "https://localhost:7033/odata/Presses";
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(PressApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            using (JsonDocument jsonDocument = JsonDocument.Parse(strData))
            {
                var jsonElement = jsonDocument.RootElement.GetProperty("value");
                var items = JsonSerializer.Deserialize<List<Press>>(jsonElement.GetRawText());
            }

            return View();
        }
    }
}
