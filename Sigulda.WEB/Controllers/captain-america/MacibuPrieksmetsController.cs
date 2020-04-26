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
using Sigulda.WEB.Contexts.captain_america;

namespace Sigulda.WEB.Controllers.captain_america
{
    public class MacibuPrieksmetsController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/MacibuPrieksmets
        public IQueryable<Macibu_prieksmets> GetMacibu_prieksmets()
        {
            return db.Macibu_prieksmets;
        }

        // GET: api/MacibuPrieksmets/5
        [ResponseType(typeof(Macibu_prieksmets))]
        public IHttpActionResult GetMacibu_prieksmets(int id)
        {
            Macibu_prieksmets macibu_prieksmets = db.Macibu_prieksmets.Find(id);
            if (macibu_prieksmets == null)
            {
                return NotFound();
            }

            return Ok(macibu_prieksmets);
        }

        // PUT: api/MacibuPrieksmets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMacibu_prieksmets(int id, Macibu_prieksmets macibu_prieksmets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != macibu_prieksmets.Prieksmets_ID)
            {
                return BadRequest();
            }

            db.Entry(macibu_prieksmets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Macibu_prieksmetsExists(id))
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

        // POST: api/MacibuPrieksmets
        [ResponseType(typeof(Macibu_prieksmets))]
        public IHttpActionResult PostMacibu_prieksmets(Macibu_prieksmets macibu_prieksmets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Macibu_prieksmets.Add(macibu_prieksmets);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Macibu_prieksmetsExists(macibu_prieksmets.Prieksmets_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("CaptainAmericaApi-MacibuPrieksmetsController", new { id = macibu_prieksmets.Prieksmets_ID }, macibu_prieksmets);
        }

        // DELETE: api/MacibuPrieksmets/5
        [ResponseType(typeof(Macibu_prieksmets))]
        public IHttpActionResult DeleteMacibu_prieksmets(int id)
        {
            Macibu_prieksmets macibu_prieksmets = db.Macibu_prieksmets.Find(id);
            if (macibu_prieksmets == null)
            {
                return NotFound();
            }

            db.Macibu_prieksmets.Remove(macibu_prieksmets);
            db.SaveChanges();

            return Ok(macibu_prieksmets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Macibu_prieksmetsExists(int id)
        {
            return db.Macibu_prieksmets.Count(e => e.Prieksmets_ID == id) > 0;
        }
    }
}