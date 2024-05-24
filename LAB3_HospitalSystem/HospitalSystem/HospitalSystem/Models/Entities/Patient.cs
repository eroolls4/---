using HospitalSystem.Models.Entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models.Entities
{
    public class Patient : BaseEntity
    {
        [Required]
        public string PatientName { get; set; }
        [Required]
        [Range(10000, 99999)]
        public int PatientCode { get; set; }
        public GENDER Gender { get; set; }
        public virtual ICollection<PatientDoctor> Doctors { get; set; } =new List<PatientDoctor>();
    }
}