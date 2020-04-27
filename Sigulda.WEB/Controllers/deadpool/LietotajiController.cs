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
    public class LietotajiController : ApiController
    {
        private Deadpool db = new Deadpool();

        // GET: api/Lietotaji
        public IQueryable<LietotajsViewModel> GetLietotaji1()
        {
            return db.Lietotaji1.Select(_ => new LietotajsViewModel
            {
                epasts = _.epasts,
                parole = _.parole,
                personas_kods = _.personas_kods,
                skolotajs = _.skolotajs,
                uzvards = _.uzvards,
                vards = _.vards
            });
        }

        // GET: api/Lietotaji/5
        [ResponseType(typeof(LietotajsViewModel))]
        public IHttpActionResult GetLietotaji1(int id)
        {
            Lietotaji1 lietotaji1 = db.Lietotaji1.Find(id);
            if (lietotaji1 == null)
            {
                return NotFound();
            }

            return Ok(new LietotajsViewModel
            {
                epasts = lietotaji1.epasts,
                parole = lietotaji1.parole,
                personas_kods = lietotaji1.personas_kods,
                skolotajs = lietotaji1.skolotajs,
                uzvards = lietotaji1.uzvards,
                vards = lietotaji1.vards
            });
        }

        // PUT: api/Lietotaji/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLietotaji1(int id, LietotajsViewModel lietotaji1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lietotaji1.lietotajs_id)
            {
                return BadRequest();
            }

            var dbLietotajs = db.Lietotaji1.FirstOrDefault(_ => _.lietotajs_id == lietotaji1.lietotajs_id);

            if (dbLietotajs == null)
            {
                return NotFound();
            }

            dbLietotajs.vards = lietotaji1.vards;
            dbLietotajs.uzvards = lietotaji1.uzvards;
            dbLietotajs.skolotajs = lietotaji1.skolotajs;
            dbLietotajs.personas_kods = lietotaji1.personas_kods;
            dbLietotajs.parole = lietotaji1.parole;
            dbLietotajs.epasts = lietotaji1.epasts;

            db.Entry(dbLietotajs).State = EntityState.Modified;
            

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lietotaji1Exists(id))
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

        // POST: api/Lietotaji
        [ResponseType(typeof(LietotajsViewModel))]
        public IHttpActionResult PostLietotaji1(LietotajsViewModel lietotaji1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lietotajs = new Lietotaji1
            {
                lietotajs_id = lietotaji1.lietotajs_id,
                epasts = lietotaji1.epasts,
                vards = lietotaji1.vards,
                uzvards = lietotaji1.uzvards,
                parole = lietotaji1.parole,
                personas_kods = lietotaji1.personas_kods,
                skolotajs = lietotaji1.skolotajs
            };

            db.Lietotaji1.Add(lietotajs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Lietotaji1Exists(lietotajs.lietotajs_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DeadpoolApi-LietotajiController", new { id = lietotaji1.lietotajs_id }, lietotaji1);
        }

        // DELETE: api/Lietotaji/5
        [ResponseType(typeof(LietotajsViewModel))]
        public IHttpActionResult DeleteLietotaji1(int id)
        {
            Lietotaji1 lietotaji1 = db.Lietotaji1.Find(id);
            if (lietotaji1 == null)
            {
                return NotFound();
            }

            db.Lietotaji1.Remove(lietotaji1);
            db.SaveChanges();

            return Ok(new LietotajsViewModel
            {
                epasts = lietotaji1.epasts,
                parole = lietotaji1.parole,
                personas_kods = lietotaji1.personas_kods,
                skolotajs = lietotaji1.skolotajs,
                uzvards = lietotaji1.uzvards,
                vards = lietotaji1.vards
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

        private bool Lietotaji1Exists(int id)
        {
            return db.Lietotaji1.Count(e => e.lietotajs_id == id) > 0;
        }
    }
}