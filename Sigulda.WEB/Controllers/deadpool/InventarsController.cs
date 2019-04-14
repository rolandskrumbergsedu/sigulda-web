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
    public class InventarsController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/Inventars
        public IQueryable<Inventars> GetInventars()
        {
            return db.Inventars;
        }

        // GET: api/Inventars/5
        [ResponseType(typeof(Inventars))]
        public IHttpActionResult GetInventars(int id)
        {
            Inventars inventars = db.Inventars.Find(id);
            if (inventars == null)
            {
                return NotFound();
            }

            return Ok(inventars);
        }

        // PUT: api/Inventars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventars(int id, Inventars inventars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventars.InventaraID)
            {
                return BadRequest();
            }

            db.Entry(inventars).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarsExists(id))
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

        // POST: api/Inventars
        [ResponseType(typeof(Inventars))]
        public IHttpActionResult PostInventars(Inventars inventars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventars.Add(inventars);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InventarsExists(inventars.InventaraID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventars.InventaraID }, inventars);
        }

        // DELETE: api/Inventars/5
        [ResponseType(typeof(Inventars))]
        public IHttpActionResult DeleteInventars(int id)
        {
            Inventars inventars = db.Inventars.Find(id);
            if (inventars == null)
            {
                return NotFound();
            }

            db.Inventars.Remove(inventars);
            db.SaveChanges();

            return Ok(inventars);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventarsExists(int id)
        {
            return db.Inventars.Count(e => e.InventaraID == id) > 0;
        }
    }
}