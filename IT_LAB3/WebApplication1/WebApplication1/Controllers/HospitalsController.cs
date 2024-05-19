using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    public class HospitalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hospitals
        public ActionResult Index()
        {
            return View(db.Hospitals.ToList());
        }

        // GET: Hospitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // GET: Hospitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HospitalName,HospitalLocation,HospitalImage")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital);
        }

        // GET: Hospitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HospitalName,HospitalLocation")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital);
        }

        // GET: Hospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddDoctorToHospital(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Hospital doctor = db.Hospitals.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            List<Doctor> AllPatients = db.Doctors.ToList();

            if (AllPatients.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AddDoctorToHospitalDTO model = new AddDoctorToHospitalDTO( AllPatients,doctor);
            return View(model);
        }



        // POST: Hospitals/AddDoctorToHospital
        [HttpPost]
       
        public ActionResult AddDoctorToHospital(int hospitalId, int doctorId)
        {
            Hospital hospital = db.Hospitals.Find(hospitalId);
            if (hospital == null)
            {
                return HttpNotFound();
            }

            Doctor doctor = db.Doctors.Find(doctorId);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            if (hasDoctor(hospitalId, doctorId))
            {
                ViewBag.ErrorMessage = "This doctor is already part of staff for this hospital.";
                List<Doctor> allDoctors = db.Doctors.ToList();
                AddDoctorToHospitalDTO model = new AddDoctorToHospitalDTO(allDoctors, hospital);
                return View(model);
            }


            if (DoctorIsOperating(doctor))
            {
                ViewBag.ErrorMessage = "This doctor is already operating in another hospital.";
                List<Doctor> allDoctors = db.Doctors.ToList();
                AddDoctorToHospitalDTO model = new AddDoctorToHospitalDTO(allDoctors, hospital);
                return View(model);
            }

            hospital.doctors.Add(doctor);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = hospitalId });
        }

        private bool hasDoctor(int hospitalId, int doctorId)
        {
              return db.Hospitals.Find(hospitalId).doctors.Any(d => d.ID == doctorId);
        }

        private bool DoctorIsOperating(Doctor doctor)
        {
            return db.Hospitals.Any(h => h.doctors.Any(d => d.ID == doctor.ID));
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
