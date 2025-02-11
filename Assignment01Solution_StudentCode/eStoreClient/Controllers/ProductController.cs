using Microsoft.AspNetCore.Mvc;

namespace eStoreClient.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
