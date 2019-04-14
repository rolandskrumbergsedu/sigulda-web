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
    public class MebelesController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Mebeles
        public IQueryable<Mebeles> GetMebeles()
        {
            return db.Mebeles;
        }

        // GET: api/Mebeles/5
        [ResponseType(typeof(Mebeles))]
        public IHttpActionResult GetMebeles(string id)
        {
            Mebeles mebeles = db.Mebeles.Find(id);
            if (mebeles == null)
            {
                return NotFound();
            }

            return Ok(mebeles);
        }

        // PUT: api/Mebeles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMebeles(string id, Mebeles mebeles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mebeles.MebelesID)
            {
                return BadRequest();
            }

            db.Entry(mebeles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MebelesExists(id))
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

        // POST: api/Mebeles
        [ResponseType(typeof(Mebeles))]
        public IHttpActionResult PostMebeles(Mebeles mebeles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mebeles.Add(mebeles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MebelesExists(mebeles.MebelesID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mebeles.MebelesID }, mebeles);
        }

        // DELETE: api/Mebeles/5
        [ResponseType(typeof(Mebeles))]
        public IHttpActionResult DeleteMebeles(string id)
        {
            Mebeles mebeles = db.Mebeles.Find(id);
            if (mebeles == null)
            {
                return NotFound();
            }

            db.Mebeles.Remove(mebeles);
            db.SaveChanges();

            return Ok(mebeles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MebelesExists(string id)
        {
            return db.Mebeles.Count(e => e.MebelesID == id) > 0;
        }
    }
}