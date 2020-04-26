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
    public class InventaraTipiController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/InventaraTipi
        public IQueryable<inventara_tipi2> Getinventara_tipi2()
        {
            return db.inventara_tipi2;
        }

        // GET: api/InventaraTipi/5
        [ResponseType(typeof(inventara_tipi2))]
        public IHttpActionResult Getinventara_tipi2(string id)
        {
            inventara_tipi2 inventara_tipi2 = db.inventara_tipi2.Find(id);
            if (inventara_tipi2 == null)
            {
                return NotFound();
            }

            return Ok(inventara_tipi2);
        }

        // PUT: api/InventaraTipi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinventara_tipi2(string id, inventara_tipi2 inventara_tipi2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventara_tipi2.tipa_id)
            {
                return BadRequest();
            }

            db.Entry(inventara_tipi2).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inventara_tipi2Exists(id))
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

        // POST: api/InventaraTipi
        [ResponseType(typeof(inventara_tipi2))]
        public IHttpActionResult Postinventara_tipi2(inventara_tipi2 inventara_tipi2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.inventara_tipi2.Add(inventara_tipi2);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (inventara_tipi2Exists(inventara_tipi2.tipa_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-InventaraTipiController", new { id = inventara_tipi2.tipa_id }, inventara_tipi2);
        }

        // DELETE: api/InventaraTipi/5
        [ResponseType(typeof(inventara_tipi2))]
        public IHttpActionResult Deleteinventara_tipi2(string id)
        {
            inventara_tipi2 inventara_tipi2 = db.inventara_tipi2.Find(id);
            if (inventara_tipi2 == null)
            {
                return NotFound();
            }

            db.inventara_tipi2.Remove(inventara_tipi2);
            db.SaveChanges();

            return Ok(inventara_tipi2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool inventara_tipi2Exists(string id)
        {
            return db.inventara_tipi2.Count(e => e.tipa_id == id) > 0;
        }
    }
}