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
    public class EnergijasKomponentesController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/EnergijasKomponentes
        public IQueryable<EnergijasKomponente> GetEnerģijas_komponente()
        {
            return db.Enerģijas_komponente;
        }

        // GET: api/EnergijasKomponentes/5
        [ResponseType(typeof(EnergijasKomponente))]
        public IHttpActionResult GetEnergijasKomponente(int id)
        {
            EnergijasKomponente energijasKomponente = db.Enerģijas_komponente.Find(id);
            if (energijasKomponente == null)
            {
                return NotFound();
            }

            return Ok(energijasKomponente);
        }

        // PUT: api/EnergijasKomponentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnergijasKomponente(int id, EnergijasKomponente energijasKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != energijasKomponente.Enerģijas_komponente_ID)
            {
                return BadRequest();
            }

            db.Entry(energijasKomponente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnergijasKomponenteExists(id))
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

        // POST: api/EnergijasKomponentes
        [ResponseType(typeof(EnergijasKomponente))]
        public IHttpActionResult PostEnergijasKomponente(EnergijasKomponente energijasKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enerģijas_komponente.Add(energijasKomponente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EnergijasKomponenteExists(energijasKomponente.Enerģijas_komponente_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = energijasKomponente.Enerģijas_komponente_ID }, energijasKomponente);
        }

        // DELETE: api/EnergijasKomponentes/5
        [ResponseType(typeof(EnergijasKomponente))]
        public IHttpActionResult DeleteEnergijasKomponente(int id)
        {
            EnergijasKomponente energijasKomponente = db.Enerģijas_komponente.Find(id);
            if (energijasKomponente == null)
            {
                return NotFound();
            }

            db.Enerģijas_komponente.Remove(energijasKomponente);
            db.SaveChanges();

            return Ok(energijasKomponente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnergijasKomponenteExists(int id)
        {
            return db.Enerģijas_komponente.Count(e => e.Enerģijas_komponente_ID == id) > 0;
        }
    }
}