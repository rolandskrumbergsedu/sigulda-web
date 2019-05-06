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
using Sigulda.WEB.Contexts.deadpool;

namespace Sigulda.WEB.Controllers.deadpool
{
    public class KabinetsController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/Kabinets
        public IQueryable<Kabinets> GetKabinets()
        {
            return db.Kabinets;
        }

        // GET: api/Kabinets/5
        [ResponseType(typeof(Kabinets))]
        public IHttpActionResult GetKabinets(int id)
        {
            Kabinets kabinets = db.Kabinets.Find(id);
            if (kabinets == null)
            {
                return NotFound();
            }

            return Ok(kabinets);
        }

        // PUT: api/Kabinets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabinets(int id, Kabinets kabinets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabinets.KabinetaID)
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
        [ResponseType(typeof(Kabinets))]
        public IHttpActionResult PostKabinets(Kabinets kabinets)
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
                if (KabinetsExists(kabinets.KabinetaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-Kabinets", new { id = kabinets.KabinetaID }, kabinets);
        }

        // DELETE: api/Kabinets/5
        [ResponseType(typeof(Kabinets))]
        public IHttpActionResult DeleteKabinets(int id)
        {
            Kabinets kabinets = db.Kabinets.Find(id);
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

        private bool KabinetsExists(int id)
        {
            return db.Kabinets.Count(e => e.KabinetaID == id) > 0;
        }
    }
}