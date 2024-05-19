using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Patient : BaseEntity
    {

        [Required]
        public string PatientName { get; set; }

        [Required]
        [Range(10000, 99999)]
        public int PatientCode { get; set; }

        public GENDER Gender { get; set; }


        public virtual ICollection<Doctor> doctors { get; set; }

        public Patient()
        {
            doctors = new List<Doctor>();
        }

    }
}