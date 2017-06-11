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
    public class VentaPaquetesController : Controller
    {
        //private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public VentaPaquetesController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public VentaPaquetesController()
        {

        }
        // GET: VentaPaquetes
        public ActionResult Index()
        {
            var ventaPaquetes = db.VentaPaquetes.Include(v => v.ComprobantePago);
            // return View(ventaPaquetes.ToList());
            return View(_UnityOfWork.VentaPaquete.GetAll());

        }

        // GET: VentaPaquetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            VentaPaquete ventaPaquete = _UnityOfWork.VentaPaquete.Get(id);

            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquete);
        }

        // GET: VentaPaquetes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.ComprobantesPago, "Id", "Id");
            return View();
        }

        // POST: VentaPaquetes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id,MediosPago")] VentaPaquete ventaPaquete)
        {
            if (ModelState.IsValid)
            {
                // db.VentaPaquetes.Add(ventaPaquete);
                _UnityOfWork.VentaPaquete.Add(ventaPaquete);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.ComprobantesPago, "Id", "Id", ventaPaquete.Id);
            return View(ventaPaquete);
        }

        // GET: VentaPaquetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            VentaPaquete ventaPaquete = _UnityOfWork.VentaPaquete.Get(id);

            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.ComprobantesPago, "Id", "Id", ventaPaquete.Id);
            return View(ventaPaquete);
        }

        // POST: VentaPaquetes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id,MediosPago")] VentaPaquete ventaPaquete)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ventaPaquete).State = EntityState.Modified;
                _UnityOfWork.StateModified(ventaPaquete);

                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.ComprobantesPago, "Id", "Id", ventaPaquete.Id);
            return View(ventaPaquete);
        }

        // GET: VentaPaquetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            VentaPaquete ventaPaquete = _UnityOfWork.VentaPaquete.Get(id);

            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquete);
        }

        // POST: VentaPaquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //  VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            VentaPaquete ventaPaquete = _UnityOfWork.VentaPaquete.Get(id);

            //db.VentaPaquetes.Remove(ventaPaquete);
            _UnityOfWork.VentaPaquete.Delete(ventaPaquete);

            //db.SaveChanges();
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
