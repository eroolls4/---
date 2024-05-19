using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DTOs
{
    public class AddPatientToDoctorDTO
    {
        public Doctor doctor { get; set; }
        public List<Patient> patients { get; set; }

        public AddPatientToDoctorDTO(Doctor doctor, List<Patient> patients)
        {
            this.doctor = doctor;
            this.patients = patients;
        }
    }
}