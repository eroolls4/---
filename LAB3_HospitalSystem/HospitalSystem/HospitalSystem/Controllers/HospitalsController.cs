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
            Hospital hospital = db.Hospitals
                                 .Include(h => h.Doctors)
                                 .FirstOrDefault(d => d.Id == id);


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
        public ActionResult Create([Bind(Include = "Id,HospitalName,HospitalLocation,HospitalImage")] Hospital hospital)
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
        public ActionResult Edit([Bind(Include = "Id,HospitalName,HospitalLocation,HospitalImage")] Hospital hospital)
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

            if (hospital == null)
            {
                return HttpNotFound();
            }

            //  disassociate doctors from this hospital now
            var doctors = db.Doctors.Where(d => d.HospitalId == id).ToList();
            foreach (var doctor in doctors)
            {
                doctor.HospitalId = null; // Disassociate doctor from hospital making it null
            }

            db.Hospitals.Remove(hospital);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



       
        public ActionResult AddDoctor(int? hospitalId)
        {
            if (hospitalId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.HospitalId =  hospitalId;
            ViewBag.HospitalName = db.Hospitals.Find(hospitalId).HospitalName;
            var doctors = db.Doctors.Where(dr => dr.HospitalId == null).ToList();
            ViewBag.DoctorId = new SelectList(doctors, "Id", "DoctorName");

            return View();
        }

        // POST: Doctors/AddPatient
        [HttpPost]

        public ActionResult AddDoctor(int? hospitalId, int? doctorId)
        {
            if (hospitalId == null || doctorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var hospital = db.Hospitals.Find(hospitalId);
            var doctor = db.Doctors.Find(doctorId);

            if (hospital == null || doctor == null)
            {
                return HttpNotFound();
            }

                hospital.Doctors.Add(doctor);
                db.SaveChanges();
         
            return RedirectToAction("Details", new { id = hospitalId });
        }



        public ActionResult RemoveDoctor(int? hospitalId, int? doctorId)
        {
            if (hospitalId == null || doctorId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var hospital = db.Hospitals.Find(hospitalId);
            var doctor = db.Doctors.Find(doctorId);
            doctor.HospitalId = null;

            hospital.Doctors.Remove(doctor);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = hospitalId });
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
