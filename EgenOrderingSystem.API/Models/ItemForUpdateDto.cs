using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Models
{
    public class ItemForUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
