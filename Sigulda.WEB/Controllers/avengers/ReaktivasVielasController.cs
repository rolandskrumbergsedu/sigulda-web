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
using Sigulda.WEB.Contexts.avengers;

namespace Sigulda.WEB.Controllers.avengers
{
    public class ReaktivasVielasController : ApiController
    {
        private AvengersModel db = new AvengersModel();

        // GET: api/ReaktivasVielas
        public IQueryable<Reaktivas_Viela> GetReaktivas_Vielas()
        {
            return db.Reaktivas_Vielas;
        }

        // GET: api/ReaktivasVielas/5
        [ResponseType(typeof(Reaktivas_Viela))]
        public IHttpActionResult GetReaktivas_Viela(int id)
        {
            Reaktivas_Viela reaktivas_Viela = db.Reaktivas_Vielas.Find(id);
            if (reaktivas_Viela == null)
            {
                return NotFound();
            }

            return Ok(reaktivas_Viela);
        }

        // PUT: api/ReaktivasVielas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReaktivas_Viela(int id, Reaktivas_Viela reaktivas_Viela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reaktivas_Viela.ReaktivasVielasID)
            {
                return BadRequest();
            }

            db.Entry(reaktivas_Viela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Reaktivas_VielaExists(id))
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

        // POST: api/ReaktivasVielas
        [ResponseType(typeof(Reaktivas_Viela))]
        public IHttpActionResult PostReaktivas_Viela(Reaktivas_Viela reaktivas_Viela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reaktivas_Vielas.Add(reaktivas_Viela);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Reaktivas_VielaExists(reaktivas_Viela.ReaktivasVielasID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("AvengersApi-ReaktivasVielas", new { id = reaktivas_Viela.ReaktivasVielasID }, reaktivas_Viela);
        }

        // DELETE: api/ReaktivasVielas/5
        [ResponseType(typeof(Reaktivas_Viela))]
        public IHttpActionResult DeleteReaktivas_Viela(int id)
        {
            Reaktivas_Viela reaktivas_Viela = db.Reaktivas_Vielas.Find(id);
            if (reaktivas_Viela == null)
            {
                return NotFound();
            }

            db.Reaktivas_Vielas.Remove(reaktivas_Viela);
            db.SaveChanges();

            return Ok(reaktivas_Viela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Reaktivas_VielaExists(int id)
        {
            return db.Reaktivas_Vielas.Count(e => e.ReaktivasVielasID == id) > 0;
        }
    }
}