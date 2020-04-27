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
    public class KabinetiController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/Kabineti
        public IQueryable<KabinetiViewModel> GetKabineti1()
        {
            return db.Kabineti1.Select(_ => new KabinetiViewModel
            {
                kabineta_id = _.kabineta_id,
                atrasanas_vieta = _.atrasanas_vieta,
                kabineta_nummurs = _.kabineta_nummurs,
                skolotajs_id = _.skolotajs_id
            });
        }

        // GET: api/Kabineti/5
        [ResponseType(typeof(KabinetiViewModel))]
        public IHttpActionResult GetKabineti1(int id)
        {
            Kabineti1 kabineti1 = db.Kabineti1.Find(id);
            if (kabineti1 == null)
            {
                return NotFound();
            }

            return Ok(new KabinetiViewModel
            {
                kabineta_id = kabineti1.kabineta_id,
                atrasanas_vieta = kabineti1.atrasanas_vieta,
                kabineta_nummurs = kabineti1.kabineta_nummurs,
                skolotajs_id = kabineti1.skolotajs_id
            });
        }

        // PUT: api/Kabineti/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabineti1(int id, KabinetiViewModel kabineti1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabineti1.kabineta_id)
            {
                return BadRequest();
            }

            var entry = db.Kabineti1.FirstOrDefault(_ => _.kabineta_id == kabineti1.kabineta_id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.kabineta_nummurs = kabineti1.kabineta_nummurs;
            entry.skolotajs_id = kabineti1.skolotajs_id;
            entry.atrasanas_vieta = kabineti1.atrasanas_vieta;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Kabineti1Exists(id))
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

        // POST: api/Kabineti
        [ResponseType(typeof(KabinetiViewModel))]
        public IHttpActionResult PostKabineti1(KabinetiViewModel kabineti1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kabineti1.Add(new Kabineti1
            {
                kabineta_nummurs = kabineti1.kabineta_nummurs,
                kabineta_id = kabineti1.kabineta_id,
                skolotajs_id = kabineti1.skolotajs_id,
                atrasanas_vieta = kabineti1.atrasanas_vieta
            });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Kabineti1Exists(kabineti1.kabineta_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-KabinetiController", new { id = kabineti1.kabineta_id }, kabineti1);
        }

        // DELETE: api/Kabineti/5
        [ResponseType(typeof(KabinetiViewModel))]
        public IHttpActionResult DeleteKabineti1(int id)
        {
            Kabineti1 kabineti1 = db.Kabineti1.Find(id);
            if (kabineti1 == null)
            {
                return NotFound();
            }

            db.Kabineti1.Remove(kabineti1);
            db.SaveChanges();

            return Ok(new KabinetiViewModel
            {
                kabineta_id = kabineti1.kabineta_id,
                atrasanas_vieta = kabineti1.atrasanas_vieta,
                skolotajs_id = kabineti1.skolotajs_id,
                kabineta_nummurs = kabineti1.kabineta_nummurs
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

        private bool Kabineti1Exists(int id)
        {
            return db.Kabineti1.Count(e => e.kabineta_id == id) > 0;
        }
    }
}