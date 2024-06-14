using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace GestorEventos.Servicios.Controller
{
    public class SimpleController : Microsoft.AspNetCore.Mvc.Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Details(int id)
        {
            return View();
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
