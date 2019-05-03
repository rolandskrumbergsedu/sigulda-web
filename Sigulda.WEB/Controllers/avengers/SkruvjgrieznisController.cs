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
using Sigulda.WEB.Contexts.avengers;

namespace Sigulda.WEB.Controllers.avengers
{
    public class SkruvjgrieznisController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/Skruvjgrieznis
        public IQueryable<Skruvjgriezni> GetSkruvjgrieznis()
        {
            return db.Skruvjgrieznis;
        }

        // GET: api/Skruvjgrieznis/5
        [ResponseType(typeof(Skruvjgriezni))]
        public IHttpActionResult GetSkruvjgriezni(int id)
        {
            Skruvjgriezni skruvjgriezni = db.Skruvjgrieznis.Find(id);
            if (skruvjgriezni == null)
            {
                return NotFound();
            }

            return Ok(skruvjgriezni);
        }

        // PUT: api/Skruvjgrieznis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkruvjgriezni(int id, Skruvjgriezni skruvjgriezni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skruvjgriezni.Skruvgriezna_ID)
            {
                return BadRequest();
            }

            db.Entry(skruvjgriezni).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkruvjgriezniExists(id))
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

        // POST: api/Skruvjgrieznis
        [ResponseType(typeof(Skruvjgriezni))]
        public IHttpActionResult PostSkruvjgriezni(Skruvjgriezni skruvjgriezni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Skruvjgrieznis.Add(skruvjgriezni);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SkruvjgriezniExists(skruvjgriezni.Skruvgriezna_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("AvengersApi-Skruvjgrieznis", new { id = skruvjgriezni.Skruvgriezna_ID }, skruvjgriezni);
        }

        // DELETE: api/Skruvjgrieznis/5
        [ResponseType(typeof(Skruvjgriezni))]
        public IHttpActionResult DeleteSkruvjgriezni(int id)
        {
            Skruvjgriezni skruvjgriezni = db.Skruvjgrieznis.Find(id);
            if (skruvjgriezni == null)
            {
                return NotFound();
            }

            db.Skruvjgrieznis.Remove(skruvjgriezni);
            db.SaveChanges();

            return Ok(skruvjgriezni);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkruvjgriezniExists(int id)
        {
            return db.Skruvjgrieznis.Count(e => e.Skruvgriezna_ID == id) > 0;
        }
    }
}