using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models.Entities
{
    public class Doctor : BaseEntity
    {
        [Required]
        public string DoctorName { get; set; }


        public virtual ICollection<PatientDoctor> Patients { get; set; }


        public virtual Hospital Hospital { get; set; }
        public int? HospitalId { get; set; }

        public Doctor() { Patients = new List<PatientDoctor>(); }
    }
}