using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgenOrderingSystem.API.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }
    }
}
