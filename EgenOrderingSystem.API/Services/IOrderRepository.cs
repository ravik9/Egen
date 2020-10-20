using EgenOrderingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Services
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();        

        Order GetOrder(int orderId);
        void UpdateOrder(int orderId);
        bool OrderExists(int orderId);
        IEnumerable<OrderItems> GetOrderItems(int orderId);
        OrderItems GetOrderItem(int orderId, int ItemId);

    }
}
