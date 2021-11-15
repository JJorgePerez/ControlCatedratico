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
    public class cursoesController : ApiController
    {
        private examenfinalEntities db = new examenfinalEntities();

        // GET: api/cursoes
        public IQueryable<curso> Getcurso()
        {
            return db.curso;
        }

        // GET: api/cursoes/5
        [ResponseType(typeof(curso))]
        public IHttpActionResult Getcurso(int id)
        {
            curso curso = db.curso.Find(id);
            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }

        // PUT: api/cursoes/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage Put([FromBody] curso Clien)
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

        // POST: api/cursoes
        [ResponseType(typeof(curso))]
        public IHttpActionResult Postcurso(curso curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.curso.Add(curso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
  
            }

            return CreatedAtRoute("DefaultApi", new { id = curso.codigocurso }, curso);
        }

        // DELETE: api/cursoes/5
        [ResponseType(typeof(curso))]
        public HttpResponseMessage Delete([FromBody] curso Clien)
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