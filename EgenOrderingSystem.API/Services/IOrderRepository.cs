using EgenOrderingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Services
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();        

        Task<Order> GetOrderAsync(int orderId);
        void UpdateOrder(int orderId);
        bool OrderExists(int orderId);
        Task<IEnumerable<OrderItems>> GetOrderItemsAsync(int orderId);
        Task<OrderItems> GetOrderItemAsync(int orderId, int ItemId);
        void AddOrder(Order order);
        Task<bool> SaveAsync();
    }
}
