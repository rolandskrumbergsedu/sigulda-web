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
using Sigulda.WEB.Contexts.wolverine;

namespace Sigulda.WEB.Controllers.wolverine
{
    public class KlientiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Klienti
        public IQueryable<Klienti> GetKlientis()
        {
            return db.Klientis;
        }

        // GET: api/Klienti/5
        [ResponseType(typeof(Klienti))]
        public IHttpActionResult GetKlienti(int id)
        {
            Klienti klienti = db.Klientis.Find(id);
            if (klienti == null)
            {
                return NotFound();
            }

            return Ok(klienti);
        }

        // PUT: api/Klienti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlienti(int id, Klienti klienti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klienti.Klienta_ID)
            {
                return BadRequest();
            }

            db.Entry(klienti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlientiExists(id))
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

        // POST: api/Klienti
        [ResponseType(typeof(Klienti))]
        public IHttpActionResult PostKlienti(Klienti klienti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klientis.Add(klienti);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KlientiExists(klienti.Klienta_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-KlientiController", new { id = klienti.Klienta_ID }, klienti);
        }

        // DELETE: api/Klienti/5
        [ResponseType(typeof(Klienti))]
        public IHttpActionResult DeleteKlienti(int id)
        {
            Klienti klienti = db.Klientis.Find(id);
            if (klienti == null)
            {
                return NotFound();
            }

            db.Klientis.Remove(klienti);
            db.SaveChanges();

            return Ok(klienti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KlientiExists(int id)
        {
            return db.Klientis.Count(e => e.Klienta_ID == id) > 0;
        }
    }
}