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
    public class PiederumiController : ApiController
    {
        private IronManModel db = new IronManModel();

        // GET: api/Piederumi
        public IQueryable<Piederumi> GetPiederumis()
        {
            return db.Piederumis;
        }

        // GET: api/Piederumi/5
        [ResponseType(typeof(Piederumi))]
        public IHttpActionResult GetPiederumi(int id)
        {
            Piederumi piederumi = db.Piederumis.Find(id);
            if (piederumi == null)
            {
                return NotFound();
            }

            return Ok(piederumi);
        }

        // PUT: api/Piederumi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPiederumi(int id, Piederumi piederumi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piederumi.Piederumi_ID)
            {
                return BadRequest();
            }

            db.Entry(piederumi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiederumiExists(id))
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

        // POST: api/Piederumi
        [ResponseType(typeof(Piederumi))]
        public IHttpActionResult PostPiederumi(Piederumi piederumi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Piederumis.Add(piederumi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PiederumiExists(piederumi.Piederumi_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("IronManApi-Piederumi", new { id = piederumi.Piederumi_ID }, piederumi);
        }

        // DELETE: api/Piederumi/5
        [ResponseType(typeof(Piederumi))]
        public IHttpActionResult DeletePiederumi(int id)
        {
            Piederumi piederumi = db.Piederumis.Find(id);
            if (piederumi == null)
            {
                return NotFound();
            }

            db.Piederumis.Remove(piederumi);
            db.SaveChanges();

            return Ok(piederumi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PiederumiExists(int id)
        {
            return db.Piederumis.Count(e => e.Piederumi_ID == id) > 0;
        }
    }
}