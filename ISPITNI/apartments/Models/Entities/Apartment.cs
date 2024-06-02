using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class Apartment : BaseEntity
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(100),MinLength(12)]
        public string Address { get; set; }
        public float PricePerDay { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int? CityID { get; set; }
        public City City { get; set; }  

    }
}