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
    public class PasutijumiController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Pasutijumi
        public IQueryable<PasutijumiViewModel> GetPasutijumis()
        {
            return db.Pasutijumis.Select(pasutijumi => new PasutijumiViewModel
            {
                Pas_ID = pasutijumi.Pas_ID,
                Klients = pasutijumi.Klients,
                Laivu_daudzums = pasutijumi.Laivu_daudzums,
                Laivu_veids = pasutijumi.Laivu_veids,
                Ires_beigas = pasutijumi.Ires_beigas,
                Ires_sakums = pasutijumi.Ires_sakums,
                Soferis = pasutijumi.Soferis
            });
        }

        // GET: api/Pasutijumi/5
        [ResponseType(typeof(PasutijumiViewModel))]
        public IHttpActionResult GetPasutijumi(int id)
        {
            Pasutijumi pasutijumi = db.Pasutijumis.Find(id);
            if (pasutijumi == null)
            {
                return NotFound();
            }

            return Ok(new PasutijumiViewModel
            {
                Pas_ID = pasutijumi.Pas_ID,
                Klients = pasutijumi.Klients,
                Laivu_daudzums = pasutijumi.Laivu_daudzums,
                Laivu_veids = pasutijumi.Laivu_veids,
                Ires_beigas = pasutijumi.Ires_beigas,
                Ires_sakums = pasutijumi.Ires_sakums,
                Soferis = pasutijumi.Soferis
            });
        }

        // PUT: api/Pasutijumi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPasutijumi(int id, PasutijumiViewModel pasutijumi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pasutijumi.Pas_ID)
            {
                return BadRequest();
            }

            var entry = db.Pasutijumis.FirstOrDefault(_ => _.Pas_ID == pasutijumi.Pas_ID);
            if (entry == null)
            {
                return NotFound();
            }
            entry.Klients = pasutijumi.Klients;
            entry.Laivu_veids = pasutijumi.Laivu_veids;
            entry.Laivu_daudzums = pasutijumi.Laivu_daudzums;
            entry.Soferis = pasutijumi.Soferis;
            entry.Ires_beigas = pasutijumi.Ires_beigas;
            entry.Ires_sakums = pasutijumi.Ires_sakums;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasutijumiExists(id))
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

        // POST: api/Pasutijumi
        [ResponseType(typeof(PasutijumiViewModel))]
        public IHttpActionResult PostPasutijumi(PasutijumiViewModel pasutijumi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pasutijumis.Add(new Pasutijumi
            {
                Klients = pasutijumi.Klients,
                Laivu_veids = pasutijumi.Laivu_veids,
                Laivu_daudzums = pasutijumi.Laivu_daudzums,
                Soferis = pasutijumi.Soferis,
                Ires_beigas = pasutijumi.Ires_beigas,
                Ires_sakums = pasutijumi.Ires_sakums,
                Pas_ID = pasutijumi.Pas_ID
        });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PasutijumiExists(pasutijumi.Pas_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-PasutijumiController", new { id = pasutijumi.Pas_ID }, pasutijumi);
        }

        // DELETE: api/Pasutijumi/5
        [ResponseType(typeof(PasutijumiViewModel))]
        public IHttpActionResult DeletePasutijumi(int id)
        {
            Pasutijumi pasutijumi = db.Pasutijumis.Find(id);
            if (pasutijumi == null)
            {
                return NotFound();
            }

            db.Pasutijumis.Remove(pasutijumi);
            db.SaveChanges();

            return Ok(new PasutijumiViewModel
            {
                Pas_ID = pasutijumi.Pas_ID,
                Klients = pasutijumi.Klients,
                Laivu_daudzums = pasutijumi.Laivu_daudzums,
                Laivu_veids = pasutijumi.Laivu_veids,
                Ires_beigas = pasutijumi.Ires_beigas,
                Ires_sakums = pasutijumi.Ires_sakums,
                Soferis = pasutijumi.Soferis
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

        private bool PasutijumiExists(int id)
        {
            return db.Pasutijumis.Count(e => e.Pas_ID == id) > 0;
        }
    }
}