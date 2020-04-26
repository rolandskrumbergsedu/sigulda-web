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
    public class Iekartas2Controller : ApiController
    {
        private IronMan db = new IronMan();

        // GET: api/Iekartas
        public IQueryable<iekarta> Getiekartas()
        {
            return db.iekartas;
        }

        // GET: api/Iekartas/5
        [ResponseType(typeof(iekarta))]
        public IHttpActionResult Getiekarta(int id)
        {
            iekarta iekarta = db.iekartas.Find(id);
            if (iekarta == null)
            {
                return NotFound();
            }

            return Ok(iekarta);
        }

        // PUT: api/Iekartas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putiekarta(int id, iekarta iekarta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iekarta.Iekartas_ID)
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
                if (!iekartaExists(id))
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
        [ResponseType(typeof(iekarta))]
        public IHttpActionResult Postiekarta(iekarta iekarta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.iekartas.Add(iekarta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (iekartaExists(iekarta.Iekartas_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("IronManApi-IekartasController", new { id = iekarta.Iekartas_ID }, iekarta);
        }

        // DELETE: api/Iekartas/5
        [ResponseType(typeof(iekarta))]
        public IHttpActionResult Deleteiekarta(int id)
        {
            iekarta iekarta = db.iekartas.Find(id);
            if (iekarta == null)
            {
                return NotFound();
            }

            db.iekartas.Remove(iekarta);
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

        private bool iekartaExists(int id)
        {
            return db.iekartas.Count(e => e.Iekartas_ID == id) > 0;
        }
    }
}