using EgenOrderingSystem.API.DBContext;
using EgenOrderingSystem.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderSystemContext _orderSystemContext;
        public OrderRepository(OrderSystemContext orderSystemContext)
        {
            _orderSystemContext = orderSystemContext;
        }


        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _orderSystemContext.Orders.Where(x => x.Id == orderId).SingleOrDefaultAsync();
        }

        public bool OrderExists(int orderId)
        {
            var res = _orderSystemContext.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            return res != null;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _orderSystemContext.Orders.ToListAsync();
        }
        public async Task<IEnumerable<OrderItems>> GetOrderItemsAsync(int orderId)
        {
            return await _orderSystemContext.OrderItems.Where(x => x.OrderId == orderId).ToListAsync();
        }
        public async Task<OrderItems> GetOrderItemAsync(int orderId, int itemId)
        {
            return await _orderSystemContext.OrderItems.Where(x => x.OrderId == orderId && x.Id == itemId).SingleOrDefaultAsync();

        }
        public void UpdateOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orderSystemContext.Orders.Add(order);

        }
        public async Task<bool> SaveAsync()
        {
           return await _orderSystemContext.SaveChangesAsync() > 0;
        }
    }
}
