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

namespace Sigulda.WEB.Controllers.wolverine
{
    public class AtbildigieController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Atbildigie
        public IQueryable<Atbildigie> GetAtbildigie()
        {
            return db.Atbildigie;
        }

        // GET: api/Atbildigie/5
        [ResponseType(typeof(Atbildigie))]
        public IHttpActionResult GetAtbildigie(string id)
        {
            Atbildigie atbildigie = db.Atbildigie.Find(id);
            if (atbildigie == null)
            {
                return NotFound();
            }

            return Ok(atbildigie);
        }

        // PUT: api/Atbildigie/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtbildigie(string id, Atbildigie atbildigie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atbildigie.Vards)
            {
                return BadRequest();
            }

            db.Entry(atbildigie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtbildigieExists(id))
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

        // POST: api/Atbildigie
        [ResponseType(typeof(Atbildigie))]
        public IHttpActionResult PostAtbildigie(Atbildigie atbildigie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atbildigie.Add(atbildigie);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AtbildigieExists(atbildigie.Vards))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = atbildigie.Vards }, atbildigie);
        }

        // DELETE: api/Atbildigie/5
        [ResponseType(typeof(Atbildigie))]
        public IHttpActionResult DeleteAtbildigie(string id)
        {
            Atbildigie atbildigie = db.Atbildigie.Find(id);
            if (atbildigie == null)
            {
                return NotFound();
            }

            db.Atbildigie.Remove(atbildigie);
            db.SaveChanges();

            return Ok(atbildigie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtbildigieExists(string id)
        {
            return db.Atbildigie.Count(e => e.Vards == id) > 0;
        }
    }
}