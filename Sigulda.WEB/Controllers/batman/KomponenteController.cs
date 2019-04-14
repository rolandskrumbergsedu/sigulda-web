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
using Sigulda.WEB.Contexts.batman;

namespace Sigulda.WEB.Controllers.batman
{
    public class KomponenteController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/Komponente
        public IQueryable<Komponente> GetKomponentes1()
        {
            return db.Komponente;
        }

        // GET: api/Komponente/5
        [ResponseType(typeof(Komponente))]
        public IHttpActionResult GetKomponente(int id)
        {
            Komponente komponente = db.Komponente.Find(id);
            if (komponente == null)
            {
                return NotFound();
            }

            return Ok(komponente);
        }

        // PUT: api/Komponente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKomponente(int id, Komponente komponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != komponente.Komponente_ID)
            {
                return BadRequest();
            }

            db.Entry(komponente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomponenteExists(id))
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

        // POST: api/Komponente
        [ResponseType(typeof(Komponente))]
        public IHttpActionResult PostKomponente(Komponente komponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Komponente.Add(komponente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KomponenteExists(komponente.Komponente_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = komponente.Komponente_ID }, komponente);
        }

        // DELETE: api/Komponente/5
        [ResponseType(typeof(Komponente))]
        public IHttpActionResult DeleteKomponente(int id)
        {
            Komponente komponente = db.Komponente.Find(id);
            if (komponente == null)
            {
                return NotFound();
            }

            db.Komponente.Remove(komponente);
            db.SaveChanges();

            return Ok(komponente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KomponenteExists(int id)
        {
            return db.Komponente.Count(e => e.Komponente_ID == id) > 0;
        }
    }
}