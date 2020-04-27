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
    public class PiekabesVeidsController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/PiekabesVeids
        public IQueryable<PiekabesVeidsViewModel> GetPiekabes_veids()
        {
            return db.Piekabes_veids.Select(piekabes_veids => new PiekabesVeidsViewModel
            {
                PVID = piekabes_veids.PVID,
                Max_kajaku_ietilpiba = piekabes_veids.Max_kajaku_ietilpiba,
                Max_kanoe_ietilpiba = piekabes_veids.Max_kanoe_ietilpiba,
                Max_piep_ietilpiba = piekabes_veids.Max_piep_ietilpiba,
                Max_supdelu_ietilpiba = piekabes_veids.Max_supdelu_ietilpiba,
                Veida_nosaukums = piekabes_veids.Veida_nosaukums
            });
        }

        // GET: api/PiekabesVeids/5
        [ResponseType(typeof(PiekabesVeidsViewModel))]
        public IHttpActionResult GetPiekabes_veids(int id)
        {
            Piekabes_veids piekabes_veids = db.Piekabes_veids.Find(id);
            if (piekabes_veids == null)
            {
                return NotFound();
            }

            return Ok(new PiekabesVeidsViewModel
            {
                PVID = piekabes_veids.PVID,
                Max_kajaku_ietilpiba = piekabes_veids.Max_kajaku_ietilpiba,
                Max_kanoe_ietilpiba = piekabes_veids.Max_kanoe_ietilpiba,
                Max_piep_ietilpiba = piekabes_veids.Max_piep_ietilpiba,
                Max_supdelu_ietilpiba = piekabes_veids.Max_supdelu_ietilpiba,
                Veida_nosaukums = piekabes_veids.Veida_nosaukums
            });
        }

        // PUT: api/PiekabesVeids/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPiekabes_veids(int id, PiekabesVeidsViewModel piekabes_veids)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piekabes_veids.PVID)
            {
                return BadRequest();
            }

            var entry = db.Piekabes_veids.FirstOrDefault(_ => _.PVID == piekabes_veids.PVID);
            if (entry == null)
            {
                return NotFound();
            }
            entry.Veida_nosaukums = piekabes_veids.Veida_nosaukums;
            entry.Max_kajaku_ietilpiba = piekabes_veids.Max_kajaku_ietilpiba;
            entry.Max_kanoe_ietilpiba = piekabes_veids.Max_kanoe_ietilpiba;
            entry.Max_piep_ietilpiba = piekabes_veids.Max_piep_ietilpiba;
            entry.Max_supdelu_ietilpiba = piekabes_veids.Max_supdelu_ietilpiba;

            db.Entry(entry).State = EntityState.Modified;

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
        [ResponseType(typeof(PiekabesVeidsViewModel))]
        public IHttpActionResult PostPiekabes_veids(PiekabesVeidsViewModel piekabes_veids)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Piekabes_veids.Add(new Piekabes_veids
            {
                Veida_nosaukums = piekabes_veids.Veida_nosaukums,
                Max_kajaku_ietilpiba = piekabes_veids.Max_kajaku_ietilpiba,
                Max_kanoe_ietilpiba = piekabes_veids.Max_kanoe_ietilpiba,
                Max_piep_ietilpiba = piekabes_veids.Max_piep_ietilpiba,
                Max_supdelu_ietilpiba = piekabes_veids.Max_supdelu_ietilpiba,
                PVID = piekabes_veids.PVID
            });

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
        [ResponseType(typeof(PiekabesVeidsViewModel))]
        public IHttpActionResult DeletePiekabes_veids(int id)
        {
            Piekabes_veids piekabes_veids = db.Piekabes_veids.Find(id);
            if (piekabes_veids == null)
            {
                return NotFound();
            }

            db.Piekabes_veids.Remove(piekabes_veids);
            db.SaveChanges();

            return Ok(new PiekabesVeidsViewModel
            {
                PVID = piekabes_veids.PVID,
                Max_kajaku_ietilpiba = piekabes_veids.Max_kajaku_ietilpiba,
                Max_kanoe_ietilpiba = piekabes_veids.Max_kanoe_ietilpiba,
                Max_piep_ietilpiba = piekabes_veids.Max_piep_ietilpiba,
                Max_supdelu_ietilpiba = piekabes_veids.Max_supdelu_ietilpiba,
                Veida_nosaukums = piekabes_veids.Veida_nosaukums
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

        private bool Piekabes_veidsExists(int id)
        {
            return db.Piekabes_veids.Count(e => e.PVID == id) > 0;
        }
    }
}