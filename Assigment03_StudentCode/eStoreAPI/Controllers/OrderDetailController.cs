using BusinessObject;
using eStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.ImplRepo;
using Repository;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository repository = new OrderDetailRepository();

        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails() => repository.GetOrderDetails();
        [HttpGet("order/{id}")]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int id) => repository.GetOrderDetailsByOrderId(id);

        [HttpGet("{orderId}/{id}")]
        public ActionResult<OrderDetail> GetOrderDetailByOrderIdAndProductId(int orderId, int productId) => repository.GetOrderDetailByOrderIdAndProductId(orderId, productId);

        [HttpPost]
        public IActionResult PostOrderDetail(PostOrderDetail OrderDetailRequest)
        {
            var orderDetail = new OrderDetail
            {
                ProductID = OrderDetailRequest.ProductID,
                UnitPrice = OrderDetailRequest.UnitPrice,
                Quantity = OrderDetailRequest.Quantity,
            };
            repository.SaveOrderDetail(orderDetail);
            return NoContent();
        }

        [HttpDelete("{orderId}/{id}")]
        public IActionResult DeleteOrderDetailByOrderIdAndProductId(int orderId, int productId)
        {
            var o = repository.GetOrderDetailByOrderIdAndProductId(orderId, productId);
            if (o == null)
            {
                return NotFound();
            }
            repository.DeleteOrderDetail(o);
            return NoContent();
        }

        [HttpPut("{orderId}/{id}")]
        public IActionResult PutOrderDetailByOrderIdAndFlowerBouquetId(int orderId, int productId, OrderDetail orderDetail)
        {
            var oTmp = repository.GetOrderDetailByOrderIdAndProductId(orderId, productId);
            if (oTmp == null)
            {
                return NotFound();
            }

            oTmp.UnitPrice = orderDetail.UnitPrice;
            oTmp.Quantity = orderDetail.Quantity;
            oTmp.Discount = orderDetail.Discount;

            repository.UpdateOrderDetail(oTmp);
            return NoContent();
        }
    }
}
