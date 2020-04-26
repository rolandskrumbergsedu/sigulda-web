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
    public class StundasTemasController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/StundasTemas
        public IQueryable<StundasTema> GetStundasTemas()
        {
            return db.StundasTemas;
        }

        // GET: api/StundasTemas/5
        [ResponseType(typeof(StundasTema))]
        public IHttpActionResult GetStundasTema(int id)
        {
            StundasTema stundasTema = db.StundasTemas.Find(id);
            if (stundasTema == null)
            {
                return NotFound();
            }

            return Ok(stundasTema);
        }

        // PUT: api/StundasTemas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStundasTema(int id, StundasTema stundasTema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stundasTema.Tema_ID)
            {
                return BadRequest();
            }

            db.Entry(stundasTema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StundasTemaExists(id))
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

        // POST: api/StundasTemas
        [ResponseType(typeof(StundasTema))]
        public IHttpActionResult PostStundasTema(StundasTema stundasTema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StundasTemas.Add(stundasTema);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StundasTemaExists(stundasTema.Tema_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("CaptainAmericaApi-StundasTemasController", new { id = stundasTema.Tema_ID }, stundasTema);
        }

        // DELETE: api/StundasTemas/5
        [ResponseType(typeof(StundasTema))]
        public IHttpActionResult DeleteStundasTema(int id)
        {
            StundasTema stundasTema = db.StundasTemas.Find(id);
            if (stundasTema == null)
            {
                return NotFound();
            }

            db.StundasTemas.Remove(stundasTema);
            db.SaveChanges();

            return Ok(stundasTema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StundasTemaExists(int id)
        {
            return db.StundasTemas.Count(e => e.Tema_ID == id) > 0;
        }
    }
}