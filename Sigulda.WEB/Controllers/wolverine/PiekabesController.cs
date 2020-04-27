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
    public class PiekabesController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Piekabes
        public IQueryable<PiekabeViewModel> GetPiekabes()
        {
            return db.Piekabes.Select(piekabe => new PiekabeViewModel
            {
                PiekabesID = piekabe.PiekabesID,
                Nosaukums = piekabe.Nosaukums,
                Veids = piekabe.Veids
            });
        }

        // GET: api/Piekabes/5
        [ResponseType(typeof(PiekabeViewModel))]
        public IHttpActionResult GetPiekabe(int id)
        {
            Piekabe piekabe = db.Piekabes.Find(id);
            if (piekabe == null)
            {
                return NotFound();
            }

            return Ok(new PiekabeViewModel
            {
                PiekabesID = piekabe.PiekabesID,
                Nosaukums = piekabe.Nosaukums,
                Veids = piekabe.Veids
            });
        }

        // PUT: api/Piekabes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPiekabe(int id, PiekabeViewModel piekabe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piekabe.PiekabesID)
            {
                return BadRequest();
            }

            var entry = db.Piekabes.FirstOrDefault(_ => _.PiekabesID == piekabe.PiekabesID);
            entry.Nosaukums = piekabe.Nosaukums;
            entry.Veids = piekabe.Veids;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiekabeExists(id))
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

        // POST: api/Piekabes
        [ResponseType(typeof(PiekabeViewModel))]
        public IHttpActionResult PostPiekabe(PiekabeViewModel piekabe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Piekabes.Add(new Piekabe
            {
                PiekabesID = piekabe.PiekabesID,
                Nosaukums = piekabe.Nosaukums,
                Veids = piekabe.Veids
            });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PiekabeExists(piekabe.PiekabesID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-PiekabesController", new { id = piekabe.PiekabesID }, piekabe);
        }

        // DELETE: api/Piekabes/5
        [ResponseType(typeof(PiekabeViewModel))]
        public IHttpActionResult DeletePiekabe(int id)
        {
            Piekabe piekabe = db.Piekabes.Find(id);
            if (piekabe == null)
            {
                return NotFound();
            }

            db.Piekabes.Remove(piekabe);
            db.SaveChanges();

            return Ok(new PiekabeViewModel
            {
                PiekabesID = piekabe.PiekabesID,
                Nosaukums = piekabe.Nosaukums,
                Veids = piekabe.Veids
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

        private bool PiekabeExists(int id)
        {
            return db.Piekabes.Count(e => e.PiekabesID == id) > 0;
        }
    }
}