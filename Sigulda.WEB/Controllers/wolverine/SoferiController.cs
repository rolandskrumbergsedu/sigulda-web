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
    public class SoferiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Soferi
        public IQueryable<Soferi> GetSoferis()
        {
            return db.Soferis;
        }

        // GET: api/Soferi/5
        [ResponseType(typeof(Soferi))]
        public IHttpActionResult GetSoferi(int id)
        {
            Soferi soferi = db.Soferis.Find(id);
            if (soferi == null)
            {
                return NotFound();
            }

            return Ok(soferi);
        }

        // PUT: api/Soferi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSoferi(int id, Soferi soferi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soferi.SoferaID)
            {
                return BadRequest();
            }

            db.Entry(soferi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoferiExists(id))
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

        // POST: api/Soferi
        [ResponseType(typeof(Soferi))]
        public IHttpActionResult PostSoferi(Soferi soferi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Soferis.Add(soferi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SoferiExists(soferi.SoferaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-SoferiController", new { id = soferi.SoferaID }, soferi);
        }

        // DELETE: api/Soferi/5
        [ResponseType(typeof(Soferi))]
        public IHttpActionResult DeleteSoferi(int id)
        {
            Soferi soferi = db.Soferis.Find(id);
            if (soferi == null)
            {
                return NotFound();
            }

            db.Soferis.Remove(soferi);
            db.SaveChanges();

            return Ok(soferi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SoferiExists(int id)
        {
            return db.Soferis.Count(e => e.SoferaID == id) > 0;
        }
    }
}