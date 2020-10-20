using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Entities
{
    public class OrderPaymentDetails
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CardId { get; set; }
        public IEnumerable<Cards> Card { get; set; }
        public decimal Amount { get; set; }
        public int OrderPaymentId { get; set; }

        public OrderPayment OrderPayment { get; set; }
    }
}
