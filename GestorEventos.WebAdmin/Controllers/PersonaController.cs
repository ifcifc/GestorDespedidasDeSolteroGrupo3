using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorEventos.WebAdmin.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult Index()
        {
            return View(new PersonaService().Get());
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            return View(new PersonaService().GetPorId(id));
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                new PersonaService().Crear(new Persona()
                {
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Direccion = collection["Direccion"],
                    Telefono = collection["Telefono"],
                    Email = collection["Email"],
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new PersonaService().GetPorId(id));
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                new PersonaService().Modificar(id, new Persona()
                {
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Direccion = collection["Direccion"],
                    Telefono = collection["Telefono"],
                    Email = collection["Email"],
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new PersonaService().GetPorId(id));
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                new PersonaService().Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
