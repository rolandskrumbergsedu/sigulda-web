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
    public class MacibuPrieksmetsController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/MacibuPrieksmets
        public IQueryable<MacibuPrieksmetsViewModel> GetMacibu_prieksmets()
        {
            return db.Macibu_prieksmets.Select(x => new MacibuPrieksmetsViewModel
            {
                Prieksmets_ID = x.Prieksmets_ID,
                Stundas_nosaukums = x.Stundas_nosaukums
            });
        }

        // GET: api/MacibuPrieksmets/5
        [ResponseType(typeof(MacibuPrieksmetsViewModel))]
        public IHttpActionResult GetMacibuPrieksmets(int id)
        {
            MacibuPrieksmets macibuPrieksmets = db.Macibu_prieksmets.Find(id);
            if (macibuPrieksmets == null)
            {
                return NotFound();
            }

            return Ok(new MacibuPrieksmetsViewModel {
                Prieksmets_ID = macibuPrieksmets.Prieksmets_ID,
                Stundas_nosaukums = macibuPrieksmets.Stundas_nosaukums
            });
        }

        // PUT: api/MacibuPrieksmets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMacibuPrieksmets(int id, MacibuPrieksmetsViewModel macibuPrieksmetsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var macibuPrieksmets = db.Macibu_prieksmets.FirstOrDefault(x => x.Prieksmets_ID == macibuPrieksmetsModel.Prieksmets_ID);

            if (id != macibuPrieksmets.Prieksmets_ID)
            {
                return BadRequest();
            }

            macibuPrieksmets.Stundas_nosaukums = macibuPrieksmetsModel.Stundas_nosaukums;
            db.Entry(macibuPrieksmets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacibuPrieksmetsExists(id))
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

        // POST: api/MacibuPrieksmets
        [ResponseType(typeof(MacibuPrieksmetsViewModel))]
        public IHttpActionResult PostMacibuPrieksmets(MacibuPrieksmetsViewModel macibuPrieksmetsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var macibuPrieksmets = new MacibuPrieksmets
            {
                Prieksmets_ID = macibuPrieksmetsModel.Prieksmets_ID,
                Stundas_nosaukums = macibuPrieksmetsModel.Stundas_nosaukums
            };

            db.Macibu_prieksmets.Add(macibuPrieksmets);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MacibuPrieksmetsExists(macibuPrieksmets.Prieksmets_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("CaptinAmericaApi-MacibuPrieksmets", new { id = macibuPrieksmets.Prieksmets_ID }, new MacibuPrieksmetsViewModel {
                Prieksmets_ID = macibuPrieksmets.Prieksmets_ID,
                Stundas_nosaukums = macibuPrieksmets.Stundas_nosaukums
            });
        }

        // DELETE: api/MacibuPrieksmets/5
        [ResponseType(typeof(MacibuPrieksmetsViewModel))]
        public IHttpActionResult DeleteMacibuPrieksmets(int id)
        {
            MacibuPrieksmets macibuPrieksmets = db.Macibu_prieksmets.Find(id);
            if (macibuPrieksmets == null)
            {
                return NotFound();
            }

            db.Macibu_prieksmets.Remove(macibuPrieksmets);
            db.SaveChanges();

            return Ok(new MacibuPrieksmetsViewModel {
                Prieksmets_ID = macibuPrieksmets.Prieksmets_ID,
                Stundas_nosaukums = macibuPrieksmets.Stundas_nosaukums
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

        private bool MacibuPrieksmetsExists(int id)
        {
            return db.Macibu_prieksmets.Count(e => e.Prieksmets_ID == id) > 0;
        }
    }
}