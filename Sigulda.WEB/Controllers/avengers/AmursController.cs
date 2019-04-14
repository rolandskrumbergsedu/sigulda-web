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
    public class AmursController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Amurs
        public IQueryable<Amurs> GetAmurs()
        {
            return db.Amurs;
        }

        // GET: api/Amurs/5
        [ResponseType(typeof(Amurs))]
        public IHttpActionResult GetAmur(int id)
        {
            Amurs amur = db.Amurs.Find(id);
            if (amur == null)
            {
                return NotFound();
            }

            return Ok(amur);
        }

        // PUT: api/Amurs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAmur(int id, Amurs amur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amur.Amura_ID)
            {
                return BadRequest();
            }

            db.Entry(amur).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmurExists(id))
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

        // POST: api/Amurs
        [ResponseType(typeof(Amurs))]
        public IHttpActionResult PostAmur(Amurs amur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Amurs.Add(amur);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AmurExists(amur.Amura_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = amur.Amura_ID }, amur);
        }

        // DELETE: api/Amurs/5
        [ResponseType(typeof(Amurs))]
        public IHttpActionResult DeleteAmur(int id)
        {
            Amurs amur = db.Amurs.Find(id);
            if (amur == null)
            {
                return NotFound();
            }

            db.Amurs.Remove(amur);
            db.SaveChanges();

            return Ok(amur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AmurExists(int id)
        {
            return db.Amurs.Count(e => e.Amura_ID == id) > 0;
        }
    }
}