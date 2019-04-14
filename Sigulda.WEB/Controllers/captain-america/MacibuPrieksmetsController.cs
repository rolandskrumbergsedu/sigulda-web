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
    public class MacibuPrieksmetsController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/MacibuPrieksmets
        public IQueryable<MacibuPrieksmets> GetMacibu_prieksmets()
        {
            return db.Macibu_prieksmets;
        }

        // GET: api/MacibuPrieksmets/5
        [ResponseType(typeof(MacibuPrieksmets))]
        public IHttpActionResult GetMacibuPrieksmets(int id)
        {
            MacibuPrieksmets macibuPrieksmets = db.Macibu_prieksmets.Find(id);
            if (macibuPrieksmets == null)
            {
                return NotFound();
            }

            return Ok(macibuPrieksmets);
        }

        // PUT: api/MacibuPrieksmets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMacibuPrieksmets(int id, MacibuPrieksmets macibuPrieksmets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != macibuPrieksmets.Prieksmets_ID)
            {
                return BadRequest();
            }

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
        [ResponseType(typeof(MacibuPrieksmets))]
        public IHttpActionResult PostMacibuPrieksmets(MacibuPrieksmets macibuPrieksmets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            return CreatedAtRoute("DefaultApi", new { id = macibuPrieksmets.Prieksmets_ID }, macibuPrieksmets);
        }

        // DELETE: api/MacibuPrieksmets/5
        [ResponseType(typeof(MacibuPrieksmets))]
        public IHttpActionResult DeleteMacibuPrieksmets(int id)
        {
            MacibuPrieksmets macibuPrieksmets = db.Macibu_prieksmets.Find(id);
            if (macibuPrieksmets == null)
            {
                return NotFound();
            }

            db.Macibu_prieksmets.Remove(macibuPrieksmets);
            db.SaveChanges();

            return Ok(macibuPrieksmets);
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