using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgenOrderingSystem.API.DBContext;
using EgenOrderingSystem.API.Entities;

namespace EgenOrderingSystem.API.Services
{
    public class OrderRepository : IOrderRepository,IDisposable
    {
        private readonly OrderSystemContext _orderSystemContext;
        public OrderRepository(OrderSystemContext orderSystemContext)
        {
            _orderSystemContext = orderSystemContext;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Order GetOrder(int orderId)
        {
            return _orderSystemContext.Orders.Where(x => x.Id == orderId).FirstOrDefault();
        }

        public bool OrderExists(int orderId)
        {
            var res = _orderSystemContext.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            return res != null;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderSystemContext.Orders.ToList();
        }
        public IEnumerable<OrderItems> GetOrderItems(int orderId)
        {
            return _orderSystemContext.OrderItems.Where(x => x.OrderId == orderId);
        }
        public OrderItems GetOrderItem(int orderId, int itemId)
        {
            return _orderSystemContext.OrderItems.Where(x => x.OrderId == orderId && x.Id == itemId).FirstOrDefault();

        }
        public void UpdateOrder(int orderId)
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
