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
    public class GatavaShemaModulisController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/GatavaShemaModulis
        public IQueryable<GatavaShemaModulis> GetGatavā_shēma_modulis()
        {
            return db.Gatavā_shēma_modulis;
        }

        // GET: api/GatavaShemaModulis/5
        [ResponseType(typeof(GatavaShemaModulis))]
        public IHttpActionResult GetGatavaShemaModulis(int id)
        {
            GatavaShemaModulis gatavaShemaModulis = db.Gatavā_shēma_modulis.Find(id);
            if (gatavaShemaModulis == null)
            {
                return NotFound();
            }

            return Ok(gatavaShemaModulis);
        }

        // PUT: api/GatavaShemaModulis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGatavaShemaModulis(int id, GatavaShemaModulis gatavaShemaModulis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gatavaShemaModulis.Gatavā_shēma_moduļa_ID)
            {
                return BadRequest();
            }

            db.Entry(gatavaShemaModulis).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GatavaShemaModulisExists(id))
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

        // POST: api/GatavaShemaModulis
        [ResponseType(typeof(GatavaShemaModulis))]
        public IHttpActionResult PostGatavaShemaModulis(GatavaShemaModulis gatavaShemaModulis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gatavā_shēma_modulis.Add(gatavaShemaModulis);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GatavaShemaModulisExists(gatavaShemaModulis.Gatavā_shēma_moduļa_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gatavaShemaModulis.Gatavā_shēma_moduļa_ID }, gatavaShemaModulis);
        }

        // DELETE: api/GatavaShemaModulis/5
        [ResponseType(typeof(GatavaShemaModulis))]
        public IHttpActionResult DeleteGatavaShemaModulis(int id)
        {
            GatavaShemaModulis gatavaShemaModulis = db.Gatavā_shēma_modulis.Find(id);
            if (gatavaShemaModulis == null)
            {
                return NotFound();
            }

            db.Gatavā_shēma_modulis.Remove(gatavaShemaModulis);
            db.SaveChanges();

            return Ok(gatavaShemaModulis);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GatavaShemaModulisExists(int id)
        {
            return db.Gatavā_shēma_modulis.Count(e => e.Gatavā_shēma_moduļa_ID == id) > 0;
        }
    }
}