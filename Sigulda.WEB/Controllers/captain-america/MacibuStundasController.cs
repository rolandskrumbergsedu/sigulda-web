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
    public class MacibuStundasController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/MacibuStundas
        public IQueryable<MacibuStunda> GetMacibu_stunda()
        {
            return db.Macibu_stunda;
        }

        // GET: api/MacibuStundas/5
        [ResponseType(typeof(MacibuStunda))]
        public IHttpActionResult GetMacibuStunda(int id)
        {
            MacibuStunda macibuStunda = db.Macibu_stunda.Find(id);
            if (macibuStunda == null)
            {
                return NotFound();
            }

            return Ok(macibuStunda);
        }

        // PUT: api/MacibuStundas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMacibuStunda(int id, MacibuStunda macibuStunda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != macibuStunda.Stunda_ID)
            {
                return BadRequest();
            }

            db.Entry(macibuStunda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacibuStundaExists(id))
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

        // POST: api/MacibuStundas
        [ResponseType(typeof(MacibuStunda))]
        public IHttpActionResult PostMacibuStunda(MacibuStunda macibuStunda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Macibu_stunda.Add(macibuStunda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MacibuStundaExists(macibuStunda.Stunda_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = macibuStunda.Stunda_ID }, macibuStunda);
        }

        // DELETE: api/MacibuStundas/5
        [ResponseType(typeof(MacibuStunda))]
        public IHttpActionResult DeleteMacibuStunda(int id)
        {
            MacibuStunda macibuStunda = db.Macibu_stunda.Find(id);
            if (macibuStunda == null)
            {
                return NotFound();
            }

            db.Macibu_stunda.Remove(macibuStunda);
            db.SaveChanges();

            return Ok(macibuStunda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MacibuStundaExists(int id)
        {
            return db.Macibu_stunda.Count(e => e.Stunda_ID == id) > 0;
        }
    }
}