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
using Sigulda.WEB.Contexts.wolverine;
using Sigulda.WEB.Controllers.wolverine.ViewModels;

namespace Sigulda.WEB.Controllers.wolverine
{
    public class TransportlidzekliController : ApiController
    {
        private WolverineModel db = new WolverineModel();

        // GET: api/Transportlidzekli
        public IQueryable<TransportlidzekliViewModel> GetTransportlidzeklis()
        {
            return db.Transportlidzeklis.Select(transportlidzekli => new TransportlidzekliViewModel
            {
                Gads = transportlidzekli.Gads,
                Ipasnieks = transportlidzekli.Ipasnieks,
                Marka = transportlidzekli.Marka,
                Max_airu_ietilpiba = transportlidzekli.Max_airu_ietilpiba,
                Max_cilv_ietilpiba = transportlidzekli.Max_cilv_ietilpiba,
                Max_vestu_ietilpiba = transportlidzekli.Max_vestu_ietilpiba,
                Modelis = transportlidzekli.Modelis,
                Numurzime = transportlidzekli.Numurzime,
                PIekabe = transportlidzekli.PIekabe,
                TransportaID = transportlidzekli.TransportaID
            });
        }

        // GET: api/Transportlidzekli/5
        [ResponseType(typeof(TransportlidzekliViewModel))]
        public IHttpActionResult GetTransportlidzekli(int id)
        {
            Transportlidzekli transportlidzekli = db.Transportlidzeklis.Find(id);
            if (transportlidzekli == null)
            {
                return NotFound();
            }

            return Ok(new TransportlidzekliViewModel
            {
                Gads = transportlidzekli.Gads,
                Ipasnieks = transportlidzekli.Ipasnieks,
                Marka = transportlidzekli.Marka,
                Max_airu_ietilpiba = transportlidzekli.Max_airu_ietilpiba,
                Max_cilv_ietilpiba = transportlidzekli.Max_cilv_ietilpiba,
                Max_vestu_ietilpiba = transportlidzekli.Max_vestu_ietilpiba,
                Modelis = transportlidzekli.Modelis,
                Numurzime = transportlidzekli.Numurzime,
                PIekabe = transportlidzekli.PIekabe,
                TransportaID = transportlidzekli.TransportaID
            });
        }

        // PUT: api/Transportlidzekli/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTransportlidzekli(int id, TransportlidzekliViewModel transportlidzekli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transportlidzekli.TransportaID)
            {
                return BadRequest();
            }

            var entry = db.Transportlidzeklis.FirstOrDefault(_ => _.TransportaID == transportlidzekli.TransportaID);
            if (entry == null)
            {
                return NotFound();
            }
            entry.Ipasnieks = transportlidzekli.Ipasnieks;
            entry.Marka = transportlidzekli.Marka;
            entry.Modelis = transportlidzekli.Modelis;
            entry.Gads = transportlidzekli.Gads;
            entry.Max_cilv_ietilpiba = transportlidzekli.Max_cilv_ietilpiba;
            entry.Max_airu_ietilpiba = transportlidzekli.Max_airu_ietilpiba;
            entry.Max_vestu_ietilpiba = transportlidzekli.Max_vestu_ietilpiba;
            entry.PIekabe = transportlidzekli.PIekabe;
            entry.Numurzime = transportlidzekli.Numurzime;

            db.Entry(entry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportlidzekliExists(id))
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

        // POST: api/Transportlidzekli
        [ResponseType(typeof(TransportlidzekliViewModel))]
        public IHttpActionResult PostTransportlidzekli(TransportlidzekliViewModel transportlidzekli)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transportlidzeklis.Add(new Transportlidzekli
            {
                Ipasnieks = transportlidzekli.Ipasnieks,
                Marka = transportlidzekli.Marka,
                Modelis = transportlidzekli.Modelis,
                Gads = transportlidzekli.Gads,
                Max_cilv_ietilpiba = transportlidzekli.Max_cilv_ietilpiba,
                Max_airu_ietilpiba = transportlidzekli.Max_airu_ietilpiba,
                Max_vestu_ietilpiba = transportlidzekli.Max_vestu_ietilpiba,
                PIekabe = transportlidzekli.PIekabe,
                Numurzime = transportlidzekli.Numurzime,
                TransportaID = transportlidzekli.TransportaID
        });

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransportlidzekliExists(transportlidzekli.TransportaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("WolverineApi-TransportlidzekliController", new { id = transportlidzekli.TransportaID }, transportlidzekli);
        }

        // DELETE: api/Transportlidzekli/5
        [ResponseType(typeof(TransportlidzekliViewModel))]
        public IHttpActionResult DeleteTransportlidzekli(int id)
        {
            Transportlidzekli transportlidzekli = db.Transportlidzeklis.Find(id);
            if (transportlidzekli == null)
            {
                return NotFound();
            }

            db.Transportlidzeklis.Remove(transportlidzekli);
            db.SaveChanges();

            return Ok(new TransportlidzekliViewModel
            {
                Gads = transportlidzekli.Gads,
                Ipasnieks = transportlidzekli.Ipasnieks,
                Marka = transportlidzekli.Marka,
                Max_airu_ietilpiba = transportlidzekli.Max_airu_ietilpiba,
                Max_cilv_ietilpiba = transportlidzekli.Max_cilv_ietilpiba,
                Max_vestu_ietilpiba = transportlidzekli.Max_vestu_ietilpiba,
                Modelis = transportlidzekli.Modelis,
                Numurzime = transportlidzekli.Numurzime,
                PIekabe = transportlidzekli.PIekabe,
                TransportaID = transportlidzekli.TransportaID
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

        private bool TransportlidzekliExists(int id)
        {
            return db.Transportlidzeklis.Count(e => e.TransportaID == id) > 0;
        }
    }
}