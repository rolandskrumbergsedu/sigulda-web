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
    public class ElektroniskasIericesController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/ElektroniskasIerices
        public IQueryable<ElektroniskasIerices> GetElektroniskasIerices()
        {
            return db.ElektroniskasIerices;
        }

        // GET: api/ElektroniskasIerices/5
        [ResponseType(typeof(ElektroniskasIerices))]
        public IHttpActionResult GetElektroniskasIerices(int id)
        {
            ElektroniskasIerices elektroniskasIerices = db.ElektroniskasIerices.Find(id);
            if (elektroniskasIerices == null)
            {
                return NotFound();
            }

            return Ok(elektroniskasIerices);
        }

        // PUT: api/ElektroniskasIerices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElektroniskasIerices(int id, ElektroniskasIerices elektroniskasIerices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elektroniskasIerices.IericesID)
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

            db.ElektroniskasIerices.Add(elektroniskasIerices);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ElektroniskasIericesExists(elektroniskasIerices.IericesID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = elektroniskasIerices.IericesID }, elektroniskasIerices);
        }

        // DELETE: api/ElektroniskasIerices/5
        [ResponseType(typeof(ElektroniskasIerices))]
        public IHttpActionResult DeleteElektroniskasIerices(int id)
        {
            ElektroniskasIerices elektroniskasIerices = db.ElektroniskasIerices.Find(id);
            if (elektroniskasIerices == null)
            {
                return NotFound();
            }

            db.ElektroniskasIerices.Remove(elektroniskasIerices);
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

        private bool ElektroniskasIericesExists(int id)
        {
            return db.ElektroniskasIerices.Count(e => e.IericesID == id) > 0;
        }
    }
}