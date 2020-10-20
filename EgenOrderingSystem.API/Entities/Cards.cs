using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Entities
{
    public class Cards
    {       
        [Key]
        public int Id { get; set; }
        
        public long CardNumber { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }
    }
}
