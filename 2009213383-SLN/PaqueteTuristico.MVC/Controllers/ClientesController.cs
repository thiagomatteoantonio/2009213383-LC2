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
    public class ClientesController : Controller
    {
        // private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();
        private readonly IUnityofWork _UnityOfWork;

        public ClientesController(IUnityofWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public ClientesController()
        {

        }

        // GET: Clientes
        public ActionResult Index()
        {
            // return View(db.Personas.ToList());
            return View(_UnityOfWork.Cliente.GetAll());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Cliente cliente = db.Personas.Find(id);
            Cliente cliente = _UnityOfWork.Cliente.Get(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombres,ApePaterno,ApeMaterno,Correo,Telefono,Dirección,Dni,NroCuenta")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //  db.Personas.Add(cliente);
                _UnityOfWork.Cliente.Add(cliente);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Cliente cliente = db.Personas.Find(id);
            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,ApePaterno,ApeMaterno,Correo,Telefono,Dirección,Dni,NroCuenta")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //   db.Entry(cliente).State = EntityState.Modified;
                _UnityOfWork.StateModified(cliente);
                //  db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
              

            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Cliente cliente = db.Personas.Find(id);
            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Cliente cliente = db.Personas.Find(id);
            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            //  db.Personas.Remove(cliente);
            _UnityOfWork.Cliente.Delete(cliente);
            //  db.SaveChanges();
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
