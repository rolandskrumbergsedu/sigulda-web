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
    public class FilimentsController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Filiments
        public IQueryable<Filiments> GetFiliments()
        {
            return db.Filiments;
        }

        // GET: api/Filiments/5
        [ResponseType(typeof(Filiments))]
        public IHttpActionResult GetFiliments(int id)
        {
            Filiments filiments = db.Filiments.Find(id);
            if (filiments == null)
            {
                return NotFound();
            }

            return Ok(filiments);
        }

        // PUT: api/Filiments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFiliments(int id, Filiments filiments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filiments.filimenta_ID)
            {
                return BadRequest();
            }

            db.Entry(filiments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilimentsExists(id))
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

        // POST: api/Filiments
        [ResponseType(typeof(Filiments))]
        public IHttpActionResult PostFiliments(Filiments filiments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filiments.Add(filiments);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FilimentsExists(filiments.filimenta_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("AvengersApi-Filiments", new { id = filiments.filimenta_ID }, filiments);
        }

        // DELETE: api/Filiments/5
        [ResponseType(typeof(Filiments))]
        public IHttpActionResult DeleteFiliments(int id)
        {
            Filiments filiments = db.Filiments.Find(id);
            if (filiments == null)
            {
                return NotFound();
            }

            db.Filiments.Remove(filiments);
            db.SaveChanges();

            return Ok(filiments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilimentsExists(int id)
        {
            return db.Filiments.Count(e => e.filimenta_ID == id) > 0;
        }
    }
}