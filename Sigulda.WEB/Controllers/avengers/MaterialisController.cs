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
    public class MaterialisController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Materialis
        public IQueryable<Materiali> GetMaterials()
        {
            return db.Materials;
        }

        // GET: api/Materialis/5
        [ResponseType(typeof(Materiali))]
        public IHttpActionResult GetMateriali(int id)
        {
            Materiali materiali = db.Materials.Find(id);
            if (materiali == null)
            {
                return NotFound();
            }

            return Ok(materiali);
        }

        // PUT: api/Materialis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMateriali(int id, Materiali materiali)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materiali.Materiala_ID)
            {
                return BadRequest();
            }

            db.Entry(materiali).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialiExists(id))
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

        // POST: api/Materialis
        [ResponseType(typeof(Materiali))]
        public IHttpActionResult PostMateriali(Materiali materiali)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materials.Add(materiali);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MaterialiExists(materiali.Materiala_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = materiali.Materiala_ID }, materiali);
        }

        // DELETE: api/Materialis/5
        [ResponseType(typeof(Materiali))]
        public IHttpActionResult DeleteMateriali(int id)
        {
            Materiali materiali = db.Materials.Find(id);
            if (materiali == null)
            {
                return NotFound();
            }

            db.Materials.Remove(materiali);
            db.SaveChanges();

            return Ok(materiali);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialiExists(int id)
        {
            return db.Materials.Count(e => e.Materiala_ID == id) > 0;
        }
    }
}