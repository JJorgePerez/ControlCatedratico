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
using Principal;

namespace finalFase2.Controllers
{
    public class catedraticoesController : ApiController
    {
        private examenfinalEntities db = new examenfinalEntities();

        // GET: api/catedraticoes
        public IQueryable<catedratico> Getcatedratico()
        {
            return db.catedratico;
        }

        // GET: api/catedraticoes/5
        [ResponseType(typeof(catedratico))]
        public IHttpActionResult Getcatedratico(int id)
        {
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return NotFound();
            }

            return Ok(catedratico);
        }

        // PUT: api/catedraticoes/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage Put([FromBody] catedratico Clien)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (examenfinalEntities entities = new examenfinalEntities())
                {
                    entities.Entry(Clien).State = System.Data.Entity.EntityState.Modified;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

        // POST: api/catedraticoes
        [ResponseType(typeof(catedratico))]
        public IHttpActionResult Postcatedratico(catedratico catedratico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.catedratico.Add(catedratico);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
               
            }

            return CreatedAtRoute("DefaultApi", new { id = catedratico.id }, catedratico);
        }

        // DELETE: api/catedraticoes/5
        [ResponseType(typeof(catedratico))]
        public HttpResponseMessage Delete([FromBody] catedratico Clien)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (examenfinalEntities entities = new examenfinalEntities())
                {
                    entities.Entry(Clien).State = System.Data.Entity.EntityState.Deleted;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }
    }
}