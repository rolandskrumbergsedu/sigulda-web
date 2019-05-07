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
    public class MacibuStundasController : ApiController
    {
        private CaptainAmericaModel db = new CaptainAmericaModel();

        // GET: api/MacibuStundas
        public IQueryable<MacibuStundaViewModel> GetMacibu_stunda()
        {
            return db.Macibu_stunda.Select(x => new MacibuStundaViewModel
            {
                Datums = x.Datums,
                Kabineta_nr = x.Kabineta_nr,
                Klase_ID = x.Klase_ID,
                Piezime = x.Piezime,
                Prieksmets_ID = x.Prieksmets_ID,
                Stundas_nr = x.Stundas_nr,
                Stunda_ID = x.Stunda_ID,
                Tema_ID = x.Tema_ID
            });
        }

        // GET: api/MacibuStundas/5
        [ResponseType(typeof(MacibuStundaViewModel))]
        public IHttpActionResult GetMacibuStunda(int id)
        {
            MacibuStunda x = db.Macibu_stunda.Find(id);
            if (x == null)
            {
                return NotFound();
            }

            return Ok(new MacibuStundaViewModel
            {
                Datums = x.Datums,
                Kabineta_nr = x.Kabineta_nr,
                Klase_ID = x.Klase_ID,
                Piezime = x.Piezime,
                Prieksmets_ID = x.Prieksmets_ID,
                Stundas_nr = x.Stundas_nr,
                Stunda_ID = x.Stunda_ID,
                Tema_ID = x.Tema_ID
            });
        }

        // PUT: api/MacibuStundas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMacibuStunda(int id, MacibuStundaViewModel macibuStundaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var macibuStunda = db.Macibu_stunda.FirstOrDefault(x => x.Stunda_ID == macibuStundaModel.Stunda_ID);
            if (id != macibuStunda.Stunda_ID)
            {
                return BadRequest();
            }

            macibuStunda.Datums = macibuStundaModel.Datums;
            macibuStunda.Kabineta_nr = macibuStundaModel.Kabineta_nr;
            macibuStunda.Klase_ID = macibuStundaModel.Klase_ID;
            macibuStunda.Piezime = macibuStundaModel.Piezime;
            macibuStunda.Prieksmets_ID = macibuStundaModel.Prieksmets_ID;
            macibuStunda.Stundas_nr = macibuStundaModel.Stundas_nr;
            macibuStunda.Stunda_ID = macibuStundaModel.Stunda_ID;
            macibuStunda.Tema_ID = macibuStundaModel.Tema_ID;
            macibuStunda.Klase = db.Klases.FirstOrDefault(x => x.Klase_ID == macibuStundaModel.Klase_ID);
            macibuStunda.Macibu_prieksmets = db.Macibu_prieksmets.FirstOrDefault(x => x.Prieksmets_ID == macibuStundaModel.Prieksmets_ID);
            macibuStunda.StundasTema = db.StundasTemas.FirstOrDefault(x => x.Tema_ID == macibuStundaModel.Tema_ID);
            db.Entry(macibuStunda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacibuStundaExists(id))
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

        // POST: api/MacibuStundas
        [ResponseType(typeof(MacibuStundaViewModel))]
        public IHttpActionResult PostMacibuStunda(MacibuStundaViewModel macibuStundaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var macibuStunda = new MacibuStunda
            {
                Datums = macibuStundaModel.Datums,
                Kabineta_nr = macibuStundaModel.Kabineta_nr,
                Klase_ID = macibuStundaModel.Klase_ID,
                Piezime = macibuStundaModel.Piezime,
                Prieksmets_ID = macibuStundaModel.Prieksmets_ID,
                Stundas_nr = macibuStundaModel.Stundas_nr,
                Stunda_ID = macibuStundaModel.Stunda_ID,
                Tema_ID = macibuStundaModel.Tema_ID,
                Klase = db.Klases.FirstOrDefault(x => x.Klase_ID == macibuStundaModel.Klase_ID),
                Macibu_prieksmets = db.Macibu_prieksmets.FirstOrDefault(x => x.Prieksmets_ID == macibuStundaModel.Prieksmets_ID),
                StundasTema = db.StundasTemas.FirstOrDefault(x => x.Tema_ID == macibuStundaModel.Tema_ID),
            };
            db.Macibu_stunda.Add(macibuStunda);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MacibuStundaExists(macibuStunda.Stunda_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("CaptinAmericaApi-MacibuStunda", new { id = macibuStunda.Stunda_ID }, new MacibuStundaViewModel {
                Datums = macibuStundaModel.Datums,
                Kabineta_nr = macibuStundaModel.Kabineta_nr,
                Klase_ID = macibuStundaModel.Klase_ID,
                Piezime = macibuStundaModel.Piezime,
                Prieksmets_ID = macibuStundaModel.Prieksmets_ID,
                Stundas_nr = macibuStundaModel.Stundas_nr,
                Stunda_ID = macibuStundaModel.Stunda_ID,
                Tema_ID = macibuStundaModel.Tema_ID,
            });
        }

        // DELETE: api/MacibuStundas/5
        [ResponseType(typeof(MacibuStundaViewModel))]
        public IHttpActionResult DeleteMacibuStunda(int id)
        {
            MacibuStunda macibuStunda = db.Macibu_stunda.Find(id);
            if (macibuStunda == null)
            {
                return NotFound();
            }

            db.Macibu_stunda.Remove(macibuStunda);
            db.SaveChanges();

            return Ok(new MacibuStundaViewModel
            {
                Datums = macibuStunda.Datums,
                Kabineta_nr = macibuStunda.Kabineta_nr,
                Klase_ID = macibuStunda.Klase_ID,
                Piezime = macibuStunda.Piezime,
                Prieksmets_ID = macibuStunda.Prieksmets_ID,
                Stundas_nr = macibuStunda.Stundas_nr,
                Stunda_ID = macibuStunda.Stunda_ID,
                Tema_ID = macibuStunda.Tema_ID,
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

        private bool MacibuStundaExists(int id)
        {
            return db.Macibu_stunda.Count(e => e.Stunda_ID == id) > 0;
        }
    }
}