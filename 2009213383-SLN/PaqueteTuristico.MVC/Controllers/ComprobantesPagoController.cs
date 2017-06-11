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
    public class ComprobantesPagoController : Controller
    {
        //  private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public ComprobantesPagoController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public ComprobantesPagoController()
        {

        }
        // GET: ComprobantesPago
        public ActionResult Index()
        {
            //  return View(db.ComprobantesPago.ToList());
            return View(_UnityOfWork.ComprobantePago.GetAll());
        }

        // GET: ComprobantesPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // ComprobantePago comprobantePago = db.ComprobantesPago.Find(id);
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantePago.Get(id);

            if (comprobantePago == null)
            {
                return HttpNotFound();
            }
            return View(comprobantePago);
        }

        // GET: ComprobantesPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComprobantesPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,TipoComprobante")] ComprobantePago comprobantePago)
        {
            if (ModelState.IsValid)
            {
                //   db.ComprobantesPago.Add(comprobantePago);
                _UnityOfWork.ComprobantePago.Add(comprobantePago);

                //   db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(comprobantePago);
        }

        // GET: ComprobantesPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  ComprobantePago comprobantePago = db.ComprobantesPago.Find(id);
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantePago.Get(id);

            if (comprobantePago == null)
            {
                return HttpNotFound();
            }
            return View(comprobantePago);
        }

        // POST: ComprobantesPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,TipoComprobante")] ComprobantePago comprobantePago)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(comprobantePago).State = EntityState.Modified;
                _UnityOfWork.StateModified(comprobantePago);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(comprobantePago);
        }

        // GET: ComprobantesPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // ComprobantePago comprobantePago = db.ComprobantesPago.Find(id);
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantePago.Get(id);

            if (comprobantePago == null)
            {
                return HttpNotFound();
            }
            return View(comprobantePago);
        }

        // POST: ComprobantesPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //ComprobantePago comprobantePago = db.ComprobantesPago.Find(id);
            ComprobantePago comprobantePago = _UnityOfWork.ComprobantePago.Get(id);

            // db.ComprobantesPago.Remove(comprobantePago);
            _UnityOfWork.ComprobantePago.Delete(comprobantePago);

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
