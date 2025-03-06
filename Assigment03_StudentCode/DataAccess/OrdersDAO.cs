using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrdersDAO
    {
        public static List<Order> GetOrders()
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrders = context.Orders.ToList();
                    listOrders.ForEach(o =>
                    o.Member = context.Members.Find(o.MemberID));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrders;
        }

        public static List<Order> FindAllOrdersByMemberId(string memberId)
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrders = context.Orders.Where(o =>
                    o.MemberID == memberId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrders;
        }

        public static Order FindOrderById(int orderId)
        {
            var order = new Order();
            try
            {
                using (var context = new MyDbContext())
                {
                    order = context.Orders.SingleOrDefault(o => o.OrderID == orderId);
                    if (order != null)
                        order.Member = context.Members.Find(order.MemberID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public static Order SaveOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public static void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry(order).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var orderToDelete = context
                        .Orders
                        .SingleOrDefault(o => o.OrderID == order.OrderID);
                    context.Orders.Remove(orderToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            var listOrders = new List<Order>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listOrders = context.Orders
                        .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                        .ToList();
                    listOrders.ForEach(o => o.Member = context.Members.Find(o.MemberID));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listOrders;
        }

    }
}
