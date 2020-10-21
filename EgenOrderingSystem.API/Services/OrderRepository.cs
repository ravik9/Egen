using EgenOrderingSystem.API.DBContext;
using EgenOrderingSystem.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EgenOrderingSystem.API.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderSystemContext _orderSystemContext;
        public OrderRepository(OrderSystemContext orderSystemContext)
        {
            _orderSystemContext = orderSystemContext;
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

        public void AddOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            _orderSystemContext.Orders.Add(order);

        }
        public void Save()
        {
            _orderSystemContext.SaveChanges();
        }
    }
}
