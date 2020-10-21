using EgenOrderingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Services
{
    public interface IOrderItemsRepository
    {
        IEnumerable<OrderItems> GetOrderItems(int orderID);

        OrderItems GetOrderItem(int orderItemId);
        void UpdateOrderItem(OrderItems orderItem);
        void AddOrderItem(int orderId, OrderItems orderItem);
        void Save();
        void CreateOrderItem(OrderItems entity);
        OrderItems GetItem(int orderId, int itemId);
        void DeleteItem(OrderItems orderItem);

    }
}
