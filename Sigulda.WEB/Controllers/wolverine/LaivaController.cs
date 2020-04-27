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
    public class LaivaController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Laiva
        public IQueryable<LaivaViewModel> GetLaivas()
        {
            return db.Laivas.Select(laiva => new LaivaViewModel
            {
                LaivasID = laiva.LaivasID,
                Nosaukums = laiva.Nosaukums,
                Skaits = laiva.Skaits,
                Veids = laiva.Veids
            });
        }

        // GET: api/Laiva/5
        [ResponseType(typeof(LaivaViewModel))]
        public IHttpActionResult GetLaiva(int id)
        {
            Laiva laiva = db.Laivas.Find(id);
            if (laiva == null)
            {
                return NotFound();
            }

            return Ok(new LaivaViewModel
            {
                LaivasID = laiva.LaivasID,
                Nosaukums = laiva.Nosaukums,
                Skaits = laiva.Skaits,
                Veids = laiva.Veids
            });
        }

        // PUT: api/Laiva/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaiva(int id, LaivaViewModel laiva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laiva.LaivasID)
            {
                return BadRequest();
            }

            var entry = db.Laivas.FirstOrDefault(_ => _.LaivasID == laiva.LaivasID);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Nosaukums = laiva.Nosaukums;
            entry.Veids = laiva.Veids;
            entry.Skaits = laiva.Skaits;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaivaExists(id))
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

        // POST: api/Laiva
        [ResponseType(typeof(LaivaViewModel))]
        public IHttpActionResult PostLaiva(LaivaViewModel laiva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Laivas.Add(new Laiva
            {
                LaivasID = laiva.LaivasID,
                Nosaukums = laiva.Nosaukums,
                Veids = laiva.Veids,
                Skaits = laiva.Skaits
            });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LaivaExists(laiva.LaivasID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-LaivaController", new { id = laiva.LaivasID }, laiva);
        }

        // DELETE: api/Laiva/5
        [ResponseType(typeof(LaivaViewModel))]
        public IHttpActionResult DeleteLaiva(int id)
        {
            Laiva laiva = db.Laivas.Find(id);
            if (laiva == null)
            {
                return NotFound();
            }

            db.Laivas.Remove(laiva);
            db.SaveChanges();

            return Ok(new LaivaViewModel
            {
                LaivasID = laiva.LaivasID,
                Nosaukums = laiva.Nosaukums,
                Skaits = laiva.Skaits,
                Veids = laiva.Veids
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

        private bool LaivaExists(int id)
        {
            return db.Laivas.Count(e => e.LaivasID == id) > 0;
        }
    }
}