using DataAccess.Repository.ImplRepo;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Model;

namespace eStoreAPI.Controllers
{
    [Route("api/orderdetails")]
    [ApiController]
    public class OrderDetailAPI : ControllerBase
    {
        private IOrderDetailRepository repository = new OrderDetailRepository();

        [HttpGet]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetails() => repository.GetOrderDetails();

        [HttpGet("order/{id}")]
        public ActionResult<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int id) => repository.GetOrderDetailsByOrderId(id);

        [HttpGet("{orderId}/{productId}")]
        public ActionResult<OrderDetail> GetOrderDetailByOrderIdAndProductId(int orderId, int productId) => repository.GetOrderDetailByOrderIdAndProductId(orderId, productId);

        [HttpPost]
        public IActionResult PostOrderDetail(OrderDetail OrderDetailRequest)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = OrderDetailRequest.OrderId,
                ProductId = OrderDetailRequest.ProductId,
                UnitPrice = OrderDetailRequest.UnitPrice,
                Quantity = OrderDetailRequest.Quantity,
                Discount = OrderDetailRequest.Discount
            };
            repository.SaveOrderDetail(orderDetail);
            return NoContent();
        }

        [HttpDelete("{orderId}/{productId}")]
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

        [HttpPut("{orderId}/{productId}")]
        public IActionResult PutOrderDetailByOrderIdAndProductId(int orderId, int productId, OrderDetail orderDetail)
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
