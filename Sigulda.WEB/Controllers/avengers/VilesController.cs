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
    public class VilesController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Viles
        public IQueryable<Viles> GetViles()
        {
            return db.Viles;
        }

        // GET: api/Viles/5
        [ResponseType(typeof(Viles))]
        public IHttpActionResult GetViles(int id)
        {
            Viles viles = db.Viles.Find(id);
            if (viles == null)
            {
                return NotFound();
            }

            return Ok(viles);
        }

        // PUT: api/Viles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViles(int id, Viles viles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viles.Viles_ID)
            {
                return BadRequest();
            }

            db.Entry(viles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VilesExists(id))
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

        // POST: api/Viles
        [ResponseType(typeof(Viles))]
        public IHttpActionResult PostViles(Viles viles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Viles.Add(viles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VilesExists(viles.Viles_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = viles.Viles_ID }, viles);
        }

        // DELETE: api/Viles/5
        [ResponseType(typeof(Viles))]
        public IHttpActionResult DeleteViles(int id)
        {
            Viles viles = db.Viles.Find(id);
            if (viles == null)
            {
                return NotFound();
            }

            db.Viles.Remove(viles);
            db.SaveChanges();

            return Ok(viles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VilesExists(int id)
        {
            return db.Viles.Count(e => e.Viles_ID == id) > 0;
        }
    }
}