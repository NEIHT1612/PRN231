using BusinessObject.DataAccess;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ImplRepo
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order order) => OrderDAO.DeleteOrder(order);

        public List<Order> GetAllOrdersByMemberId(int customerId) => OrderDAO.FindAllOrdersByMemberId(customerId);

        public Order GetOrderById(int id) => OrderDAO.FindOrderById(id);

        public List<OrderDetail> GetOrderDetails(int orderId) => OrderDetailDAO.FindAllOrderDetailsByOrderId(orderId);

        public List<Order> GetOrders() => OrderDAO.GetOrders();

        public Order SaveOrder(Order order) => OrderDAO.SaveOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.UpdateOrder(order);
    }
}
