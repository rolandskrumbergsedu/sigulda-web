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
    public class ObjektsController : ApiController
    {
        private IronMan db = new IronMan();

        // GET: api/Objekts
        public IQueryable<Objekt> GetObjekts()
        {
            return db.Objekts;
        }

        // GET: api/Objekts/5
        [ResponseType(typeof(Objekt))]
        public IHttpActionResult GetObjekt(int id)
        {
            Objekt objekt = db.Objekts.Find(id);
            if (objekt == null)
            {
                return NotFound();
            }

            return Ok(objekt);
        }

        // PUT: api/Objekts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutObjekt(int id, Objekt objekt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objekt.Objekta_ID)
            {
                return BadRequest();
            }

            db.Entry(objekt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjektExists(id))
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

        // POST: api/Objekts
        [ResponseType(typeof(Objekt))]
        public IHttpActionResult PostObjekt(Objekt objekt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Objekts.Add(objekt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ObjektExists(objekt.Objekta_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("IronManApi-ObjektsController", new { id = objekt.Objekta_ID }, objekt);
        }

        // DELETE: api/Objekts/5
        [ResponseType(typeof(Objekt))]
        public IHttpActionResult DeleteObjekt(int id)
        {
            Objekt objekt = db.Objekts.Find(id);
            if (objekt == null)
            {
                return NotFound();
            }

            db.Objekts.Remove(objekt);
            db.SaveChanges();

            return Ok(objekt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObjektExists(int id)
        {
            return db.Objekts.Count(e => e.Objekta_ID == id) > 0;
        }
    }
}