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
using Sigulda.WEB.Controllers.wolverine.ViewModels;

namespace Sigulda.WEB.Controllers.wolverine
{
    public class SoferiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Soferi
        public IQueryable<SoferiViewModel> GetSoferis()
        {
            return db.Soferis.Select(soferi => new SoferiViewModel
            {
                SoferaID = soferi.SoferaID,
                Telefona_nr = soferi.Telefona_nr,
                Transports = soferi.Transports,
                Uzvards = soferi.Uzvards,
                Vards = soferi.Vards
            });
        }

        // GET: api/Soferi/5
        [ResponseType(typeof(SoferiViewModel))]
        public IHttpActionResult GetSoferi(int id)
        {
            Soferi soferi = db.Soferis.Find(id);
            if (soferi == null)
            {
                return NotFound();
            }

            return Ok(new SoferiViewModel
            {
                SoferaID = soferi.SoferaID,
                Telefona_nr = soferi.Telefona_nr,
                Transports = soferi.Transports,
                Uzvards = soferi.Uzvards,
                Vards = soferi.Vards
            });
        }

        // PUT: api/Soferi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSoferi(int id, SoferiViewModel soferi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soferi.SoferaID)
            {
                return BadRequest();
            }

            var entry = db.Soferis.FirstOrDefault(_ => _.SoferaID == soferi.SoferaID);
            if (entry == null)
            {
                return NotFound();
            }
            entry.Vards = soferi.Vards;
            entry.Uzvards = soferi.Uzvards;
            entry.Telefona_nr = soferi.Telefona_nr;
            entry.Transports = soferi.Transports;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoferiExists(id))
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

        // POST: api/Soferi
        [ResponseType(typeof(SoferiViewModel))]
        public IHttpActionResult PostSoferi(SoferiViewModel soferi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Soferis.Add(new Soferi
            {
                Vards = soferi.Vards,
                Uzvards = soferi.Uzvards,
                Telefona_nr = soferi.Telefona_nr,
                Transports = soferi.Transports,
                SoferaID = soferi.SoferaID
            });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SoferiExists(soferi.SoferaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-SoferiController", new { id = soferi.SoferaID }, soferi);
        }

        // DELETE: api/Soferi/5
        [ResponseType(typeof(SoferiViewModel))]
        public IHttpActionResult DeleteSoferi(int id)
        {
            Soferi soferi = db.Soferis.Find(id);
            if (soferi == null)
            {
                return NotFound();
            }

            db.Soferis.Remove(soferi);
            db.SaveChanges();

            return Ok(new SoferiViewModel
            {
                SoferaID = soferi.SoferaID,
                Telefona_nr = soferi.Telefona_nr,
                Transports = soferi.Transports,
                Uzvards = soferi.Uzvards,
                Vards = soferi.Vards
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

        private bool SoferiExists(int id)
        {
            return db.Soferis.Count(e => e.SoferaID == id) > 0;
        }
    }
}