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
using Sigulda.WEB.Contexts.deadpool;
using Sigulda.WEB.Controllers.deadpool.ViewModels;

namespace Sigulda.WEB.Controllers.deadpool
{
    public class ElektroniskasIericesController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/ElektroniskasIerices
        public IQueryable<ElektroniskasIericesViewModel> GetElektroniskasIerices()
        {
            return db.ElektroniskasIerices.Select(x => new ElektroniskasIericesViewModel {
                Datums = x.Datums,
                IericesCena = x.IericesCena,
                IericesID = x.IericesID,
                IericesNolietojums = x.IericesNolietojums,
                IericesNosaukums = x.IericesNosaukums
            });
        }

        // GET: api/ElektroniskasIerices/5
        [ResponseType(typeof(ElektroniskasIericesViewModel))]
        public IHttpActionResult GetElektroniskasIerices(int id)
        {
            ElektroniskasIerices elektroniskasIerices = db.ElektroniskasIerices.Find(id);
            if (elektroniskasIerices == null)
            {
                return NotFound();
            }

            return Ok(new ElektroniskasIericesViewModel
            {
                Datums =elektroniskasIerices.Datums,
                IericesNosaukums = elektroniskasIerices.IericesNosaukums,
                IericesNolietojums = elektroniskasIerices.IericesNolietojums,
                IericesID = elektroniskasIerices.IericesID,
                IericesCena = elektroniskasIerices.IericesCena
            });
        }

        // PUT: api/ElektroniskasIerices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutElektroniskasIerices(int id, ElektroniskasIericesViewModel elektroniskasIericesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elektroniskasIerices = db.ElektroniskasIerices.FirstOrDefault(x => x.IericesID == elektroniskasIericesModel.IericesID);
            if (id != elektroniskasIerices.IericesID)
            {
                return BadRequest();
            }

            elektroniskasIerices.IericesCena = elektroniskasIericesModel.IericesCena;
            elektroniskasIerices.IericesNolietojums = elektroniskasIericesModel.IericesNolietojums;
            elektroniskasIerices.IericesNosaukums = elektroniskasIericesModel.IericesNosaukums;
            elektroniskasIerices.Datums = elektroniskasIericesModel.Datums;

            db.Entry(elektroniskasIerices).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElektroniskasIericesExists(id))
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

        // POST: api/ElektroniskasIerices
        [ResponseType(typeof(ElektroniskasIericesViewModel))]
        public IHttpActionResult PostElektroniskasIerices(ElektroniskasIericesViewModel elektroniskasIericesModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var elektroniskasIerices = new ElektroniskasIerices
            {
                Datums = elektroniskasIericesModel.Datums,
                IericesCena = elektroniskasIericesModel.IericesCena,
                IericesNosaukums = elektroniskasIericesModel.IericesNosaukums,
                IericesNolietojums = elektroniskasIericesModel.IericesNolietojums,
                IericesID = elektroniskasIericesModel.IericesID
            };
            db.ElektroniskasIerices.Add(elektroniskasIerices);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ElektroniskasIericesExists(elektroniskasIerices.IericesID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-ElektroniskasIerices", new { id = elektroniskasIerices.IericesID }, new ElektroniskasIericesViewModel {
                Datums = elektroniskasIerices.Datums,
                IericesCena = elektroniskasIerices.IericesCena,
                IericesNosaukums = elektroniskasIerices.IericesNosaukums,
                IericesNolietojums = elektroniskasIerices.IericesNolietojums,
                IericesID = elektroniskasIerices.IericesID
            });
        }

        // DELETE: api/ElektroniskasIerices/5
        [ResponseType(typeof(ElektroniskasIericesViewModel))]
        public IHttpActionResult DeleteElektroniskasIerices(int id)
        {
            ElektroniskasIerices elektroniskasIerices = db.ElektroniskasIerices.Find(id);
            if (elektroniskasIerices == null)
            {
                return NotFound();
            }

            db.ElektroniskasIerices.Remove(elektroniskasIerices);
            db.SaveChanges();

            return Ok(new ElektroniskasIericesViewModel {
                Datums = elektroniskasIerices.Datums,
                IericesCena = elektroniskasIerices.IericesCena,
                IericesNosaukums = elektroniskasIerices.IericesNosaukums,
                IericesNolietojums = elektroniskasIerices.IericesNolietojums,
                IericesID = elektroniskasIerices.IericesID
            }
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElektroniskasIericesExists(int id)
        {
            return db.ElektroniskasIerices.Count(e => e.IericesID == id) > 0;
        }
    }
}