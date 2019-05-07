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
    public class AtbildigaisController : ApiController
    {
        private DeadPoolModel db = new DeadPoolModel();

        // GET: api/Atbildigais
        public IQueryable<AtbildigaisViewModel> GetAtbildigais()
        {
            return db.Atbildigais.Select(x => new AtbildigaisViewModel {
                AtbildigaisID = x.AtbildigaisID,
                AtbildigaisUzvards = x.AtbildigaisUzvards,
                AtbildigaisVards = x.AtbildigaisVards,
                KabinetaID = x.KabinetaID
            });
        }

        // GET: api/Atbildigais/5
        [ResponseType(typeof(AtbildigaisViewModel))]
        public IHttpActionResult GetAtbildigais(int id)
        {
            Atbildigais atbildigais = db.Atbildigais.Find(id);
            if (atbildigais == null)
            {
                return NotFound();
            }

            return Ok(new AtbildigaisViewModel
            {
                AtbildigaisID = atbildigais.AtbildigaisID,
                KabinetaID = atbildigais.KabinetaID,
                AtbildigaisVards = atbildigais.AtbildigaisVards,
                AtbildigaisUzvards = atbildigais.AtbildigaisUzvards
            });
        }

        // PUT: api/Atbildigais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtbildigais(int id, AtbildigaisViewModel atbildigaisModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atbildigais = db.Atbildigais.FirstOrDefault(x => x.AtbildigaisID == atbildigaisModel.AtbildigaisID );
            if (id != atbildigais.AtbildigaisID)
            {
                return BadRequest();
            }

            db.Entry(atbildigais).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtbildigaisExists(id))
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

        // POST: api/Atbildigais
        [ResponseType(typeof(AtbildigaisViewModel))]
        public IHttpActionResult PostAtbildigais(AtbildigaisViewModel atbildigaisModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var atbildigais = new Atbildigais
            {
                AtbildigaisID = atbildigaisModel.AtbildigaisID,
                AtbildigaisUzvards = atbildigaisModel.AtbildigaisUzvards,
                AtbildigaisVards = atbildigaisModel.AtbildigaisVards,
                KabinetaID = atbildigaisModel.KabinetaID,
                Kabinets = db.Kabinets.FirstOrDefault(x => x.KabinetaID == atbildigaisModel.KabinetaID)
            };
            db.Atbildigais.Add(atbildigais);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AtbildigaisExists(atbildigais.AtbildigaisID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-Atbildigais", new { id = atbildigais.AtbildigaisID }, new AtbildigaisViewModel {
                KabinetaID = atbildigais.KabinetaID,
                AtbildigaisVards = atbildigais.AtbildigaisVards,
                AtbildigaisUzvards = atbildigais.AtbildigaisUzvards,
                AtbildigaisID = atbildigais.AtbildigaisID
            });
        }

        // DELETE: api/Atbildigais/5
        [ResponseType(typeof(AtbildigaisViewModel))]
        public IHttpActionResult DeleteAtbildigais(int id)
        {
            Atbildigais atbildigais = db.Atbildigais.Find(id);
            if (atbildigais == null)
            {
                return NotFound();
            }

            db.Atbildigais.Remove(atbildigais);
            db.SaveChanges();

            return Ok(new AtbildigaisViewModel {
                AtbildigaisID = atbildigais.AtbildigaisID,
                AtbildigaisUzvards = atbildigais.AtbildigaisUzvards,
                AtbildigaisVards = atbildigais.AtbildigaisVards,
                KabinetaID = atbildigais.KabinetaID
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

        private bool AtbildigaisExists(int id)
        {
            return db.Atbildigais.Count(e => e.AtbildigaisID == id) > 0;
        }
    }
}