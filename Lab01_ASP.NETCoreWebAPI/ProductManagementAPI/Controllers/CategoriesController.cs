using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository repository = new CategoryRepository();

        //GET: api/categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories() => repository.GetAllCategories();

    }
}
