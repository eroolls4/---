using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DTOs
{
    public class AddDoctorToHospitalDTO
    {
        public List<Doctor> Doctors { get; set; }
        public Hospital Hospital { get; set; }

        public AddDoctorToHospitalDTO(List<Doctor> doctors, Hospital hospital)
        {
            Doctors = doctors;
            Hospital = hospital;
        }
    }
}