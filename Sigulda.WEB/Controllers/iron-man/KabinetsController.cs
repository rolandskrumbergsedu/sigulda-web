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
using Sigulda.WEB.Contexts.iron_man;

namespace Sigulda.WEB.Controllers.iron_man
{
    public class KabinetsController : ApiController
    {
        private IronMan db = new IronMan();

        // GET: api/Kabinets
        public IQueryable<Kabinet> GetKabinets()
        {
            return db.Kabinets;
        }

        // GET: api/Kabinets/5
        [ResponseType(typeof(Kabinet))]
        public IHttpActionResult GetKabinet(int id)
        {
            Kabinet kabinet = db.Kabinets.Find(id);
            if (kabinet == null)
            {
                return NotFound();
            }

            return Ok(kabinet);
        }

        // PUT: api/Kabinets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabinet(int id, Kabinet kabinet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabinet.Kabineta_ID)
            {
                return BadRequest();
            }

            db.Entry(kabinet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KabinetExists(id))
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
        [ResponseType(typeof(Kabinet))]
        public IHttpActionResult PostKabinet(Kabinet kabinet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kabinets.Add(kabinet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KabinetExists(kabinet.Kabineta_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("IronManApi-KabinetsController", new { id = kabinet.Kabineta_ID }, kabinet);
        }

        // DELETE: api/Kabinets/5
        [ResponseType(typeof(Kabinet))]
        public IHttpActionResult DeleteKabinet(int id)
        {
            Kabinet kabinet = db.Kabinets.Find(id);
            if (kabinet == null)
            {
                return NotFound();
            }

            db.Kabinets.Remove(kabinet);
            db.SaveChanges();

            return Ok(kabinet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KabinetExists(int id)
        {
            return db.Kabinets.Count(e => e.Kabineta_ID == id) > 0;
        }
    }
}