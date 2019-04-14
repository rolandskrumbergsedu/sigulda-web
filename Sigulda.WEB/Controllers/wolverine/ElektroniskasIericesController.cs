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
    public class ElektroniskasIericesController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/ElektroniskasIerices
        public IQueryable<ElektroniskasIerices> GetElektroniskas_ierices()
        {
            return db.Elektroniskas_ierices;
        }

        // GET: api/ElektroniskasIerices/5
        [ResponseType(typeof(ElektroniskasIerices))]
        public IHttpActionResult GetElektroniskasIerices(string id)
        {
            ElektroniskasIerices elektroniskasIerices = db.Elektroniskas_ierices.Find(id);
            if (elektroniskasIerices == null)
            {
                return NotFound();
            }

            return Ok(elektroniskasIerices);
        }

        // PUT: api/ElektroniskasIerices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElektroniskasIerices(string id, ElektroniskasIerices elektroniskasIerices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elektroniskasIerices.vertiba)
            {
                return BadRequest();
            }

            db.Entry(elektroniskasIerices).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElektroniskasIericesExists(id))
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

        // POST: api/ElektroniskasIerices
        [ResponseType(typeof(ElektroniskasIerices))]
        public IHttpActionResult PostElektroniskasIerices(ElektroniskasIerices elektroniskasIerices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elektroniskas_ierices.Add(elektroniskasIerices);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ElektroniskasIericesExists(elektroniskasIerices.vertiba))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elektroniskasIerices.vertiba }, elektroniskasIerices);
        }

        // DELETE: api/ElektroniskasIerices/5
        [ResponseType(typeof(ElektroniskasIerices))]
        public IHttpActionResult DeleteElektroniskasIerices(string id)
        {
            ElektroniskasIerices elektroniskasIerices = db.Elektroniskas_ierices.Find(id);
            if (elektroniskasIerices == null)
            {
                return NotFound();
            }

            db.Elektroniskas_ierices.Remove(elektroniskasIerices);
            db.SaveChanges();

            return Ok(elektroniskasIerices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElektroniskasIericesExists(string id)
        {
            return db.Elektroniskas_ierices.Count(e => e.vertiba == id) > 0;
        }
    }
}