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
    public class ReagentiController : ApiController
    {
        private IronMan db = new IronMan();

        // GET: api/Reagenti
        public IQueryable<Reagenti> GetReagentis()
        {
            return db.Reagentis;
        }

        // GET: api/Reagenti/5
        [ResponseType(typeof(Reagenti))]
        public IHttpActionResult GetReagenti(int id)
        {
            Reagenti reagenti = db.Reagentis.Find(id);
            if (reagenti == null)
            {
                return NotFound();
            }

            return Ok(reagenti);
        }

        // PUT: api/Reagenti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReagenti(int id, Reagenti reagenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reagenti.Reagenti_ID)
            {
                return BadRequest();
            }

            db.Entry(reagenti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReagentiExists(id))
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

        // POST: api/Reagenti
        [ResponseType(typeof(Reagenti))]
        public IHttpActionResult PostReagenti(Reagenti reagenti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reagentis.Add(reagenti);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReagentiExists(reagenti.Reagenti_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("IronManApi-ReagentiController", new { id = reagenti.Reagenti_ID }, reagenti);
        }

        // DELETE: api/Reagenti/5
        [ResponseType(typeof(Reagenti))]
        public IHttpActionResult DeleteReagenti(int id)
        {
            Reagenti reagenti = db.Reagentis.Find(id);
            if (reagenti == null)
            {
                return NotFound();
            }

            db.Reagentis.Remove(reagenti);
            db.SaveChanges();

            return Ok(reagenti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReagentiExists(int id)
        {
            return db.Reagentis.Count(e => e.Reagenti_ID == id) > 0;
        }
    }
}