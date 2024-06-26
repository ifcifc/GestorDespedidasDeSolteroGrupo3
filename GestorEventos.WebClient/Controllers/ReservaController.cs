using GestorEventos.Compartido.Controller;
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
        private IService<Localidad> localidadService;
        private PersonaService personaService;

        public ReservaController(IService<Persona> personaService, IService<PersonaModel> personaModelService, IService<Provincia> provinciaService, IService<Localidad> localidadService)
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



        public ActionResult PersonaList()
        {
            int IdUsuario = int.Parse(HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return View(this.personaModelService.GetAllByID(IdUsuario));
        }
    }

    
}
