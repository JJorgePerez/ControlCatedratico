using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Principal;

namespace finalFase2.Views
{
    public class catedraticoesController : Controller
    {
        private examenfinalEntities db = new examenfinalEntities();

        // GET: catedraticoes
        public ActionResult Index()
        {
            var catedratico = db.catedratico.Include(c => c.curso);
            return View(catedratico.ToList());
        }

        // GET: catedraticoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return HttpNotFound();
            }
            return View(catedratico);
        }

        // GET: catedraticoes/Create
        public ActionResult Create()
        {
            ViewBag.idcurso = new SelectList(db.curso, "codigocurso", "nombrecurso");
            return View();
        }

        // POST: catedraticoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre1,nombre2,apellido1,apellido2,telefono,estado,idcurso")] catedratico catedratico)
        {
            if (ModelState.IsValid)
            {
                db.catedratico.Add(catedratico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcurso = new SelectList(db.curso, "codigocurso", "nombrecurso", catedratico.idcurso);
            return View(catedratico);
        }

        // GET: catedraticoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcurso = new SelectList(db.curso, "codigocurso", "nombrecurso", catedratico.idcurso);
            return View(catedratico);
        }

        // POST: catedraticoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre1,nombre2,apellido1,apellido2,telefono,estado,idcurso")] catedratico catedratico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catedratico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcurso = new SelectList(db.curso, "codigocurso", "nombrecurso", catedratico.idcurso);
            return View(catedratico);
        }

        // GET: catedraticoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return HttpNotFound();
            }
            return View(catedratico);
        }

        // POST: catedraticoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            catedratico catedratico = db.catedratico.Find(id);
            db.catedratico.Remove(catedratico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
