using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Servicios.Controllers
{
    public abstract class WebController<V> : Microsoft.AspNetCore.Mvc.Controller where V : Entidad, new()
    {
        protected IService<V> Service;
        public WebController(IService<V> service)
        {
            this.Service = service;
        }

        // GET: ServiceController
        public virtual ActionResult Index()
        {
            return View(this.Service.GetAll());
        }

        // GET: ServiceController/Details/5
        public virtual ActionResult Details(int id)
        {
            if (!ValidateAction(id)) return RedirectToAction("Index", "Home");
            return View(this.Service.GetByID(id));
        }

        // GET: ServiceController/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(IFormCollection collection)
        {
            this.Service.Add(this.Service.FromFormCollection(collection));

            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceController/Edit/5

        public virtual ActionResult Edit(int id)
        {
            if (!ValidateAction(id)) return RedirectToAction("Index", "Home");
            return View(this.Service.GetByID(id));
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(int id, IFormCollection collection)
        {
            if (!ValidateAction(id)) return RedirectToAction("Index", "Home");
            V v = this.Service.FromFormCollection(collection);
            this.Service.Modify(
                id,
                this.Service.FromFormCollection(collection));

            return RedirectToAction(nameof(Index));
          
        }

        // GET: ServiceController/Delete/5
        public virtual ActionResult Delete(int id)
        {
            if (!ValidateAction(id)) return RedirectToAction("Index", "Home");
            return View(this.Service.GetByID(id));
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id, IFormCollection collection)
        {
            if(!ValidateAction(id)) return RedirectToAction("Index", "Home");
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

        protected virtual bool ValidateAction(int idEntity) => true;
    }
}
