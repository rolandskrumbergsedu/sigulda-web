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
    public class ElektromehaniskaKomponentesController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/ElektromehaniskaKomponentes
        public IQueryable<ElektromehaniskaKomponente> GetElektromehāniskā_komponente()
        {
            return db.Elektromehāniskā_komponente;
        }

        // GET: api/ElektromehaniskaKomponentes/5
        [ResponseType(typeof(ElektromehaniskaKomponente))]
        public IHttpActionResult GetElektromehaniskaKomponente(int id)
        {
            ElektromehaniskaKomponente elektromehaniskaKomponente = db.Elektromehāniskā_komponente.Find(id);
            if (elektromehaniskaKomponente == null)
            {
                return NotFound();
            }

            return Ok(elektromehaniskaKomponente);
        }

        // PUT: api/ElektromehaniskaKomponentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElektromehaniskaKomponente(int id, ElektromehaniskaKomponente elektromehaniskaKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elektromehaniskaKomponente.Elektromehāniskā_komponente_ID)
            {
                return BadRequest();
            }

            db.Entry(elektromehaniskaKomponente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElektromehaniskaKomponenteExists(id))
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

        // POST: api/ElektromehaniskaKomponentes
        [ResponseType(typeof(ElektromehaniskaKomponente))]
        public IHttpActionResult PostElektromehaniskaKomponente(ElektromehaniskaKomponente elektromehaniskaKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elektromehāniskā_komponente.Add(elektromehaniskaKomponente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ElektromehaniskaKomponenteExists(elektromehaniskaKomponente.Elektromehāniskā_komponente_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elektromehaniskaKomponente.Elektromehāniskā_komponente_ID }, elektromehaniskaKomponente);
        }

        // DELETE: api/ElektromehaniskaKomponentes/5
        [ResponseType(typeof(ElektromehaniskaKomponente))]
        public IHttpActionResult DeleteElektromehaniskaKomponente(int id)
        {
            ElektromehaniskaKomponente elektromehaniskaKomponente = db.Elektromehāniskā_komponente.Find(id);
            if (elektromehaniskaKomponente == null)
            {
                return NotFound();
            }

            db.Elektromehāniskā_komponente.Remove(elektromehaniskaKomponente);
            db.SaveChanges();

            return Ok(elektromehaniskaKomponente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElektromehaniskaKomponenteExists(int id)
        {
            return db.Elektromehāniskā_komponente.Count(e => e.Elektromehāniskā_komponente_ID == id) > 0;
        }
    }
}