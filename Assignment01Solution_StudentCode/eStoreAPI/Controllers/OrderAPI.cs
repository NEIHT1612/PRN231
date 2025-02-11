using DataAccess.Repository.ImplRepo;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Model;

namespace eStoreAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderAPI : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders() => repository.GetOrders();

        [HttpGet("member/{id}")]
        public ActionResult<IEnumerable<Order>> GetAllOrdersByMemberId(int id) => repository.GetAllOrdersByMemberId(id);

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id) => repository.GetOrderById(id);

        [HttpPost]
        public ActionResult<Order> PostOrder(Order orderReq)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                ShippedDate = DateTime.Now.AddDays(7),
                RequiredDate = DateTime.Now.AddDays(2),
                Freight = orderReq.Freight,
                MemberId = orderReq.MemberId,
            };
            return repository.SaveOrder(order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var o = repository.GetOrderById(id);
            if (o == null)
            {
                return NotFound();
            }
            repository.DeleteOrder(o);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            var oTmp = repository.GetOrderById(id);
            if (oTmp == null)
            {
                return NotFound();
            }
            oTmp.MemberId = order.MemberId;
            oTmp.Freight = order.Freight;

            repository.UpdateOrder(oTmp);
            return NoContent();
        }
    }
}
