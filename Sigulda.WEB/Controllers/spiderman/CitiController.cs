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
    public class CitiController : ApiController
    {
        private SpidermanModel db = new SpidermanModel();

        // GET: api/Citi
        public IQueryable<Citi> GetCiti()
        {
            return db.Citi;
        }

        // GET: api/Citi/5
        [ResponseType(typeof(Citi))]
        public IHttpActionResult GetCiti(int id)
        {
            Citi citi = db.Citi.Find(id);
            if (citi == null)
            {
                return NotFound();
            }

            return Ok(citi);
        }

        // PUT: api/Citi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCiti(int id, Citi citi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citi.Citi_ID)
            {
                return BadRequest();
            }

            db.Entry(citi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitiExists(id))
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

        // POST: api/Citi
        [ResponseType(typeof(Citi))]
        public IHttpActionResult PostCiti(Citi citi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Citi.Add(citi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CitiExists(citi.Citi_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("SpidermanApi-Citi", new { id = citi.Citi_ID }, citi);
        }

        // DELETE: api/Citi/5
        [ResponseType(typeof(Citi))]
        public IHttpActionResult DeleteCiti(int id)
        {
            Citi citi = db.Citi.Find(id);
            if (citi == null)
            {
                return NotFound();
            }

            db.Citi.Remove(citi);
            db.SaveChanges();

            return Ok(citi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitiExists(int id)
        {
            return db.Citi.Count(e => e.Citi_ID == id) > 0;
        }
    }
}