using GestorEventos.Servicios.Controller;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GestorEventos.Servicios.SQLUtils;

namespace GestorEventos.WebClient.Controllers
{
    [Authorize]
    public class ReservaController : Controller
    {
        private IService<PersonaModel> personaModelService;
        private IService<Provincia> provinciaService;
        private IService<LocalidadesProvincia> localidadService;
        private PersonaService personaService;

        public ReservaController(IService<Persona> personaService, IService<PersonaModel> personaModelService, IService<Provincia> provinciaService, IService<LocalidadesProvincia> localidadService)
        {
            this.personaModelService = personaModelService;
            this.provinciaService = provinciaService;
            this.localidadService = localidadService;
            this.personaService = (PersonaService)personaService;
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
            this.personaModelService.Add(this.personaModelService.FromFormCollection(collection));

            return RedirectToAction(nameof(Index));
        }

        public ActionResult PersonaList()
        {
            int IdUsuario = int.Parse(HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return View(this.personaModelService.GetAllByID(IdUsuario));
        }
    }

    
}
