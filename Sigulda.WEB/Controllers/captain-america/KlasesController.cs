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
using Sigulda.WEB.Contexts.captain_america;

namespace Sigulda.WEB.Controllers.captain_america
{
    public class KlasesController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/Klases
        public IQueryable<Klase> GetKlases()
        {
            return db.Klases;
        }

        // GET: api/Klases/5
        [ResponseType(typeof(Klase))]
        public IHttpActionResult GetKlase(int id)
        {
            Klase klase = db.Klases.Find(id);
            if (klase == null)
            {
                return NotFound();
            }

            return Ok(klase);
        }

        // PUT: api/Klases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlase(int id, Klase klase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klase.Klase_ID)
            {
                return BadRequest();
            }

            db.Entry(klase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlaseExists(id))
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

        // POST: api/Klases
        [ResponseType(typeof(Klase))]
        public IHttpActionResult PostKlase(Klase klase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klases.Add(klase);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KlaseExists(klase.Klase_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = klase.Klase_ID }, klase);
        }

        // DELETE: api/Klases/5
        [ResponseType(typeof(Klase))]
        public IHttpActionResult DeleteKlase(int id)
        {
            Klase klase = db.Klases.Find(id);
            if (klase == null)
            {
                return NotFound();
            }

            db.Klases.Remove(klase);
            db.SaveChanges();

            return Ok(klase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlaseExists(int id)
        {
            return db.Klases.Count(e => e.Klase_ID == id) > 0;
        }
    }
}