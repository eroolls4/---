using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalSystem.Models;
using HospitalSystem.Models.Entities;

namespace HospitalSystem.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Doctor doctor = db.Doctors
                      .Include(d => d.Patients.Select(pd => pd.Patient))
                      .FirstOrDefault(d => d.Id == id);


            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DoctorName")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DoctorName")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            //  disassociate doctors from this hospital now
            var patientDoctors = db.PatientsDoctors.Where(pd => pd.DoctorId == id).ToList();
            foreach (var pd in patientDoctors)
            {
                db.PatientsDoctors.Remove(pd);
            }

            db.Doctors.Remove(doctor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Doctors/AddPatient
        public ActionResult AddPatient(int? doctorId)
        {
            if (doctorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.DoctorId = doctorId;
            ViewBag.DoctorName = db.Doctors.Find(doctorId).DoctorName;
            var patients = db.Patients.ToList();
            ViewBag.PatientId = new SelectList(patients, "Id", "PatientName");

            return View();
        }

        // POST: Doctors/AddPatient
        [HttpPost]

        public ActionResult AddPatient(int? doctorId, int? patientId)
        {
            if (doctorId == null || patientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var doctor = db.Doctors.Find(doctorId);
            var patient = db.Patients.Find(patientId);

            if (doctor == null || patient == null)
            {
                return HttpNotFound();
            }

            // Check if the patient is already associated with the doctor
            var existingAssociation = db.PatientsDoctors
                                          .Any(pd => pd.DoctorId == doctorId && pd.PatientId == patientId);

            if (!existingAssociation)
            {
                // Create a new association between the doctor and the patient
                var patientDoctor = new PatientDoctor
                {
                    DoctorId = doctorId.Value,
                    PatientId = patientId.Value,
                    Patient = patient
                };

                db.PatientsDoctors.Add(patientDoctor);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = doctorId });
        }



        public ActionResult RemovePatient(int? doctorId, int? patientId)
        {
            if (doctorId == null || patientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var patientDoctor = db.PatientsDoctors
                                  .FirstOrDefault(pd => pd.DoctorId == doctorId && pd.PatientId == patientId);

            if (patientDoctor == null)
            {
                return HttpNotFound();
            }

            db.PatientsDoctors.Remove(patientDoctor);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = doctorId });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
