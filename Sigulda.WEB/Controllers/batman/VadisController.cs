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
    public class VadisController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/Vadis
        public IQueryable<Vadi> GetVadis()
        {
            return db.Vadis;
        }

        // GET: api/Vadis/5
        [ResponseType(typeof(Vadi))]
        public IHttpActionResult GetVadi(int id)
        {
            Vadi vadi = db.Vadis.Find(id);
            if (vadi == null)
            {
                return NotFound();
            }

            return Ok(vadi);
        }

        // PUT: api/Vadis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVadi(int id, Vadi vadi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vadi.Vadi_ID)
            {
                return BadRequest();
            }

            db.Entry(vadi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VadiExists(id))
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

        // POST: api/Vadis
        [ResponseType(typeof(Vadi))]
        public IHttpActionResult PostVadi(Vadi vadi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vadis.Add(vadi);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VadiExists(vadi.Vadi_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("BatmanApi-VadisController", new { id = vadi.Vadi_ID }, vadi);
        }

        // DELETE: api/Vadis/5
        [ResponseType(typeof(Vadi))]
        public IHttpActionResult DeleteVadi(int id)
        {
            Vadi vadi = db.Vadis.Find(id);
            if (vadi == null)
            {
                return NotFound();
            }

            db.Vadis.Remove(vadi);
            db.SaveChanges();

            return Ok(vadi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VadiExists(int id)
        {
            return db.Vadis.Count(e => e.Vadi_ID == id) > 0;
        }
    }
}