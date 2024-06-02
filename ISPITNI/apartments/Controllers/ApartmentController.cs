using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{

    [Authorize(Roles ="admin,user")]
    public class ApartmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apartmen
        [Authorize(Roles = "user,admin")]
        public ActionResult Index()
        {
            var apartmants = db.Apartmants.Include(a => a.City);
            return View(apartmants.ToList());
        }

        // GET: Apartmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartman = db.Apartmants.Include(a => a.City).FirstOrDefault(a => a.ID == id);
            if (apartman == null)
            {
                return HttpNotFound();
            }
            return View(apartman);
        }

        // GET: Apartmen/Create
        public ActionResult Create()
        {
            //ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            return View();
        }

        // POST: Apartmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Address,PricePerDay,Image")] Apartment apartman)
        {
            if (ModelState.IsValid)
            {
                db.Apartmants.Add(apartman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", apartman.CityID);
            return View(apartman);
        }

        // GET: Apartmen/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartman = db.Apartmants.Find(id);
            if (apartman == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", apartman.CityID);
            return View(apartman);
        }

        // POST: Apartmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Address,PricePerDay,Image")] Apartment apartman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", apartman.CityID);
            return View(apartman);
        }

        // GET: Apartmen/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartment apartman = db.Apartmants.Find(id);
            if (apartman == null)
            {
                return HttpNotFound();
            }
            return View(apartman);
        }

        // POST: Apartmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apartment apartman = db.Apartmants.Find(id);
            db.Apartmants.Remove(apartman);
            db.SaveChanges();
            return RedirectToAction("Index");
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
