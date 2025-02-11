using BusinessObject.DataAccess;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.ImplRepo
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.DeleteOrderDetail(orderDetail);

        public OrderDetail GetOrderDetailByOrderIdAndProductId(int orderId, int productId) => OrderDetailDAO.FindOrderDetailByOrderIdAndProductID(orderId, productId);

        public List<OrderDetail> GetOrderDetails() => OrderDetailDAO.GetOrderDetails();

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId) => OrderDetailDAO.FindAllOrderDetailsByOrderId(orderId);

        public void SaveOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.SaveOrderDetail(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.UpdateOrderDetail(orderDetail);
    }
}
