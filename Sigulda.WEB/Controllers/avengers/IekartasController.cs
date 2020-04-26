using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Sigulda.WEB.Contexts.avengers;

namespace Sigulda.WEB.Controllers.avengers
{
    public class IekartasController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Iekartas
        public IQueryable<Iekarta> GetIekartas()
        {
            return db.Iekartas;
        }

        // GET: api/Iekartas/5
        [ResponseType(typeof(Iekarta))]
        public IHttpActionResult GetIekarta(int id)
        {
            Iekarta iekarta = db.Iekartas.Find(id);
            if (iekarta == null)
            {
                return NotFound();
            }

            return Ok(iekarta);
        }

        // PUT: api/Iekartas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIekarta(int id, Iekarta iekarta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iekarta.IekartasID)
            {
                return BadRequest();
            }

            db.Entry(iekarta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IekartaExists(id))
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

        // POST: api/Iekartas
        [ResponseType(typeof(Iekarta))]
        public IHttpActionResult PostIekarta(Iekarta iekarta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Iekartas.Add(iekarta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IekartaExists(iekarta.IekartasID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("AvengersApi-Iekartas", new { id = iekarta.IekartasID }, iekarta);
        }

        // DELETE: api/Iekartas/5
        [ResponseType(typeof(Iekarta))]
        public IHttpActionResult DeleteIekarta(int id)
        {
            Iekarta iekarta = db.Iekartas.Find(id);
            if (iekarta == null)
            {
                return NotFound();
            }

            db.Iekartas.Remove(iekarta);
            db.SaveChanges();

            return Ok(iekarta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IekartaExists(int id)
        {
            return db.Iekartas.Count(e => e.IekartasID == id) > 0;
        }
    }
}