using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        
        //GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetAllProducts();

        //POST: ProductsController/Products
        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            repository.SaveProduct(p);
            return NoContent();
        }

        //GET: api/products/id
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductByID(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            return p;
        }

        //GET: ProductsController/Delete/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if(p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return NoContent();
        }

        //GET: ProductsController/Edit/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var pTmp = repository.GetProductById(id);
            if(pTmp == null)
            {
                return NotFound();
            }
            p.ProductId = pTmp.ProductId;
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}
