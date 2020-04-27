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
using Sigulda.WEB.Controllers.deadpool.ViewModels;

namespace Sigulda.WEB.Controllers.deadpool
{
    public class InventaraTipiController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/InventaraTipi
        public IQueryable<InventaraTipiViewModel> Getinventara_tipi2()
        {
            return db.inventara_tipi2.Select(_ => new InventaraTipiViewModel 
            { 
                tipa_id = _.tipa_id,
                Apraksts = _.Apraksts,
                nosaukums = _.nosaukums
            });
        }

        // GET: api/InventaraTipi/5
        [ResponseType(typeof(InventaraTipiViewModel))]
        public IHttpActionResult Getinventara_tipi2(string id)
        {
            inventara_tipi2 inventara_tipi2 = db.inventara_tipi2.Find(id);
            if (inventara_tipi2 == null)
            {
                return NotFound();
            }

            return Ok(new InventaraTipiViewModel
            {
                tipa_id = inventara_tipi2.tipa_id,
                Apraksts = inventara_tipi2.Apraksts,
                nosaukums = inventara_tipi2.nosaukums
            });
        }

        // PUT: api/InventaraTipi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinventara_tipi2(string id, InventaraTipiViewModel inventara_tipi2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventara_tipi2.tipa_id)
            {
                return BadRequest();
            }

            var entry = db.inventara_tipi2.FirstOrDefault(_ => _.tipa_id == inventara_tipi2.tipa_id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.nosaukums = inventara_tipi2.nosaukums;
            entry.Apraksts = inventara_tipi2.Apraksts;

            db.Entry(entry).State = EntityState.Modified;

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
        [ResponseType(typeof(InventaraTipiViewModel))]
        public IHttpActionResult Postinventara_tipi2(InventaraTipiViewModel inventara_tipi2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = new inventara_tipi2
            {
                tipa_id = inventara_tipi2.tipa_id,
                Apraksts = inventara_tipi2.Apraksts,
                nosaukums = inventara_tipi2.nosaukums
            };

            db.inventara_tipi2.Add(entry);

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
        [ResponseType(typeof(InventaraTipiViewModel))]
        public IHttpActionResult Deleteinventara_tipi2(string id)
        {
            inventara_tipi2 inventara_tipi2 = db.inventara_tipi2.Find(id);
            if (inventara_tipi2 == null)
            {
                return NotFound();
            }

            db.inventara_tipi2.Remove(inventara_tipi2);
            db.SaveChanges();

            return Ok(new InventaraTipiViewModel
            {
                tipa_id = inventara_tipi2.tipa_id,
                Apraksts = inventara_tipi2.Apraksts,
                nosaukums = inventara_tipi2.nosaukums
            });
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