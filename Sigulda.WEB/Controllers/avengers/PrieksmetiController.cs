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
using Sigulda.WEB.Contexts.avengers;

namespace Sigulda.WEB.Controllers.avengers
{
    public class PrieksmetiController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Prieksmeti
        public IQueryable<Prieksmeti> GetPrieksmetis()
        {
            return db.Prieksmetis;
        }

        // GET: api/Prieksmeti/5
        [ResponseType(typeof(Prieksmeti))]
        public IHttpActionResult GetPrieksmeti(int id)
        {
            Prieksmeti prieksmeti = db.Prieksmetis.Find(id);
            if (prieksmeti == null)
            {
                return NotFound();
            }

            return Ok(prieksmeti);
        }

        // PUT: api/Prieksmeti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrieksmeti(int id, Prieksmeti prieksmeti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prieksmeti.PrieksmetaID)
            {
                return BadRequest();
            }

            db.Entry(prieksmeti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrieksmetiExists(id))
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

        // POST: api/Prieksmeti
        [ResponseType(typeof(Prieksmeti))]
        public IHttpActionResult PostPrieksmeti(Prieksmeti prieksmeti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prieksmetis.Add(prieksmeti);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PrieksmetiExists(prieksmeti.PrieksmetaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("AvengersApi-Prieksmeti", new { id = prieksmeti.PrieksmetaID }, prieksmeti);
        }

        // DELETE: api/Prieksmeti/5
        [ResponseType(typeof(Prieksmeti))]
        public IHttpActionResult DeletePrieksmeti(int id)
        {
            Prieksmeti prieksmeti = db.Prieksmetis.Find(id);
            if (prieksmeti == null)
            {
                return NotFound();
            }

            db.Prieksmetis.Remove(prieksmeti);
            db.SaveChanges();

            return Ok(prieksmeti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrieksmetiExists(int id)
        {
            return db.Prieksmetis.Count(e => e.PrieksmetaID == id) > 0;
        }
    }
}