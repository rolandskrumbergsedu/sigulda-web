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
    public class LaivuVeidiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/LaivuVeidi
        public IQueryable<Laivu_veidi> GetLaivu_veidi()
        {
            return db.Laivu_veidi;
        }

        // GET: api/LaivuVeidi/5
        [ResponseType(typeof(Laivu_veidi))]
        public IHttpActionResult GetLaivu_veidi(int id)
        {
            Laivu_veidi laivu_veidi = db.Laivu_veidi.Find(id);
            if (laivu_veidi == null)
            {
                return NotFound();
            }

            return Ok(laivu_veidi);
        }

        // PUT: api/LaivuVeidi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaivu_veidi(int id, Laivu_veidi laivu_veidi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laivu_veidi.LVID)
            {
                return BadRequest();
            }

            db.Entry(laivu_veidi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Laivu_veidiExists(id))
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

        // POST: api/LaivuVeidi
        [ResponseType(typeof(Laivu_veidi))]
        public IHttpActionResult PostLaivu_veidi(Laivu_veidi laivu_veidi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Laivu_veidi.Add(laivu_veidi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Laivu_veidiExists(laivu_veidi.LVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-LaivuVeidiController", new { id = laivu_veidi.LVID }, laivu_veidi);
        }

        // DELETE: api/LaivuVeidi/5
        [ResponseType(typeof(Laivu_veidi))]
        public IHttpActionResult DeleteLaivu_veidi(int id)
        {
            Laivu_veidi laivu_veidi = db.Laivu_veidi.Find(id);
            if (laivu_veidi == null)
            {
                return NotFound();
            }

            db.Laivu_veidi.Remove(laivu_veidi);
            db.SaveChanges();

            return Ok(laivu_veidi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Laivu_veidiExists(int id)
        {
            return db.Laivu_veidi.Count(e => e.LVID == id) > 0;
        }
    }
}