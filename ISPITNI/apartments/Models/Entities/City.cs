using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public float Country { get; set; }

        public virtual List<Apartment> Apartments { get; set; } =new List<Apartment>();
    
    }
}