using DataAccess.Repository.ImplRepo;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Model;

namespace eStoreAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductAPI : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();

        [HttpGet("Search/{keyword}")]
        public ActionResult<IEnumerable<Product>> Search(string keyword) => repository.Search(keyword);

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id) => repository.GetProductById(id);

        [HttpPost]
        public IActionResult PostProduct(Product productReq)
        {
            var product = new Product
            {
                ProductName = productReq.ProductName,
                CategoryId = productReq.CategoryId,
                UnitPrice = productReq.UnitPrice,
                UnitsInStock = productReq.UnitsInStock,
                Weight = productReq.Weight
            };
            repository.SaveProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }

            repository.DeleteProduct(p);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product productReq)
        {
            var pTmp = repository.GetProductById(id);
            if (pTmp == null)
            {
                return NotFound();
            }

            pTmp.ProductName = productReq.ProductName;
            pTmp.UnitPrice = productReq.UnitPrice;
            pTmp.UnitsInStock = productReq.UnitsInStock;
            pTmp.CategoryId = productReq.CategoryId;
            pTmp.Weight = productReq.Weight;

            repository.UpdateProduct(pTmp);
            return NoContent();
        }
    }
}
