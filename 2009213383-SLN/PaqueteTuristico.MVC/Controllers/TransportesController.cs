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
    public class TransportesController : Controller
    {
        //private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public TransportesController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public TransportesController()
        {

        }
        // GET: Transportes
        public ActionResult Index()
        {
            // return View(db.ServicioTuristicoes.ToList());
            return View(_UnityOfWork.Transporte.GetAll());

        }

        // GET: Transportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Transporte transporte = db.ServicioTuristicoes.Find(id);
            Transporte transporte = _UnityOfWork.Transporte.Get(id);

            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // GET: Transportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,Direccion,DescripcionTransporte,TipoTransporte,CategoriaTransporte")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                //  db.ServicioTuristicoes.Add(transporte);
                _UnityOfWork.Transporte.Add(transporte);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(transporte);
        }

        // GET: Transportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Transporte transporte = db.ServicioTuristicoes.Find(id);
            Transporte transporte = _UnityOfWork.Transporte.Get(id);
            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,Direccion,DescripcionTransporte,TipoTransporte,CategoriaTransporte")] Transporte transporte)
        {
            if (ModelState.IsValid)
            {
                //  db.Entry(transporte).State = EntityState.Modified;
                _UnityOfWork.StateModified(transporte);
                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(transporte);
        }

        // GET: Transportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Transporte transporte = db.ServicioTuristicoes.Find(id);
            Transporte transporte = _UnityOfWork.Transporte.Get(id);

            if (transporte == null)
            {
                return HttpNotFound();
            }
            return View(transporte);
        }

        // POST: Transportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Transporte transporte = db.ServicioTuristicoes.Find(id);
            Transporte transporte = _UnityOfWork.Transporte.Get(id);
            //  db.ServicioTuristicoes.Remove(transporte);
            _UnityOfWork.Transporte.Delete(transporte);
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
