using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Doctor : BaseEntity
    {
        [Required]
        public String DoctorName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

        public virtual Hospital Hospital { get; set; }


        public Doctor()   {  Patients = new List<Patient>(); }

    }
}