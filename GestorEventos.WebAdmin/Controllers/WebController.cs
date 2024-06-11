using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public abstract class WebController<V> : Controller where V : Entidad, new()
    {
        private IService<V> Service;
        public WebController(IService<V> service)
        {
            this.Service = service;
        }

        // GET: ServiceController
        public ActionResult Index()
        {
            return View(this.Service.GetAll());
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View(this.Service.GetByID(id));
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                this.Service.Add(this.Service.FromFormCollection(collection));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(this.Service.GetByID(id));
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                this.Service.Modify(
                    id,
                    this.Service.FromFormCollection(collection));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(this.Service.GetByID(id));
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                this.Service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
