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
using Sigulda.WEB.Contexts.batman;

namespace Sigulda.WEB.Controllers.batman
{
    public class BaterijasController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/Baterijas
        public IQueryable<Baterija> GetBaterijas()
        {
            return db.Baterijas;
        }

        // GET: api/Baterijas/5
        [ResponseType(typeof(Baterija))]
        public IHttpActionResult GetBaterija(int id)
        {
            Baterija baterija = db.Baterijas.Find(id);
            if (baterija == null)
            {
                return NotFound();
            }

            return Ok(baterija);
        }

        // PUT: api/Baterijas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaterija(int id, Baterija baterija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baterija.Baterijas_ID)
            {
                return BadRequest();
            }

            db.Entry(baterija).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaterijaExists(id))
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

        // POST: api/Baterijas
        [ResponseType(typeof(Baterija))]
        public IHttpActionResult PostBaterija(Baterija baterija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Baterijas.Add(baterija);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BaterijaExists(baterija.Baterijas_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = baterija.Baterijas_ID }, baterija);
        }

        // DELETE: api/Baterijas/5
        [ResponseType(typeof(Baterija))]
        public IHttpActionResult DeleteBaterija(int id)
        {
            Baterija baterija = db.Baterijas.Find(id);
            if (baterija == null)
            {
                return NotFound();
            }

            db.Baterijas.Remove(baterija);
            db.SaveChanges();

            return Ok(baterija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaterijaExists(int id)
        {
            return db.Baterijas.Count(e => e.Baterijas_ID == id) > 0;
        }
    }
}