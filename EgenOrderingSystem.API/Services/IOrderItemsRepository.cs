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
        void UpdateOrderItem(int orderItemId);
    }
}
