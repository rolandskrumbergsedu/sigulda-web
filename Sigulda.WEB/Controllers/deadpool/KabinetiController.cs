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
    public class KabinetiController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/Kabineti
        public IQueryable<Kabineti1> GetKabineti1()
        {
            return db.Kabineti1;
        }

        // GET: api/Kabineti/5
        [ResponseType(typeof(Kabineti1))]
        public IHttpActionResult GetKabineti1(int id)
        {
            Kabineti1 kabineti1 = db.Kabineti1.Find(id);
            if (kabineti1 == null)
            {
                return NotFound();
            }

            return Ok(kabineti1);
        }

        // PUT: api/Kabineti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabineti1(int id, Kabineti1 kabineti1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabineti1.kabineta_id)
            {
                return BadRequest();
            }

            db.Entry(kabineti1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Kabineti1Exists(id))
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

        // POST: api/Kabineti
        [ResponseType(typeof(Kabineti1))]
        public IHttpActionResult PostKabineti1(Kabineti1 kabineti1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kabineti1.Add(kabineti1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Kabineti1Exists(kabineti1.kabineta_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-KabinetiController", new { id = kabineti1.kabineta_id }, kabineti1);
        }

        // DELETE: api/Kabineti/5
        [ResponseType(typeof(Kabineti1))]
        public IHttpActionResult DeleteKabineti1(int id)
        {
            Kabineti1 kabineti1 = db.Kabineti1.Find(id);
            if (kabineti1 == null)
            {
                return NotFound();
            }

            db.Kabineti1.Remove(kabineti1);
            db.SaveChanges();

            return Ok(kabineti1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Kabineti1Exists(int id)
        {
            return db.Kabineti1.Count(e => e.kabineta_id == id) > 0;
        }
    }
}