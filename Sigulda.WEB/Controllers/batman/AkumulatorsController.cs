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
    public class AkumulatorsController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/Akumulators
        public IQueryable<Akumulators> GetAkumulators()
        {
            return db.Akumulators;
        }

        // GET: api/Akumulators/5
        [ResponseType(typeof(Akumulators))]
        public IHttpActionResult GetAkumulators(int id)
        {
            Akumulators akumulators = db.Akumulators.Find(id);
            if (akumulators == null)
            {
                return NotFound();
            }

            return Ok(akumulators);
        }

        // PUT: api/Akumulators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAkumulators(int id, Akumulators akumulators)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != akumulators.Akumulatora_ID)
            {
                return BadRequest();
            }

            db.Entry(akumulators).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AkumulatorsExists(id))
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

        // POST: api/Akumulators
        [ResponseType(typeof(Akumulators))]
        public IHttpActionResult PostAkumulators(Akumulators akumulators)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Akumulators.Add(akumulators);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AkumulatorsExists(akumulators.Akumulatora_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = akumulators.Akumulatora_ID }, akumulators);
        }

        // DELETE: api/Akumulators/5
        [ResponseType(typeof(Akumulators))]
        public IHttpActionResult DeleteAkumulators(int id)
        {
            Akumulators akumulators = db.Akumulators.Find(id);
            if (akumulators == null)
            {
                return NotFound();
            }

            db.Akumulators.Remove(akumulators);
            db.SaveChanges();

            return Ok(akumulators);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AkumulatorsExists(int id)
        {
            return db.Akumulators.Count(e => e.Akumulatora_ID == id) > 0;
        }
    }
}