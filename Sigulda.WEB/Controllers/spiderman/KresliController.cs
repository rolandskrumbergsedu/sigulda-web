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
    public class KresliController : ApiController
    {
        private SpidermanModel db = new SpidermanModel();

        // GET: api/Kresli
        public IQueryable<Kresli> GetKresli()
        {
            return db.Kresli;
        }

        // GET: api/Kresli/5
        [ResponseType(typeof(Kresli))]
        public IHttpActionResult GetKresli(int id)
        {
            Kresli kresli = db.Kresli.Find(id);
            if (kresli == null)
            {
                return NotFound();
            }

            return Ok(kresli);
        }

        // PUT: api/Kresli/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKresli(int id, Kresli kresli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kresli.Kresli_ID)
            {
                return BadRequest();
            }

            db.Entry(kresli).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KresliExists(id))
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

        // POST: api/Kresli
        [ResponseType(typeof(Kresli))]
        public IHttpActionResult PostKresli(Kresli kresli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kresli.Add(kresli);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KresliExists(kresli.Kresli_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("SpidermanApi-Kresli", new { id = kresli.Kresli_ID }, kresli);
        }

        // DELETE: api/Kresli/5
        [ResponseType(typeof(Kresli))]
        public IHttpActionResult DeleteKresli(int id)
        {
            Kresli kresli = db.Kresli.Find(id);
            if (kresli == null)
            {
                return NotFound();
            }

            db.Kresli.Remove(kresli);
            db.SaveChanges();

            return Ok(kresli);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KresliExists(int id)
        {
            return db.Kresli.Count(e => e.Kresli_ID == id) > 0;
        }
    }
}