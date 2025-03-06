using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImplRepo
{
    public class OrderRepository : IOrderRepository
    {
        public Order SaveOrder(Order order) => OrdersDAO.SaveOrder(order);
        public Order GetOrderById(int id) => OrdersDAO.FindOrderById(id);
        public List<Order> GetOrders() => OrdersDAO.GetOrders();
        public List<Order> GetAllOrdersByMemberId(string id) => OrdersDAO.FindAllOrdersByMemberId(id);
        public void UpdateOrder(Order order) => OrdersDAO.UpdateOrder(order);
        public void DeleteOrder(Order order) => OrdersDAO.DeleteOrder(order);
        public List<OrderDetail> GetOrderDetails(int orderId) => OrdersDetailDAO.FindAllOrderDetailsByOrderId(orderId);
        public List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate) =>
       OrdersDAO.GetOrdersByDateRange(startDate, endDate);
    }
}
