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
    public class KabinetsController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/Kabinets
        public IQueryable<KabinetsViewModel> GetKabinets()
        {
            return db.Kabinets.Select(x => new KabinetsViewModel
            {
                AtbildigaisID = x.AtbildigaisID,
                IericesID = x.IericesID,
                InventaraID = x.InventaraID,
                KabinetaID = x.KabinetaID
            });
        }

        // GET: api/Kabinets/5
        [ResponseType(typeof(KabinetsViewModel))]
        public IHttpActionResult GetKabinets(int id)
        {
            Kabinets kabinets = db.Kabinets.Find(id);
            if (kabinets == null)
            {
                return NotFound();
            }

            return Ok(new KabinetsViewModel
            {
                KabinetaID = kabinets.KabinetaID,
                InventaraID = kabinets.InventaraID,
                IericesID = kabinets.IericesID,
                AtbildigaisID = kabinets.AtbildigaisID
            });
        }

        // PUT: api/Kabinets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabinets(int id, KabinetsViewModel kabinetsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kabinets = db.Kabinets.FirstOrDefault(x => x.KabinetaID == kabinetsModel.KabinetaID);
            if (id != kabinets.KabinetaID)
            {
                return BadRequest();
            }

            kabinets.InventaraID = kabinetsModel.InventaraID;
            kabinets.Inventars = db.Inventars.FirstOrDefault(x => x.InventaraID == kabinetsModel.InventaraID);
            kabinets.IericesID = kabinetsModel.IericesID;
            kabinets.ElektroniskasIerices = db.ElektroniskasIerices.FirstOrDefault(x => x.IericesID == kabinetsModel.IericesID);
            kabinets.AtbildigaisID = kabinetsModel.AtbildigaisID;
            kabinets.Atbildigais1 = db.Atbildigais.FirstOrDefault(x => x.AtbildigaisID == kabinetsModel.AtbildigaisID);
            db.Entry(kabinets).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KabinetsExists(id))
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

        // POST: api/Kabinets
        [ResponseType(typeof(KabinetsViewModel))]
        public IHttpActionResult PostKabinets(KabinetsViewModel kabinetsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kabinets = new Kabinets
            {
                InventaraID = kabinetsModel.InventaraID,
                Inventars = db.Inventars.FirstOrDefault(x => x.InventaraID == kabinetsModel.InventaraID),
                IericesID = kabinetsModel.IericesID,
                ElektroniskasIerices = db.ElektroniskasIerices.FirstOrDefault(x => x.IericesID == kabinetsModel.IericesID),
                AtbildigaisID = kabinetsModel.AtbildigaisID,
                Atbildigais1 = db.Atbildigais.FirstOrDefault(x => x.AtbildigaisID == kabinetsModel.AtbildigaisID)
            };
            db.Kabinets.Add(kabinets);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KabinetsExists(kabinets.KabinetaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-Kabinets", new { id = kabinets.KabinetaID }, kabinets);
        }

        // DELETE: api/Kabinets/5
        [ResponseType(typeof(KabinetsViewModel))]
        public IHttpActionResult DeleteKabinets(int id)
        {
            Kabinets kabinets = db.Kabinets.Find(id);
            if (kabinets == null)
            {
                return NotFound();
            }

            db.Kabinets.Remove(kabinets);
            db.SaveChanges();

            return Ok(new KabinetsViewModel {
                AtbildigaisID = kabinets.AtbildigaisID,
                IericesID = kabinets.IericesID,
                InventaraID = kabinets.InventaraID,
                KabinetaID = kabinets.KabinetaID
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

        private bool KabinetsExists(int id)
        {
            return db.Kabinets.Count(e => e.KabinetaID == id) > 0;
        }
    }
}