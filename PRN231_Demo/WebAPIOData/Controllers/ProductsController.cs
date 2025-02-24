using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebAPIOData.Models;

namespace WebAPIOData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProductsController(MyDbContext context)
        {
            _context = context;
        }
        [EnableQuery]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.AsQueryable());
        }
    }
}
