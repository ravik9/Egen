using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgenOrderingSystem.API.DBContext;
using EgenOrderingSystem.API.Entities;
using Microsoft.AspNetCore.Mvc;

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

        public void UpdateOrderItem(int orderItemId)
        {
            throw new NotImplementedException();
        }
    }
}
