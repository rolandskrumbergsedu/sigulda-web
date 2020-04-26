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

namespace Sigulda.WEB.Controllers.deadpool
{
    public class KabinetaInventarsController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/KabinetaInventars
        public IQueryable<Kabineta_inventars2> GetKabineta_inventars2()
        {
            return db.Kabineta_inventars2;
        }

        // GET: api/KabinetaInventars/5
        [ResponseType(typeof(Kabineta_inventars2))]
        public IHttpActionResult GetKabineta_inventars2(int id)
        {
            Kabineta_inventars2 kabineta_inventars2 = db.Kabineta_inventars2.Find(id);
            if (kabineta_inventars2 == null)
            {
                return NotFound();
            }

            return Ok(kabineta_inventars2);
        }

        // PUT: api/KabinetaInventars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKabineta_inventars2(int id, Kabineta_inventars2 kabineta_inventars2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kabineta_inventars2.inventara_kabineta_id)
            {
                return BadRequest();
            }

            db.Entry(kabineta_inventars2).State = EntityState.Modified;

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
        [ResponseType(typeof(Kabineta_inventars2))]
        public IHttpActionResult PostKabineta_inventars2(Kabineta_inventars2 kabineta_inventars2)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kabineta_inventars2.Add(kabineta_inventars2);

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
        [ResponseType(typeof(Kabineta_inventars2))]
        public IHttpActionResult DeleteKabineta_inventars2(int id)
        {
            Kabineta_inventars2 kabineta_inventars2 = db.Kabineta_inventars2.Find(id);
            if (kabineta_inventars2 == null)
            {
                return NotFound();
            }

            db.Kabineta_inventars2.Remove(kabineta_inventars2);
            db.SaveChanges();

            return Ok(kabineta_inventars2);
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