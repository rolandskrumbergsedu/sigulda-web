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
using Sigulda.WEB.Contexts.wolverine;

namespace Sigulda.WEB.Controllers.wolverine
{
    public class TransportlidzekliController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Transportlidzekli
        public IQueryable<Transportlidzekli> GetTransportlidzeklis()
        {
            return db.Transportlidzeklis;
        }

        // GET: api/Transportlidzekli/5
        [ResponseType(typeof(Transportlidzekli))]
        public IHttpActionResult GetTransportlidzekli(int id)
        {
            Transportlidzekli transportlidzekli = db.Transportlidzeklis.Find(id);
            if (transportlidzekli == null)
            {
                return NotFound();
            }

            return Ok(transportlidzekli);
        }

        // PUT: api/Transportlidzekli/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransportlidzekli(int id, Transportlidzekli transportlidzekli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transportlidzekli.TransportaID)
            {
                return BadRequest();
            }

            db.Entry(transportlidzekli).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportlidzekliExists(id))
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

        // POST: api/Transportlidzekli
        [ResponseType(typeof(Transportlidzekli))]
        public IHttpActionResult PostTransportlidzekli(Transportlidzekli transportlidzekli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transportlidzeklis.Add(transportlidzekli);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransportlidzekliExists(transportlidzekli.TransportaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-TransportlidzekliController", new { id = transportlidzekli.TransportaID }, transportlidzekli);
        }

        // DELETE: api/Transportlidzekli/5
        [ResponseType(typeof(Transportlidzekli))]
        public IHttpActionResult DeleteTransportlidzekli(int id)
        {
            Transportlidzekli transportlidzekli = db.Transportlidzeklis.Find(id);
            if (transportlidzekli == null)
            {
                return NotFound();
            }

            db.Transportlidzeklis.Remove(transportlidzekli);
            db.SaveChanges();

            return Ok(transportlidzekli);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransportlidzekliExists(int id)
        {
            return db.Transportlidzeklis.Count(e => e.TransportaID == id) > 0;
        }
    }
}