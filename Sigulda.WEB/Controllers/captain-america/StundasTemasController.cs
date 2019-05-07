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
using Sigulda.WEB.Contexts.captain_america;
using Sigulda.WEB.Controllers.captain_america.ViewModels;

namespace Sigulda.WEB.Controllers.captain_america
{
    public class StundasTemasController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/StundasTemas
        public IQueryable<StundasTemaViewModel> GetStundasTemas()
        {
            return db.StundasTemas.Select(x => new StundasTemaViewModel {
                Tema_ID = x.Tema_ID,
                Tema = x.Tema,
                Piezime = x.Piezime
            });
        }

        // GET: api/StundasTemas/5
        [ResponseType(typeof(StundasTemaViewModel))]
        public IHttpActionResult GetStundasTema(int id)
        {
            StundasTema stundasTema = db.StundasTemas.Find(id);
            if (stundasTema == null)
            {
                return NotFound();
            }

            return Ok(new StundasTemaViewModel {
                Tema_ID = stundasTema.Tema_ID,
                Tema = stundasTema.Tema,
                Piezime = stundasTema.Piezime
            });
        }

        // PUT: api/StundasTemas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStundasTema(int id, StundasTemaViewModel stundasTemaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stundasTema = db.StundasTemas.FirstOrDefault(x => x.Tema_ID == stundasTemaModel.Tema_ID);
            if (id != stundasTema.Tema_ID)
            {
                return BadRequest();
            }
            stundasTema.Tema = stundasTemaModel.Tema;
            stundasTema.Piezime = stundasTemaModel.Piezime;
            db.Entry(stundasTema).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StundasTemaExists(id))
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

        // POST: api/StundasTemas
        [ResponseType(typeof(StundasTemaViewModel))]
        public IHttpActionResult PostStundasTema(StundasTemaViewModel stundasTemaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stundasTema = new StundasTema
            {
                Tema_ID = stundasTemaModel.Tema_ID,
                Tema = stundasTemaModel.Tema,
                Piezime = stundasTemaModel.Piezime
            };
            db.StundasTemas.Add(stundasTema);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StundasTemaExists(stundasTema.Tema_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("CaptinAmericaApi-StundasTema", new { id = stundasTema.Tema_ID }, new StundasTemaViewModel {
                Tema_ID = stundasTema.Tema_ID,
                Tema = stundasTema.Tema,
                Piezime = stundasTema.Piezime
            });
        }

        // DELETE: api/StundasTemas/5
        [ResponseType(typeof(StundasTemaViewModel))]
        public IHttpActionResult DeleteStundasTema(int id)
        {
            StundasTema stundasTema = db.StundasTemas.Find(id);
            if (stundasTema == null)
            {
                return NotFound();
            }

            db.StundasTemas.Remove(stundasTema);
            db.SaveChanges();

            return Ok(new StundasTemaViewModel {
                Tema_ID = stundasTema.Tema_ID,
                Tema = stundasTema.Tema,
                Piezime = stundasTema.Piezime
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

        private bool StundasTemaExists(int id)
        {
            return db.StundasTemas.Count(e => e.Tema_ID == id) > 0;
        }
    }
}