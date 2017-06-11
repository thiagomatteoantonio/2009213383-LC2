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
    public class HospedajesController : Controller
    {
        // private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public HospedajesController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public HospedajesController()
        {

        }
        // GET: Hospedajes
        public ActionResult Index()
        {
            //   return View(db.ServicioTuristicoes.ToList());
            return View(_UnityOfWork.Hospedaje.GetAll());

        }

        // GET: Hospedajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Hospedaje hospedaje = db.ServicioTuristicoes.Find(id);
            Hospedaje hospedaje = _UnityOfWork.Hospedaje.Get(id);

            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // GET: Hospedajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospedajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora,Direccion,Descripcion,TipoHospedaje,CalificacionHospedaje,CategoriaHospedaje,ServicioHospedaje")] Hospedaje hospedaje)
        {
            if (ModelState.IsValid)
            {
                // db.ServicioTuristicoes.Add(hospedaje);
                _UnityOfWork.Hospedaje.Add(hospedaje);
                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(hospedaje);
        }

        // GET: Hospedajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  Hospedaje hospedaje = db.ServicioTuristicoes.Find(id);
            Hospedaje hospedaje = _UnityOfWork.Hospedaje.Get(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // POST: Hospedajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora,Direccion,Descripcion,TipoHospedaje,CalificacionHospedaje,CategoriaHospedaje,ServicioHospedaje")] Hospedaje hospedaje)
        {
            if (ModelState.IsValid)
            {
                //  db.Entry(hospedaje).State = EntityState.Modified;
                _UnityOfWork.StateModified(hospedaje);

                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(hospedaje);
        }

        // GET: Hospedajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Hospedaje hospedaje = db.ServicioTuristicoes.Find(id);
            Hospedaje hospedaje = _UnityOfWork.Hospedaje.Get(id);
            if (hospedaje == null)
            {
                return HttpNotFound();
            }
            return View(hospedaje);
        }

        // POST: Hospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //  Hospedaje hospedaje = db.ServicioTuristicoes.Find(id);
            Hospedaje hospedaje = _UnityOfWork.Hospedaje.Get(id);

            // db.ServicioTuristicoes.Remove(hospedaje);
            _UnityOfWork.Hospedaje.Delete(hospedaje);

            //  db.SaveChanges();
            _UnityOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}
