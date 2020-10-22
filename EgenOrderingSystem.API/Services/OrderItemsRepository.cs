using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgenOrderingSystem.API.DBContext;
using EgenOrderingSystem.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgenOrderingSystem.API.Services
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly OrderSystemContext _orderSystemContext;
        public OrderItemsRepository(OrderSystemContext orderSystemContext)
        {
            _orderSystemContext = orderSystemContext;
        }
        public async Task<OrderItems> GetOrderItemAsync(int orderItemId)
        {
            return await _orderSystemContext.OrderItems.Where(x => x.Id == orderItemId).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<OrderItems>> GetOrderItemsAsync(int orderID)
        {
            return await _orderSystemContext.OrderItems.Where(x => x.OrderId == orderID).ToListAsync();
        }
        public void AddOrderItem(int orderID, OrderItems orderItem)
        {
            if (orderItem == null)
            {
                throw new ArgumentNullException(nameof(orderItem));
            }
            orderItem.OrderId = orderID;
            _orderSystemContext.OrderItems.Add(orderItem);

        }

        public async Task<bool> SaveAsync()
        {
            return await _orderSystemContext.SaveChangesAsync() > 0;
        }
        public void UpdateOrderItem(OrderItems orderItem)
        {
            _orderSystemContext.OrderItems.Update(orderItem);
        }

        public void CreateOrderItem(OrderItems orderItem)
        {
            _orderSystemContext.OrderItems.Add(orderItem);
        }
        public async Task<OrderItems> GetItemAsync(int orderId, int itemId)
        {
            var res = _orderSystemContext.Orders.Where(x => x.Id == orderId).Include(y => y.OrderItems).FirstOrDefault();
            var item = res.OrderItems.Where(x => x.Id == itemId).FirstOrDefault();
            return item;
        }

        public void DeleteItem(OrderItems orderItem)
        {
            _orderSystemContext.Remove(orderItem);
        }
    }
}
