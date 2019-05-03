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
    public class PasivaKomponentesController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/PasivaKomponentes
        public IQueryable<PasivaKomponente> GetPasīvā_komponente()
        {
            return db.PasīvasKomponentes;
        }

        // GET: api/PasivaKomponentes/5
        [ResponseType(typeof(PasivaKomponente))]
        public IHttpActionResult GetPasivaKomponente(int id)
        {
            PasivaKomponente pasivaKomponente = db.PasīvasKomponentes.Find(id);
            if (pasivaKomponente == null)
            {
                return NotFound();
            }

            return Ok(pasivaKomponente);
        }

        // PUT: api/PasivaKomponentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasivaKomponente(int id, PasivaKomponente pasivaKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasivaKomponente.Pasīvā_komponente_ID)
            {
                return BadRequest();
            }

            db.Entry(pasivaKomponente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasivaKomponenteExists(id))
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

        // POST: api/PasivaKomponentes
        [ResponseType(typeof(PasivaKomponente))]
        public IHttpActionResult PostPasivaKomponente(PasivaKomponente pasivaKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PasīvasKomponentes.Add(pasivaKomponente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PasivaKomponenteExists(pasivaKomponente.Pasīvā_komponente_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("BatmanApi-PasivaKomponente", new { id = pasivaKomponente.Pasīvā_komponente_ID }, pasivaKomponente);
        }

        // DELETE: api/PasivaKomponentes/5
        [ResponseType(typeof(PasivaKomponente))]
        public IHttpActionResult DeletePasivaKomponente(int id)
        {
            PasivaKomponente pasivaKomponente = db.PasīvasKomponentes.Find(id);
            if (pasivaKomponente == null)
            {
                return NotFound();
            }

            db.PasīvasKomponentes.Remove(pasivaKomponente);
            db.SaveChanges();

            return Ok(pasivaKomponente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasivaKomponenteExists(int id)
        {
            return db.PasīvasKomponentes.Count(e => e.Pasīvā_komponente_ID == id) > 0;
        }
    }
}