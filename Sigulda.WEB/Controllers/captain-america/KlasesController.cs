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
using Sigulda.WEB.Controllers.captain_america.ViewModels;

namespace Sigulda.WEB.Controllers.captain_america
{
    public class KlasesController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/Klases
        public IQueryable<KlaseViewModel> GetKlases()
        {
            return db.Klases.Select(x => new KlaseViewModel {
                Klase_ID = x.Klase_ID,
                Grupa = x.Grupa,
                Klase = x.Klase1
            });
        }

        // GET: api/Klases/5
        [ResponseType(typeof(KlaseViewModel))]
        public IHttpActionResult GetKlase(int id)
        {
            Klase klase = db.Klases.Find(id);
            if (klase == null)
            {
                return NotFound();
            }

            return Ok(new KlaseViewModel
            {
                Klase_ID = klase.Klase_ID,
                Klase = klase.Klase1,
                Grupa = klase.Grupa
            });
        }

        // PUT: api/Klases/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKlase(int id, KlaseViewModel klaseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var klase = db.Klases.FirstOrDefault(x => x.Klase_ID == klaseModel.Klase_ID);
            klase.Klase1 = klaseModel.Klase;
            klase.Grupa = klaseModel.Grupa;

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
        [ResponseType(typeof(KlaseViewModel))]
        public IHttpActionResult PostKlase(KlaseViewModel klaseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var klase = new Klase
            {
                Klase_ID = klaseModel.Klase_ID,
                Grupa = klaseModel.Grupa,
                Klase1 = klaseModel.Klase
            };
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

            return CreatedAtRoute("CaptinAmericaApi-Klase", new { id = klase.Klase_ID }, new KlaseViewModel {
                Klase_ID = klase.Klase_ID,
                Grupa = klase.Grupa,
                Klase = klase.Klase1
            });
        }

        // DELETE: api/Klases/5
        [ResponseType(typeof(KlaseViewModel))]
        public IHttpActionResult DeleteKlase(int id)
        {
            Klase klase = db.Klases.Find(id);
            if (klase == null)
            {
                return NotFound();
            }

            db.Klases.Remove(klase);
            db.SaveChanges();

            return Ok(new KlaseViewModel
            {
                Klase_ID = klase.Klase_ID,
                Klase = klase.Klase1,
                Grupa = klase.Grupa
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

        private bool KlaseExists(int id)
        {
            return db.Klases.Count(e => e.Klase_ID == id) > 0;
        }
    }
}