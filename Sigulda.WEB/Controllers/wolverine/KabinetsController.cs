﻿using System;
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
    public class KabinetsController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Kabinets
        public IQueryable<Kabinets> GetKabinets()
        {
            return db.Kabinets;
        }

        // GET: api/Kabinets/5
        [ResponseType(typeof(Kabinets))]
        public IHttpActionResult GetKabinets(string id)
        {
            Kabinets kabinets = db.Kabinets.Find(id);
            if (kabinets == null)
            {
                return NotFound();
            }

            return Ok(kabinets);
        }

        // PUT: api/Kabinets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabinets(string id, Kabinets kabinets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabinets.Elektronika)
            {
                return BadRequest();
            }

            db.Entry(kabinets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KabinetsExists(id))
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

        // POST: api/Kabinets
        [ResponseType(typeof(Kabinets))]
        public IHttpActionResult PostKabinets(Kabinets kabinets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kabinets.Add(kabinets);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KabinetsExists(kabinets.Elektronika))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kabinets.Elektronika }, kabinets);
        }

        // DELETE: api/Kabinets/5
        [ResponseType(typeof(Kabinets))]
        public IHttpActionResult DeleteKabinets(string id)
        {
            Kabinets kabinets = db.Kabinets.Find(id);
            if (kabinets == null)
            {
                return NotFound();
            }

            db.Kabinets.Remove(kabinets);
            db.SaveChanges();

            return Ok(kabinets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KabinetsExists(string id)
        {
            return db.Kabinets.Count(e => e.Elektronika == id) > 0;
        }
    }
}