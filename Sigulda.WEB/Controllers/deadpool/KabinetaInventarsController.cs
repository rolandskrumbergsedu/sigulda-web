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
    public class KabinetaInventarsController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/KabinetaInventars
        public IQueryable<KabinetaInventarsViewModel> GetKabineta_inventars2()
        {
            return db.Kabineta_inventars2.Select(_ => new KabinetaInventarsViewModel
            {
                inventara_kabineta_id = _.inventara_kabineta_id,
                Kabineta_id = _.Kabineta_id,
                tipa_kods = _.tipa_kods
            });
        }

        // GET: api/KabinetaInventars/5
        [ResponseType(typeof(KabinetaInventarsViewModel))]
        public IHttpActionResult GetKabineta_inventars2(int id)
        {
            Kabineta_inventars2 kabineta_inventars2 = db.Kabineta_inventars2.Find(id);
            if (kabineta_inventars2 == null)
            {
                return NotFound();
            }

            return Ok(new KabinetaInventarsViewModel
            {
                inventara_kabineta_id = kabineta_inventars2.inventara_kabineta_id,
                Kabineta_id = kabineta_inventars2.Kabineta_id,
                tipa_kods = kabineta_inventars2.tipa_kods
            });
        }

        // PUT: api/KabinetaInventars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabineta_inventars2(int id, KabinetaInventarsViewModel kabineta_inventars2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabineta_inventars2.inventara_kabineta_id)
            {
                return BadRequest();
            }

            var entry = db.Kabineta_inventars2.FirstOrDefault(_ => _.inventara_kabineta_id == kabineta_inventars2.inventara_kabineta_id);
            if (entry == null)
            {
                return NotFound();
            }

            entry.Kabineta_id = kabineta_inventars2.Kabineta_id;
            entry.tipa_kods = kabineta_inventars2.tipa_kods;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Kabineta_inventars2Exists(id))
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

        // POST: api/KabinetaInventars
        [ResponseType(typeof(KabinetaInventarsViewModel))]
        public IHttpActionResult PostKabineta_inventars2(KabinetaInventarsViewModel kabineta_inventars2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = new Kabineta_inventars2
            {
                inventara_kabineta_id = kabineta_inventars2.inventara_kabineta_id,
                Kabineta_id = kabineta_inventars2.Kabineta_id,
                tipa_kods = kabineta_inventars2.tipa_kods
            };
            db.Kabineta_inventars2.Add(entry);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Kabineta_inventars2Exists(kabineta_inventars2.inventara_kabineta_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-KabinetaInventarsController", new { id = kabineta_inventars2.inventara_kabineta_id }, kabineta_inventars2);
        }

        // DELETE: api/KabinetaInventars/5
        [ResponseType(typeof(KabinetaInventarsViewModel))]
        public IHttpActionResult DeleteKabineta_inventars2(int id)
        {
            Kabineta_inventars2 kabineta_inventars2 = db.Kabineta_inventars2.Find(id);
            if (kabineta_inventars2 == null)
            {
                return NotFound();
            }

            db.Kabineta_inventars2.Remove(kabineta_inventars2);
            db.SaveChanges();

            return Ok(new KabinetaInventarsViewModel
            {
                inventara_kabineta_id = kabineta_inventars2.inventara_kabineta_id,
                Kabineta_id = kabineta_inventars2.Kabineta_id,
                tipa_kods = kabineta_inventars2.tipa_kods
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

        private bool Kabineta_inventars2Exists(int id)
        {
            return db.Kabineta_inventars2.Count(e => e.inventara_kabineta_id == id) > 0;
        }
    }
}