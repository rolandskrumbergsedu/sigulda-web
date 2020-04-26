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
using Sigulda.WEB.Contexts.captain_america;

namespace Sigulda.WEB.Controllers.captain_america
{
    public class MacibuStundaController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/MacibuStunda
        public IQueryable<Macibu_stunda> GetMacibu_stunda()
        {
            return db.Macibu_stunda;
        }

        // GET: api/MacibuStunda/5
        [ResponseType(typeof(Macibu_stunda))]
        public IHttpActionResult GetMacibu_stunda(int id)
        {
            Macibu_stunda macibu_stunda = db.Macibu_stunda.Find(id);
            if (macibu_stunda == null)
            {
                return NotFound();
            }

            return Ok(macibu_stunda);
        }

        // PUT: api/MacibuStunda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMacibu_stunda(int id, Macibu_stunda macibu_stunda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != macibu_stunda.Stunda_ID)
            {
                return BadRequest();
            }

            db.Entry(macibu_stunda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Macibu_stundaExists(id))
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

        // POST: api/MacibuStunda
        [ResponseType(typeof(Macibu_stunda))]
        public IHttpActionResult PostMacibu_stunda(Macibu_stunda macibu_stunda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Macibu_stunda.Add(macibu_stunda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Macibu_stundaExists(macibu_stunda.Stunda_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("CaptainAmericaApi-MacibuStundaController", new { id = macibu_stunda.Stunda_ID }, macibu_stunda);
        }

        // DELETE: api/MacibuStunda/5
        [ResponseType(typeof(Macibu_stunda))]
        public IHttpActionResult DeleteMacibu_stunda(int id)
        {
            Macibu_stunda macibu_stunda = db.Macibu_stunda.Find(id);
            if (macibu_stunda == null)
            {
                return NotFound();
            }

            db.Macibu_stunda.Remove(macibu_stunda);
            db.SaveChanges();

            return Ok(macibu_stunda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Macibu_stundaExists(int id)
        {
            return db.Macibu_stunda.Count(e => e.Stunda_ID == id) > 0;
        }
    }
}