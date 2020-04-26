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
using Sigulda.WEB.Contexts.iron_man;

namespace Sigulda.WEB.Controllers.iron_man
{
    public class AtbildīgaisController : ApiController
    {
        private IronMan db = new IronMan();

        // GET: api/Atbildīgais
        public IQueryable<Atbildīgais> GetAtbildīgais()
        {
            return db.Atbildīgais;
        }

        // GET: api/Atbildīgais/5
        [ResponseType(typeof(Atbildīgais))]
        public IHttpActionResult GetAtbildīgais(int id)
        {
            Atbildīgais atbildīgais = db.Atbildīgais.Find(id);
            if (atbildīgais == null)
            {
                return NotFound();
            }

            return Ok(atbildīgais);
        }

        // PUT: api/Atbildīgais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtbildīgais(int id, Atbildīgais atbildīgais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atbildīgais.Atbildīgā_ID)
            {
                return BadRequest();
            }

            db.Entry(atbildīgais).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtbildīgaisExists(id))
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

        // POST: api/Atbildīgais
        [ResponseType(typeof(Atbildīgais))]
        public IHttpActionResult PostAtbildīgais(Atbildīgais atbildīgais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atbildīgais.Add(atbildīgais);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AtbildīgaisExists(atbildīgais.Atbildīgā_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("IronManApi-AtbildīgaisController", new { id = atbildīgais.Atbildīgā_ID }, atbildīgais);
        }

        // DELETE: api/Atbildīgais/5
        [ResponseType(typeof(Atbildīgais))]
        public IHttpActionResult DeleteAtbildīgais(int id)
        {
            Atbildīgais atbildīgais = db.Atbildīgais.Find(id);
            if (atbildīgais == null)
            {
                return NotFound();
            }

            db.Atbildīgais.Remove(atbildīgais);
            db.SaveChanges();

            return Ok(atbildīgais);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtbildīgaisExists(int id)
        {
            return db.Atbildīgais.Count(e => e.Atbildīgā_ID == id) > 0;
        }
    }
}