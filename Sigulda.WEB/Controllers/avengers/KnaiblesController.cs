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
using Sigulda.WEB.Contexts.avengers;

namespace Sigulda.WEB.Controllers.avengers
{
    public class KnaiblesController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Knaibles
        public IQueryable<Knaibles> GetKnaibles()
        {
            return db.Knaibles;
        }

        // GET: api/Knaibles/5
        [ResponseType(typeof(Knaibles))]
        public IHttpActionResult GetKnaibles(int id)
        {
            Knaibles knaibles = db.Knaibles.Find(id);
            if (knaibles == null)
            {
                return NotFound();
            }

            return Ok(knaibles);
        }

        // PUT: api/Knaibles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnaibles(int id, Knaibles knaibles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != knaibles.Knaibles_ID)
            {
                return BadRequest();
            }

            db.Entry(knaibles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnaiblesExists(id))
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

        // POST: api/Knaibles
        [ResponseType(typeof(Knaibles))]
        public IHttpActionResult PostKnaibles(Knaibles knaibles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Knaibles.Add(knaibles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KnaiblesExists(knaibles.Knaibles_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("AvengersApi-Knaibles", new { id = knaibles.Knaibles_ID }, knaibles);
        }

        // DELETE: api/Knaibles/5
        [ResponseType(typeof(Knaibles))]
        public IHttpActionResult DeleteKnaibles(int id)
        {
            Knaibles knaibles = db.Knaibles.Find(id);
            if (knaibles == null)
            {
                return NotFound();
            }

            db.Knaibles.Remove(knaibles);
            db.SaveChanges();

            return Ok(knaibles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KnaiblesExists(int id)
        {
            return db.Knaibles.Count(e => e.Knaibles_ID == id) > 0;
        }
    }
}