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
    public class AtbildigaisController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/Atbildigais
        public IQueryable<Atbildigais> GetAtbildigais()
        {
            return db.Atbildigais;
        }

        // GET: api/Atbildigais/5
        [ResponseType(typeof(Atbildigais))]
        public IHttpActionResult GetAtbildigais(int id)
        {
            Atbildigais atbildigais = db.Atbildigais.Find(id);
            if (atbildigais == null)
            {
                return NotFound();
            }

            return Ok(atbildigais);
        }

        // PUT: api/Atbildigais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtbildigais(int id, Atbildigais atbildigais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atbildigais.AtbildigaisID)
            {
                return BadRequest();
            }

            db.Entry(atbildigais).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtbildigaisExists(id))
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

        // POST: api/Atbildigais
        [ResponseType(typeof(Atbildigais))]
        public IHttpActionResult PostAtbildigais(Atbildigais atbildigais)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atbildigais.Add(atbildigais);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AtbildigaisExists(atbildigais.AtbildigaisID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = atbildigais.AtbildigaisID }, atbildigais);
        }

        // DELETE: api/Atbildigais/5
        [ResponseType(typeof(Atbildigais))]
        public IHttpActionResult DeleteAtbildigais(int id)
        {
            Atbildigais atbildigais = db.Atbildigais.Find(id);
            if (atbildigais == null)
            {
                return NotFound();
            }

            db.Atbildigais.Remove(atbildigais);
            db.SaveChanges();

            return Ok(atbildigais);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtbildigaisExists(int id)
        {
            return db.Atbildigais.Count(e => e.AtbildigaisID == id) > 0;
        }
    }
}