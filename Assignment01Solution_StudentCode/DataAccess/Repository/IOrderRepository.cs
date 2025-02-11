﻿using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        Order SaveOrder(Order order);
        Order GetOrderById(int id);
        List<Order> GetOrders();
        List<Order> GetAllOrdersByMemberId(int customerId);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        List<OrderDetail> GetOrderDetails(int orderId);
    }
}
