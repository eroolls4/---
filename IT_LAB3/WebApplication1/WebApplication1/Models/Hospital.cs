using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Hospital : BaseEntity
    {

        [Required]
        public String HospitalName { get; set; }

        [Required]
        public String HospitalLocation { get; set; }


     
        public String HospitalImage {  get; set; }

        public virtual ICollection<Doctor> doctors { get; set; }


        public Hospital() { doctors = new List<Doctor>(); }
    }
}