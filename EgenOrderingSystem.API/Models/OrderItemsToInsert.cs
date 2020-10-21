using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Models
{
    public class OrderItemsToInsert
    {
        public int Quantity { get; set; }
        public int ProductsID { get; set; }
    }
}
