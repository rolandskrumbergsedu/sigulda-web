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
using Sigulda.WEB.Contexts.batman;

namespace Sigulda.WEB.Controllers.batman
{
    public class SensorsController : ApiController
    {
        private BatmanModel db = new BatmanModel();

        // GET: api/Sensors
        public IQueryable<Sensors> GetSensors()
        {
            return db.Sensors;
        }

        // GET: api/Sensors/5
        [ResponseType(typeof(Sensors))]
        public IHttpActionResult GetSensors(int id)
        {
            Sensors sensors = db.Sensors.Find(id);
            if (sensors == null)
            {
                return NotFound();
            }

            return Ok(sensors);
        }

        // PUT: api/Sensors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSensors(int id, Sensors sensors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sensors.Sensora_ID)
            {
                return BadRequest();
            }

            db.Entry(sensors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorsExists(id))
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

        // POST: api/Sensors
        [ResponseType(typeof(Sensors))]
        public IHttpActionResult PostSensors(Sensors sensors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sensors.Add(sensors);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SensorsExists(sensors.Sensora_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sensors.Sensora_ID }, sensors);
        }

        // DELETE: api/Sensors/5
        [ResponseType(typeof(Sensors))]
        public IHttpActionResult DeleteSensors(int id)
        {
            Sensors sensors = db.Sensors.Find(id);
            if (sensors == null)
            {
                return NotFound();
            }

            db.Sensors.Remove(sensors);
            db.SaveChanges();

            return Ok(sensors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SensorsExists(int id)
        {
            return db.Sensors.Count(e => e.Sensora_ID == id) > 0;
        }
    }
}