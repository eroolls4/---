using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalSystem.Models.Entities
{
    public class Hospital : BaseEntity
    {
        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string HospitalLocation { get; set; }
        [Required]
        public string HospitalImage { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}