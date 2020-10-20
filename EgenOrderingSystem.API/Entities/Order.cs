using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public int DeliveryMethodId { get; set; }

        public DeliveryMethods DeliveryMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AddressID { get; set; }

        public List<OrderItems> OrderItems { get; set; } 

        //public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }


    }
}
