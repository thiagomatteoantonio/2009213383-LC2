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
    public class PaquetesController : Controller
    {
        //  private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public PaquetesController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public PaquetesController()
        {

        }
        // GET: Paquetes
        public ActionResult Index()
        {
            //return View(db.Paquetes.ToList());
            return View(_UnityOfWork.Paquete.GetAll());

        }

        // GET: Paquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Paquete paquete = db.Paquetes.Find(id);
            Paquete paquete = _UnityOfWork.Paquete.Get(id);

            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // GET: Paquetes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                //  db.Paquetes.Add(paquete);
                _UnityOfWork.Paquete.Add(paquete);

                //   db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(paquete);
        }

        // GET: Paquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Paquete paquete = db.Paquetes.Find(id);
            Paquete paquete = _UnityOfWork.Paquete.Get(id);

            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(paquete).State = EntityState.Modified;
                _UnityOfWork.StateModified(paquete);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Paquete paquete = db.Paquetes.Find(id);
            Paquete paquete = _UnityOfWork.Paquete.Get(id);

            if (paquete == null)
            {
                return HttpNotFound();
            }
            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Paquete paquete = db.Paquetes.Find(id);
            Paquete paquete = _UnityOfWork.Paquete.Get(id);

            //  db.Paquetes.Remove(paquete);
            _UnityOfWork.Paquete.Delete(paquete);

            // db.SaveChanges();
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
