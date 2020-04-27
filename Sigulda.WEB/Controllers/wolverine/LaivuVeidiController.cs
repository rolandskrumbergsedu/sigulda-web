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
    public class LaivuVeidiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/LaivuVeidi
        public IQueryable<LaivuVeidiViewModel> GetLaivu_veidi()
        {
            return db.Laivu_veidi.Select(laivu_veidi => new LaivuVeidiViewModel
            {
                LVID = laivu_veidi.LVID,
                Airi = laivu_veidi.Airi,
                Cilv_ietilpiba = laivu_veidi.Cilv_ietilpiba,
                Veida_nosaukums = laivu_veidi.Veida_nosaukums
            });
        }

        // GET: api/LaivuVeidi/5
        [ResponseType(typeof(LaivuVeidiViewModel))]
        public IHttpActionResult GetLaivu_veidi(int id)
        {
            Laivu_veidi laivu_veidi = db.Laivu_veidi.Find(id);
            if (laivu_veidi == null)
            {
                return NotFound();
            }

            return Ok(new LaivuVeidiViewModel
            {
                LVID = laivu_veidi.LVID,
                Airi = laivu_veidi.Airi,
                Cilv_ietilpiba = laivu_veidi.Cilv_ietilpiba,
                Veida_nosaukums = laivu_veidi.Veida_nosaukums
            });
        }

        // PUT: api/LaivuVeidi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaivu_veidi(int id, LaivuVeidiViewModel laivu_veidi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laivu_veidi.LVID)
            {
                return BadRequest();
            }

            var entry = db.Laivu_veidi.FirstOrDefault(_ => _.LVID == laivu_veidi.LVID);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Veida_nosaukums = laivu_veidi.Veida_nosaukums;
            entry.Cilv_ietilpiba = laivu_veidi.Cilv_ietilpiba;
            entry.Airi = laivu_veidi.Airi;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Laivu_veidiExists(id))
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

        // POST: api/LaivuVeidi
        [ResponseType(typeof(LaivuVeidiViewModel))]
        public IHttpActionResult PostLaivu_veidi(LaivuVeidiViewModel laivu_veidi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Laivu_veidi.Add(new Laivu_veidi
            {
                LVID = laivu_veidi.LVID,
                Airi = laivu_veidi.Airi,
                Cilv_ietilpiba = laivu_veidi.Cilv_ietilpiba,
                Veida_nosaukums = laivu_veidi.Veida_nosaukums
            });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Laivu_veidiExists(laivu_veidi.LVID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-LaivuVeidiController", new { id = laivu_veidi.LVID }, laivu_veidi);
        }

        // DELETE: api/LaivuVeidi/5
        [ResponseType(typeof(LaivuVeidiViewModel))]
        public IHttpActionResult DeleteLaivu_veidi(int id)
        {
            Laivu_veidi laivu_veidi = db.Laivu_veidi.Find(id);
            if (laivu_veidi == null)
            {
                return NotFound();
            }

            db.Laivu_veidi.Remove(laivu_veidi);
            db.SaveChanges();

            return Ok(new LaivuVeidiViewModel
            {
                LVID = laivu_veidi.LVID,
                Airi = laivu_veidi.Airi,
                Cilv_ietilpiba = laivu_veidi.Cilv_ietilpiba,
                Veida_nosaukums = laivu_veidi.Veida_nosaukums
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

        private bool Laivu_veidiExists(int id)
        {
            return db.Laivu_veidi.Count(e => e.LVID == id) > 0;
        }
    }
}