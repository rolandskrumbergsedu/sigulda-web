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
    public class TafelesController : ApiController
    {
        private SpidermanModel db = new SpidermanModel();

        // GET: api/Tafeles
        public IQueryable<Tafeles> GetTafeles()
        {
            return db.Tafeles;
        }

        // GET: api/Tafeles/5
        [ResponseType(typeof(Tafeles))]
        public IHttpActionResult GetTafeles(int id)
        {
            Tafeles tafeles = db.Tafeles.Find(id);
            if (tafeles == null)
            {
                return NotFound();
            }

            return Ok(tafeles);
        }

        // PUT: api/Tafeles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTafeles(int id, Tafeles tafeles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tafeles.Tafeles_ID)
            {
                return BadRequest();
            }

            db.Entry(tafeles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TafelesExists(id))
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

        // POST: api/Tafeles
        [ResponseType(typeof(Tafeles))]
        public IHttpActionResult PostTafeles(Tafeles tafeles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tafeles.Add(tafeles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TafelesExists(tafeles.Tafeles_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tafeles.Tafeles_ID }, tafeles);
        }

        // DELETE: api/Tafeles/5
        [ResponseType(typeof(Tafeles))]
        public IHttpActionResult DeleteTafeles(int id)
        {
            Tafeles tafeles = db.Tafeles.Find(id);
            if (tafeles == null)
            {
                return NotFound();
            }

            db.Tafeles.Remove(tafeles);
            db.SaveChanges();

            return Ok(tafeles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TafelesExists(int id)
        {
            return db.Tafeles.Count(e => e.Tafeles_ID == id) > 0;
        }
    }
}