using EgenOrderingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Services
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItems>> GetOrderItemsAsync(int orderID);

        Task<OrderItems> GetOrderItemAsync(int orderItemId);
        void UpdateOrderItem(OrderItems orderItem);
        void AddOrderItem(int orderId, OrderItems orderItem);
        Task<bool> SaveAsync();
        void CreateOrderItem(OrderItems entity);
        Task<OrderItems> GetItemAsync(int orderId, int itemId);
        void DeleteItem(OrderItems orderItem);

    }
}
