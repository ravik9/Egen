using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Entities
{
    public class OrderPayment
    {
        [Key]
        public int Id { get; set; }
        public int ConfirmationNumber { get; set; }
        
    }
}
