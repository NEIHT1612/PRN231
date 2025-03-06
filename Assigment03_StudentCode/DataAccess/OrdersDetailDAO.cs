using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrdersDetailDAO
    {

        public static List<OrderDetail> GetOrderDetails()
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrderDetails = context.OrderDetails.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrderDetails;
        }

        public static List<OrderDetail> FindAllOrderDetailsByProductID(int productID)
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrderDetails = context
                        .OrderDetails
                        .Where(o => o.ProductID == productID)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrderDetails;
        }


        public static List<OrderDetail> FindAllOrderDetailsByOrderId(int orderId)
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrderDetails = context
                        .OrderDetails
                        .Where(o => o.OrderID == orderId)
                        .ToList();
                    listOrderDetails.ForEach(o =>
                        o.Product = context.Products.SingleOrDefault(f => f.ProductID == o.ProductID)
                    );
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listOrderDetails;
        }

        public static OrderDetail FindOrderDetailByOrderIdAndProductID(int orderId, int ProductID)
        {
            var orderDetail = new OrderDetail();
            try
            {
                using (var context = new MyDbContext())
                {
                    orderDetail = context
                        .OrderDetails
                        .SingleOrDefault(o => o.OrderID == orderId && o.ProductID == ProductID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public static void SaveOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(orderDetail).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var orderDetailToDelete = context
                        .OrderDetails
                        .SingleOrDefault(o => o.OrderID == orderDetail.OrderID && o.ProductID == orderDetail.ProductID);
                    context.OrderDetails.Remove(orderDetailToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
