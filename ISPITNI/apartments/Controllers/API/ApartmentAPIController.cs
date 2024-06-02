using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers.API
{
    public class ApartmentAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApartmenAPI
        public IQueryable<Apartment> GetApartmants()
        {
            return db.Apartmants;
        }

        // GET: api/ApartmenAPI/5
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult GetApartman(int id)
        {
            Apartment apartman = db.Apartmants.Find(id);
            if (apartman == null)
            {
                return NotFound();
            }

            return Ok(apartman);
        }

        // PUT: api/ApartmenAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApartman(int id, Apartment apartman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartman.ID)
            {
                return BadRequest();
            }

            db.Entry(apartman).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApartmenAPI
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult PostApartman(Apartment apartman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apartmants.Add(apartman);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = apartman.ID }, apartman);
        }

        // DELETE: api/ApartmenAPI/5
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult DeleteApartman(int id)
        {
            Apartment apartman = db.Apartmants.Find(id);
            if (apartman == null)
            {
                return NotFound();
            }

            db.Apartmants.Remove(apartman);
            db.SaveChanges();

            return Ok(apartman);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApartmanExists(int id)
        {
            return db.Apartmants.Count(e => e.ID == id) > 0;
        }
    }
}