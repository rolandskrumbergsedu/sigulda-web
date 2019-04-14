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
using Sigulda.WEB.Contexts.spiderman;

namespace Sigulda.WEB.Controllers.spiderman
{
    public class MonitoriController : ApiController
    {
        private SpidermanModel db = new SpidermanModel();

        // GET: api/Monitori
        public IQueryable<Monitori> GetMonitori()
        {
            return db.Monitori;
        }

        // GET: api/Monitori/5
        [ResponseType(typeof(Monitori))]
        public IHttpActionResult GetMonitori(int id)
        {
            Monitori monitori = db.Monitori.Find(id);
            if (monitori == null)
            {
                return NotFound();
            }

            return Ok(monitori);
        }

        // PUT: api/Monitori/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitori(int id, Monitori monitori)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitori.Monitori_ID)
            {
                return BadRequest();
            }

            db.Entry(monitori).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitoriExists(id))
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

        // POST: api/Monitori
        [ResponseType(typeof(Monitori))]
        public IHttpActionResult PostMonitori(Monitori monitori)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monitori.Add(monitori);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MonitoriExists(monitori.Monitori_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = monitori.Monitori_ID }, monitori);
        }

        // DELETE: api/Monitori/5
        [ResponseType(typeof(Monitori))]
        public IHttpActionResult DeleteMonitori(int id)
        {
            Monitori monitori = db.Monitori.Find(id);
            if (monitori == null)
            {
                return NotFound();
            }

            db.Monitori.Remove(monitori);
            db.SaveChanges();

            return Ok(monitori);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonitoriExists(int id)
        {
            return db.Monitori.Count(e => e.Monitori_ID == id) > 0;
        }
    }
}