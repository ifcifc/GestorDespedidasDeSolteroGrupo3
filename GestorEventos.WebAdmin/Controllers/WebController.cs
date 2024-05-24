using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public abstract class WebController<T, V> : Controller where T : Service<V>, new() where V : Entidad, new()
    {

        // GET: ServiceController
        public ActionResult Index()
        {
            return View(new T().GetAll());
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View(new T().GetByID(id));
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
                T service = new T();
                service.Add(service.FromFormCollection(collection));
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
            return View(new T().GetByID(id));
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                T service = new T();
                service.Modify(
                    id,
                    service.FromFormCollection(collection));

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
            return View(new T().GetByID(id));
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new T().Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
