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
using Sigulda.WEB.Contexts.wolverine;

namespace Sigulda.WEB.Controllers.wolverine
{
    public class PiekabesVeidsController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/PiekabesVeids
        public IQueryable<Piekabes_veids> GetPiekabes_veids()
        {
            return db.Piekabes_veids;
        }

        // GET: api/PiekabesVeids/5
        [ResponseType(typeof(Piekabes_veids))]
        public IHttpActionResult GetPiekabes_veids(int id)
        {
            Piekabes_veids piekabes_veids = db.Piekabes_veids.Find(id);
            if (piekabes_veids == null)
            {
                return NotFound();
            }

            return Ok(piekabes_veids);
        }

        // PUT: api/PiekabesVeids/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPiekabes_veids(int id, Piekabes_veids piekabes_veids)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piekabes_veids.PVID)
            {
                return BadRequest();
            }

            db.Entry(piekabes_veids).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Piekabes_veidsExists(id))
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

        // POST: api/PiekabesVeids
        [ResponseType(typeof(Piekabes_veids))]
        public IHttpActionResult PostPiekabes_veids(Piekabes_veids piekabes_veids)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Piekabes_veids.Add(piekabes_veids);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Piekabes_veidsExists(piekabes_veids.PVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-PiekabesVeidsController", new { id = piekabes_veids.PVID }, piekabes_veids);
        }

        // DELETE: api/PiekabesVeids/5
        [ResponseType(typeof(Piekabes_veids))]
        public IHttpActionResult DeletePiekabes_veids(int id)
        {
            Piekabes_veids piekabes_veids = db.Piekabes_veids.Find(id);
            if (piekabes_veids == null)
            {
                return NotFound();
            }

            db.Piekabes_veids.Remove(piekabes_veids);
            db.SaveChanges();

            return Ok(piekabes_veids);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Piekabes_veidsExists(int id)
        {
            return db.Piekabes_veids.Count(e => e.PVID == id) > 0;
        }
    }
}