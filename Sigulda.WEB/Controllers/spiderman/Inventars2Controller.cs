using Sigulda.WEB.Contexts.spiderman;
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

namespace Sigulda.WEB.Controllers.spiderman
{
    public class Inventars2Controller : ApiController
    {
        private SpidermanModel db = new SpidermanModel();

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

            if (id != inventars.Galdi_ID)
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
                if (InventarsExists(inventars.Galdi_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("SpidermanApi-Inventars", new { id = inventars.Galdi_ID }, inventars);
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
            return db.Inventars.Count(e => e.Galdi_ID == id) > 0;
        }
    }
}