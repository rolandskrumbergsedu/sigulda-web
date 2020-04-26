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
    public class MacibuMaterialiController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/MacibuMateriali
        public IQueryable<Macibu_Materiali> GetMacibu_Materialis()
        {
            return db.Macibu_Materialis;
        }

        // GET: api/MacibuMateriali/5
        [ResponseType(typeof(Macibu_Materiali))]
        public IHttpActionResult GetMacibu_Materiali(int id)
        {
            Macibu_Materiali macibu_Materiali = db.Macibu_Materialis.Find(id);
            if (macibu_Materiali == null)
            {
                return NotFound();
            }

            return Ok(macibu_Materiali);
        }

        // PUT: api/MacibuMateriali/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMacibu_Materiali(int id, Macibu_Materiali macibu_Materiali)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != macibu_Materiali.MacibuMatID)
            {
                return BadRequest();
            }

            db.Entry(macibu_Materiali).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Macibu_MaterialiExists(id))
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

        // POST: api/MacibuMateriali
        [ResponseType(typeof(Macibu_Materiali))]
        public IHttpActionResult PostMacibu_Materiali(Macibu_Materiali macibu_Materiali)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Macibu_Materialis.Add(macibu_Materiali);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Macibu_MaterialiExists(macibu_Materiali.MacibuMatID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("AvengersApi-MacibuMateriali", new { id = macibu_Materiali.MacibuMatID }, macibu_Materiali);
        }

        // DELETE: api/MacibuMateriali/5
        [ResponseType(typeof(Macibu_Materiali))]
        public IHttpActionResult DeleteMacibu_Materiali(int id)
        {
            Macibu_Materiali macibu_Materiali = db.Macibu_Materialis.Find(id);
            if (macibu_Materiali == null)
            {
                return NotFound();
            }

            db.Macibu_Materialis.Remove(macibu_Materiali);
            db.SaveChanges();

            return Ok(macibu_Materiali);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Macibu_MaterialiExists(int id)
        {
            return db.Macibu_Materialis.Count(e => e.MacibuMatID == id) > 0;
        }
    }
}