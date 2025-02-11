using BusinessObject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var listOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new SalesManagementContext())
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
                using (var context = new SalesManagementContext())
                {
                    listOrderDetails = context
                        .OrderDetails
                        .Where(o => o.ProductId == productID)
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
                using (var context = new SalesManagementContext())
                {
                    listOrderDetails = context
                        .OrderDetails
                        .Where(o => o.OrderId == orderId)
                        .ToList();
                    listOrderDetails.ForEach(o =>
                        o.Product = context.Products.SingleOrDefault(f => f.ProductId == o.ProductId)
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
                using (var context = new SalesManagementContext())
                {
                    orderDetail = context
                        .OrderDetails
                        .SingleOrDefault(o => o.OrderId == orderId && o.ProductId == ProductID);
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
                using (var context = new SalesManagementContext())
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
                using (var context = new SalesManagementContext())
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
                using (var context = new SalesManagementContext())
                {
                    var orderDetailToDelete = context
                        .OrderDetails
                        .SingleOrDefault(o => o.OrderId == orderDetail.OrderId && o.ProductId == orderDetail.ProductId);
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
