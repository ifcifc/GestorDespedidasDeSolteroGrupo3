using GestorEventos.Servicios.Controllers;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    [Authorize]
    public class PersonaController : WebController<PersonaModel>
    {
        private IService<PersonaModel> personaModelService;
        private IService<Provincia> provinciaService;
        private IService<LocalidadesProvincia> localidadService;
        private IService<Usuario> usuarioService;
        private PersonaService personaService;
        public PersonaController(IService<Persona> personaService, IService<PersonaModel> personaModelService, IService<Provincia> provinciaService, IService<LocalidadesProvincia> localidadService, IService<Usuario> usuarioService) : base(personaModelService)
        {
            this.personaModelService = personaModelService;
            this.provinciaService = provinciaService;
            this.localidadService = localidadService;
            this.usuarioService = usuarioService;
            this.personaService = (PersonaService)personaService;

            
        }

        public override ActionResult Index()
        {
            int IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return View(this.Service.GetAllByID(IdUsuario));
        }

        public override ActionResult Create()
        {
            IEnumerable<Provincia>? provincias = this.provinciaService.GetAll();
            ViewBag.Provincias = provincias;
            ViewBag.Localidad = this.localidadService.GetAllByID(provincias?.FirstOrDefault(x => true)?.IdProvincia ?? 1);
            ViewBag.IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return base.Create();
        }



        public override ActionResult Edit(int id)
        {
            IEnumerable<Provincia>? provincias = this.provinciaService.GetAll();
            ViewBag.Provincias = provincias;
            ViewBag.Localidad = this.localidadService.GetAllByID(provincias?.FirstOrDefault(x => true)?.IdProvincia ?? 1);

            return base.Edit(id);
        }

        protected override bool ValidateAction(int idEntity) {
            int IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return this.personaService.PersonaDeUsuario(idEntity, IdUsuario);
        }
    }
}
