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
    public class LietotajiController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/Lietotaji
        public IQueryable<Lietotaji1> GetLietotaji1()
        {
            return db.Lietotaji1;
        }

        // GET: api/Lietotaji/5
        [ResponseType(typeof(Lietotaji1))]
        public IHttpActionResult GetLietotaji1(int id)
        {
            Lietotaji1 lietotaji1 = db.Lietotaji1.Find(id);
            if (lietotaji1 == null)
            {
                return NotFound();
            }

            return Ok(lietotaji1);
        }

        // PUT: api/Lietotaji/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLietotaji1(int id, Lietotaji1 lietotaji1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lietotaji1.lietotajs_id)
            {
                return BadRequest();
            }

            db.Entry(lietotaji1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lietotaji1Exists(id))
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

        // POST: api/Lietotaji
        [ResponseType(typeof(Lietotaji1))]
        public IHttpActionResult PostLietotaji1(Lietotaji1 lietotaji1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lietotaji1.Add(lietotaji1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Lietotaji1Exists(lietotaji1.lietotajs_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-LietotajiController", new { id = lietotaji1.lietotajs_id }, lietotaji1);
        }

        // DELETE: api/Lietotaji/5
        [ResponseType(typeof(Lietotaji1))]
        public IHttpActionResult DeleteLietotaji1(int id)
        {
            Lietotaji1 lietotaji1 = db.Lietotaji1.Find(id);
            if (lietotaji1 == null)
            {
                return NotFound();
            }

            db.Lietotaji1.Remove(lietotaji1);
            db.SaveChanges();

            return Ok(lietotaji1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lietotaji1Exists(int id)
        {
            return db.Lietotaji1.Count(e => e.lietotajs_id == id) > 0;
        }
    }
}