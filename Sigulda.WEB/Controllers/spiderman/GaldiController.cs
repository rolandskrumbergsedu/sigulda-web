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
    public class GaldiController : ApiController
    {
        private SpidermanModel db = new SpidermanModel();

        // GET: api/Galdi
        public IQueryable<Galdi> GetGaldi()
        {
            return db.Galdi;
        }

        // GET: api/Galdi/5
        [ResponseType(typeof(Galdi))]
        public IHttpActionResult GetGaldi(int id)
        {
            Galdi galdi = db.Galdi.Find(id);
            if (galdi == null)
            {
                return NotFound();
            }

            return Ok(galdi);
        }

        // PUT: api/Galdi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGaldi(int id, Galdi galdi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != galdi.Galdi_ID)
            {
                return BadRequest();
            }

            db.Entry(galdi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GaldiExists(id))
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

        // POST: api/Galdi
        [ResponseType(typeof(Galdi))]
        public IHttpActionResult PostGaldi(Galdi galdi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Galdi.Add(galdi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GaldiExists(galdi.Galdi_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("SpidermanApi-Galdi", new { id = galdi.Galdi_ID }, galdi);
        }

        // DELETE: api/Galdi/5
        [ResponseType(typeof(Galdi))]
        public IHttpActionResult DeleteGaldi(int id)
        {
            Galdi galdi = db.Galdi.Find(id);
            if (galdi == null)
            {
                return NotFound();
            }

            db.Galdi.Remove(galdi);
            db.SaveChanges();

            return Ok(galdi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GaldiExists(int id)
        {
            return db.Galdi.Count(e => e.Galdi_ID == id) > 0;
        }
    }
}