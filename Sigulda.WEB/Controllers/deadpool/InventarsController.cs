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
    public class InventarsController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/Inventars
        public IQueryable<InventarsViewModel> GetInventars()
        {
            return db.Inventars.Select(x => new InventarsViewModel {
            Cena = x.Cena,
            Datums = x.Datums,
            InventaraID = x.InventaraID,
            InvNosaukums = x.InvNosaukums,
            Nolietojums = x.Nolietojums
            });
        }

        // GET: api/Inventars/5
        [ResponseType(typeof(InventarsViewModel))]
        public IHttpActionResult GetInventars(int id)
        {
            Inventars inventars = db.Inventars.Find(id);
            if (inventars == null)
            {
                return NotFound();
            }

            return Ok(new InventarsViewModel {
                Nolietojums = inventars.Nolietojums,
                InvNosaukums = inventars.InvNosaukums,
                InventaraID = inventars.InventaraID,
                Datums = inventars.Datums,
                Cena = inventars.Cena
            });
        }

        // PUT: api/Inventars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventars(int id, InventarsViewModel inventarsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventars = db.Inventars.FirstOrDefault(x => x.InventaraID == inventarsModel.InventaraID);
            if (id != inventars.InventaraID)
            {
                return BadRequest();
            }
            inventars.InvNosaukums = inventarsModel.InvNosaukums;
            inventars.Nolietojums = inventarsModel.Nolietojums;
            inventars.Datums = inventarsModel.Datums;
            inventars.Cena = inventarsModel.Cena;

            db.Entry(inventars).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarsExists(id))
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

        // POST: api/Inventars
        [ResponseType(typeof(InventarsViewModel))]
        public IHttpActionResult PostInventars(InventarsViewModel inventarsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventars = new Inventars
            {
                Cena = inventarsModel.Cena,
                Datums = inventarsModel.Datums,
                Nolietojums = inventarsModel.Nolietojums,
                InvNosaukums = inventarsModel.InvNosaukums,
                InventaraID = inventarsModel.InventaraID
            };
            db.Inventars.Add(inventars);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InventarsExists(inventars.InventaraID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-Inventars", new { id = inventars.InventaraID }, new InventarsViewModel {
                Cena = inventarsModel.Cena,
                Datums = inventarsModel.Datums,
                Nolietojums = inventarsModel.Nolietojums,
                InvNosaukums = inventarsModel.InvNosaukums,
                InventaraID = inventarsModel.InventaraID
            });
        }

        // DELETE: api/Inventars/5
        [ResponseType(typeof(InventarsViewModel))]
        public IHttpActionResult DeleteInventars(int id)
        {
            Inventars inventars = db.Inventars.Find(id);
            if (inventars == null)
            {
                return NotFound();
            }

            db.Inventars.Remove(inventars);
            db.SaveChanges();

            return Ok(new InventarsViewModel {
                Cena = inventars.Cena,
                Datums = inventars.Datums,
                Nolietojums = inventars.Nolietojums,
                InvNosaukums = inventars.InvNosaukums,
                InventaraID = inventars.InventaraID
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

        private bool InventarsExists(int id)
        {
            return db.Inventars.Count(e => e.InventaraID == id) > 0;
        }
    }
}