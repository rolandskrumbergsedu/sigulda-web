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
    public class TraukiController : ApiController
    {
        private IronManModel db = new IronManModel();

        // GET: api/Trauki
        public IQueryable<Trauki> GetTraukis()
        {
            return db.Traukis;
        }

        // GET: api/Trauki/5
        [ResponseType(typeof(Trauki))]
        public IHttpActionResult GetTrauki(int id)
        {
            Trauki trauki = db.Traukis.Find(id);
            if (trauki == null)
            {
                return NotFound();
            }

            return Ok(trauki);
        }

        // PUT: api/Trauki/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrauki(int id, Trauki trauki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trauki.Trauki_ID)
            {
                return BadRequest();
            }

            db.Entry(trauki).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraukiExists(id))
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

        // POST: api/Trauki
        [ResponseType(typeof(Trauki))]
        public IHttpActionResult PostTrauki(Trauki trauki)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Traukis.Add(trauki);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TraukiExists(trauki.Trauki_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trauki.Trauki_ID }, trauki);
        }

        // DELETE: api/Trauki/5
        [ResponseType(typeof(Trauki))]
        public IHttpActionResult DeleteTrauki(int id)
        {
            Trauki trauki = db.Traukis.Find(id);
            if (trauki == null)
            {
                return NotFound();
            }

            db.Traukis.Remove(trauki);
            db.SaveChanges();

            return Ok(trauki);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TraukiExists(int id)
        {
            return db.Traukis.Count(e => e.Trauki_ID == id) > 0;
        }
    }
}