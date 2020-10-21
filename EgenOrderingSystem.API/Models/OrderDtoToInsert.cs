using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Models
{
    public class OrderDtoToInsert
    {
        public string Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public int DeliveryMethodId { get; set; }
        public int CustomerId { get; set; }
        public int AddressID { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItemsToInsert> OrderItems { get; set; } = new List<OrderItemsToInsert>();
    }
}
