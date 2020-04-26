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
    public class PasutijumiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Pasutijumi
        public IQueryable<Pasutijumi> GetPasutijumis()
        {
            return db.Pasutijumis;
        }

        // GET: api/Pasutijumi/5
        [ResponseType(typeof(Pasutijumi))]
        public IHttpActionResult GetPasutijumi(int id)
        {
            Pasutijumi pasutijumi = db.Pasutijumis.Find(id);
            if (pasutijumi == null)
            {
                return NotFound();
            }

            return Ok(pasutijumi);
        }

        // PUT: api/Pasutijumi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasutijumi(int id, Pasutijumi pasutijumi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasutijumi.Pas_ID)
            {
                return BadRequest();
            }

            db.Entry(pasutijumi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasutijumiExists(id))
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

        // POST: api/Pasutijumi
        [ResponseType(typeof(Pasutijumi))]
        public IHttpActionResult PostPasutijumi(Pasutijumi pasutijumi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pasutijumis.Add(pasutijumi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PasutijumiExists(pasutijumi.Pas_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-PasutijumiController", new { id = pasutijumi.Pas_ID }, pasutijumi);
        }

        // DELETE: api/Pasutijumi/5
        [ResponseType(typeof(Pasutijumi))]
        public IHttpActionResult DeletePasutijumi(int id)
        {
            Pasutijumi pasutijumi = db.Pasutijumis.Find(id);
            if (pasutijumi == null)
            {
                return NotFound();
            }

            db.Pasutijumis.Remove(pasutijumi);
            db.SaveChanges();

            return Ok(pasutijumi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasutijumiExists(int id)
        {
            return db.Pasutijumis.Count(e => e.Pas_ID == id) > 0;
        }
    }
}