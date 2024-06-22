using GestorEventos.Servicios.Controller;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebClient.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        private IService<PersonaModel> personaService;
        private IService<Provincia> provinciaService;
        private IService<LocalidadesProvincia> localidadService;
        public ReservaController(IService<PersonaModel> personaService, IService<Provincia> provinciaService, IService<LocalidadesProvincia> localidadService)
        {
            this.personaService = personaService;
            this.provinciaService = provinciaService;
            this.localidadService = localidadService;
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonaCreate()
        {
            IEnumerable<Provincia>? provincias = this.provinciaService.GetAll();
            ViewBag.Provincias = provincias;
            ViewBag.IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            ViewBag.Localidad = this.localidadService.GetAllByID(provincias?.FirstOrDefault(x => true)?.IdProvincia ?? 1);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PersonaCreate(IFormCollection collection)
        {
            this.personaService.Add(this.personaService.FromFormCollection(collection));

            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PersonaAction(IFormCollection collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(">>" + item.Key);
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult PersonaList()
        {
            return View(this.personaService.GetAll());
        }
    }

    
}
