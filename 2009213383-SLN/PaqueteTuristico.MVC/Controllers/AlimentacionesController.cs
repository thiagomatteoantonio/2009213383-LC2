using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Persistence;
using PaquetesTuristicos.Entities.IRepositories;

namespace PaqueteTuristico.MVC.Controllers
{
    public class AlimentacionesController : Controller
    {
        //private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public AlimentacionesController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public AlimentacionesController()
        {

        }
        // GET: Alimentaciones
        public ActionResult Index()
        {
            // return View(db.ServicioTuristicoes.ToList());
                return View(_UnityOfWork.Alimentacion.GetAll());
        }

        // GET: Alimentaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Alimentacion alimentacion = db.ServicioTuristicoes.Find(id);
            Alimentacion alimentacion = _UnityOfWork.Alimentacion.Get(id);
            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // GET: Alimentaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alimentaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,Direccion,CategoriaAlimentacion")] Alimentacion alimentacion)
        {
            if (ModelState.IsValid)
            {
                // db.ServicioTuristicoes.Add(alimentacion);
                _UnityOfWork.Alimentacion.Add(alimentacion);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alimentacion);
        }

        // GET: Alimentaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Alimentacion alimentacion = db.ServicioTuristicoes.Find(id);
            Alimentacion alimentacion = _UnityOfWork.Alimentacion.Get(id);

            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // POST: Alimentaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,Direccion,CategoriaAlimentacion")] Alimentacion alimentacion)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(alimentacion).State = EntityState.Modified;
                _UnityOfWork.StateModified(alimentacion);
                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(alimentacion);
        }

        // GET: Alimentaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  Alimentacion alimentacion = db.ServicioTuristicoes.Find(id);
            Alimentacion alimentacion = _UnityOfWork.Alimentacion.Get(id);

            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // POST: Alimentaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Alimentacion alimentacion = db.ServicioTuristicoes.Find(id);
            Alimentacion alimentacion = _UnityOfWork.Alimentacion.Get(id);

            // db.ServicioTuristicoes.Remove(alimentacion);
            _UnityOfWork.Alimentacion.Delete(alimentacion);

            // db.SaveChanges();
            _UnityOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
