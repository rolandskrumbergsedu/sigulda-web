using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Sigulda.WEB.Contexts.batman;

namespace Sigulda.WEB.Controllers.batman
{
    public class KomponentesController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/Komponentes
        public IQueryable<Komponentes> GetKomponentes11()
        {
            return db.Komponentes;
        }

        // GET: api/Komponentes/5
        [ResponseType(typeof(Komponentes))]
        public IHttpActionResult GetKomponentes(int id)
        {
            Komponentes komponentes = db.Komponentes.Find(id);
            if (komponentes == null)
            {
                return NotFound();
            }

            return Ok(komponentes);
        }

        // PUT: api/Komponentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKomponentes(int id, Komponentes komponentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != komponentes.Enerģijas_komponente_ID)
            {
                return BadRequest();
            }

            db.Entry(komponentes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomponentesExists(id))
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

        // POST: api/Komponentes
        [ResponseType(typeof(Komponentes))]
        public IHttpActionResult PostKomponentes(Komponentes komponentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Komponentes.Add(komponentes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KomponentesExists(komponentes.Enerģijas_komponente_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = komponentes.Enerģijas_komponente_ID }, komponentes);
        }

        // DELETE: api/Komponentes/5
        [ResponseType(typeof(Komponentes))]
        public IHttpActionResult DeleteKomponentes(int id)
        {
            Komponentes komponentes = db.Komponentes.Find(id);
            if (komponentes == null)
            {
                return NotFound();
            }

            db.Komponentes.Remove(komponentes);
            db.SaveChanges();

            return Ok(komponentes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KomponentesExists(int id)
        {
            return db.Komponentes.Count(e => e.Enerģijas_komponente_ID == id) > 0;
        }
    }
}