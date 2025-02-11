using Microsoft.AspNetCore.Mvc;

namespace eStoreClient.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
