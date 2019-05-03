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
    public class AktivaKomponentesController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/AktivaKomponentes
        public IQueryable<AktivaKomponente> GetAktīvā_komponente()
        {
            return db.AktivasKomponentes;
        }

        // GET: api/AktivaKomponentes/5
        [ResponseType(typeof(AktivaKomponente))]
        public IHttpActionResult GetAktivaKomponente(int id)
        {
            AktivaKomponente aktivaKomponente = db.AktivasKomponentes.Find(id);
            if (aktivaKomponente == null)
            {
                return NotFound();
            }

            return Ok(aktivaKomponente);
        }

        // PUT: api/AktivaKomponentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAktivaKomponente(int id, AktivaKomponente aktivaKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aktivaKomponente.Aktīvās_komponentes_ID)
            {
                return BadRequest();
            }

            db.Entry(aktivaKomponente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AktivaKomponenteExists(id))
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

        // POST: api/AktivaKomponentes
        [ResponseType(typeof(AktivaKomponente))]
        public IHttpActionResult PostAktivaKomponente(AktivaKomponente aktivaKomponente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AktivasKomponentes.Add(aktivaKomponente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AktivaKomponenteExists(aktivaKomponente.Aktīvās_komponentes_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("BatmanApi-AktivaKomponentes", new { id = aktivaKomponente.Aktīvās_komponentes_ID }, aktivaKomponente);
        }

        // DELETE: api/AktivaKomponentes/5
        [ResponseType(typeof(AktivaKomponente))]
        public IHttpActionResult DeleteAktivaKomponente(int id)
        {
            AktivaKomponente aktivaKomponente = db.AktivasKomponentes.Find(id);
            if (aktivaKomponente == null)
            {
                return NotFound();
            }

            db.AktivasKomponentes.Remove(aktivaKomponente);
            db.SaveChanges();

            return Ok(aktivaKomponente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AktivaKomponenteExists(int id)
        {
            return db.AktivasKomponentes.Count(e => e.Aktīvās_komponentes_ID == id) > 0;
        }
    }
}