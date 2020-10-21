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
        public OrderItems GetOrderItem(int orderItemId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<OrderItems> GetOrderItems(int orderID)
        {
            return _orderSystemContext.OrderItems.Where(x => x.OrderId == orderID);
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

        public void Save()
        {
            _orderSystemContext.SaveChanges();
        }
        public void UpdateOrderItem(OrderItems orderItem)
        {
            _orderSystemContext.OrderItems.Update(orderItem);
        }

        public void CreateOrderItem(OrderItems orderItem)
        {
            _orderSystemContext.OrderItems.Add(orderItem);
        }
        public OrderItems GetItem(int orderId, int itemId)
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
