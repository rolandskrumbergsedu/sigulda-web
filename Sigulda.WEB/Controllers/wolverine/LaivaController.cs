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
    public class LaivaController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Laiva
        public IQueryable<Laiva> GetLaivas()
        {
            return db.Laivas;
        }

        // GET: api/Laiva/5
        [ResponseType(typeof(Laiva))]
        public IHttpActionResult GetLaiva(int id)
        {
            Laiva laiva = db.Laivas.Find(id);
            if (laiva == null)
            {
                return NotFound();
            }

            return Ok(laiva);
        }

        // PUT: api/Laiva/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaiva(int id, Laiva laiva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laiva.LaivasID)
            {
                return BadRequest();
            }

            db.Entry(laiva).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaivaExists(id))
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

        // POST: api/Laiva
        [ResponseType(typeof(Laiva))]
        public IHttpActionResult PostLaiva(Laiva laiva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Laivas.Add(laiva);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LaivaExists(laiva.LaivasID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-LaivaController", new { id = laiva.LaivasID }, laiva);
        }

        // DELETE: api/Laiva/5
        [ResponseType(typeof(Laiva))]
        public IHttpActionResult DeleteLaiva(int id)
        {
            Laiva laiva = db.Laivas.Find(id);
            if (laiva == null)
            {
                return NotFound();
            }

            db.Laivas.Remove(laiva);
            db.SaveChanges();

            return Ok(laiva);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaivaExists(int id)
        {
            return db.Laivas.Count(e => e.LaivasID == id) > 0;
        }
    }
}