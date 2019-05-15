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
    public class Kabinets2Controller : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Kabinets
        public IQueryable<Kabineti> GetKabinets()
        {
            return db.Kabinets;
        }

        // GET: api/Kabinets/5
        [ResponseType(typeof(Kabineti))]
        public IHttpActionResult GetKabinets(string id)
        {
            Kabineti kabinets = db.Kabinets.Find(id);
            if (kabinets == null)
            {
                return NotFound();
            }

            return Ok(kabinets);
        }

        // PUT: api/Kabinets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabinets(string id, Kabineti kabinets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabinets.Elektronika)
            {
                return BadRequest();
            }

            db.Entry(kabinets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KabinetsExists(id))
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

        // POST: api/Kabinets
        [ResponseType(typeof(Kabineti))]
        public IHttpActionResult PostKabinets(Kabineti kabinets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kabinets.Add(kabinets);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KabinetsExists(kabinets.Elektronika))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-Kabinets", new { id = kabinets.Elektronika }, kabinets);
        }

        // DELETE: api/Kabinets/5
        [ResponseType(typeof(Kabineti))]
        public IHttpActionResult DeleteKabinets(string id)
        {
            Kabineti kabinets = db.Kabinets.Find(id);
            if (kabinets == null)
            {
                return NotFound();
            }

            db.Kabinets.Remove(kabinets);
            db.SaveChanges();

            return Ok(kabinets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KabinetsExists(string id)
        {
            return db.Kabinets.Count(e => e.Elektronika == id) > 0;
        }
    }
}