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
using Sigulda.WEB.Controllers.wolverine.ViewModels;

namespace Sigulda.WEB.Controllers.wolverine
{
    public class KlientiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Klienti
        public IQueryable<KlientiViewModel> GetKlientis()
        {
            return db.Klientis.Select(_ => new KlientiViewModel
            {
                e_pasts = _.e_pasts,
                Klienta_ID = _.Klienta_ID,
                Klienta_uzvards = _.Klienta_uzvards,
                Klienta_vards = _.Klienta_vards,
                telefons = _.telefons
            });
        }

        // GET: api/Klienti/5
        [ResponseType(typeof(KlientiViewModel))]
        public IHttpActionResult GetKlienti(int id)
        {
            Klienti klienti = db.Klientis.Find(id);
            if (klienti == null)
            {
                return NotFound();
            }

            return Ok(new KlientiViewModel
            {
                e_pasts = klienti.e_pasts,
                Klienta_ID = klienti.Klienta_ID,
                Klienta_uzvards = klienti.Klienta_uzvards,
                Klienta_vards = klienti.Klienta_vards,
                telefons = klienti.telefons
            });
        }

        // PUT: api/Klienti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlienti(int id, KlientiViewModel klienti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klienti.Klienta_ID)
            {
                return BadRequest();
            }

            var entry = db.Klientis.FirstOrDefault(_ => _.Klienta_ID == klienti.Klienta_ID);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Klienta_uzvards = klienti.Klienta_uzvards;
            entry.Klienta_vards = klienti.Klienta_vards;
            entry.telefons = klienti.telefons;
            entry.e_pasts = klienti.e_pasts;

            db.Entry(entry).State = EntityState.Modified;

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
        [ResponseType(typeof(KlientiViewModel))]
        public IHttpActionResult PostKlienti(KlientiViewModel klienti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Klientis.Add(new Klienti
            {
                Klienta_ID = klienti.Klienta_ID,
                e_pasts = klienti.e_pasts,
                telefons = klienti.telefons,
                Klienta_vards = klienti.Klienta_vards,
                Klienta_uzvards = klienti.Klienta_uzvards
            });

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
        [ResponseType(typeof(KlientiViewModel))]
        public IHttpActionResult DeleteKlienti(int id)
        {
            Klienti klienti = db.Klientis.Find(id);
            if (klienti == null)
            {
                return NotFound();
            }

            db.Klientis.Remove(klienti);
            db.SaveChanges();

            return Ok(new KlientiViewModel
            {
                e_pasts = klienti.e_pasts,
                Klienta_ID = klienti.Klienta_ID,
                Klienta_uzvards = klienti.Klienta_uzvards,
                Klienta_vards = klienti.Klienta_vards,
                telefons = klienti.telefons
            });
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