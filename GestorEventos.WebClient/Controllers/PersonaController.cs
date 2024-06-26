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
            ViewBag.IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            ViewBag.Localidad = this.localidadService.GetAllByID(provincias?.FirstOrDefault(x => true)?.IdProvincia ?? 1);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create(IFormCollection collection)
        {
            this.personaModelService.Add(this.personaModelService.FromFormCollection(collection));

            return RedirectToAction(nameof(Index));
        }


        public override ActionResult Edit(int id)
        {
            IEnumerable<Provincia>? provincias = this.provinciaService.GetAll();
            ViewBag.Provincias = provincias;
            ViewBag.Localidad = this.localidadService.GetAllByID(provincias?.FirstOrDefault(x => true)?.IdProvincia ?? 1);

            return base.Edit(GetId(id));
        }

        public override ActionResult Details(int id)
        {
            return base.Details(GetId(id));
        }
        public override ActionResult Delete(int id)
        {
            return base.Delete(GetId(id));
        }

        protected override bool ValidateAction(int idEntity) {
            int IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return this.personaService.PersonaDeUsuario(idEntity, IdUsuario);
        }

        //Si se pasa el Id a travez del TempData este se prioriza
        private int GetId(int id) 
        {
            int idPersona = (TempData["IdPersona"] == null) ? id : (int)TempData["IdPersona"];
            TempData["IdPersona"] = null;
            return idPersona;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PersonaAction(IFormCollection collection)
        {
            int IdPersona = int.Parse(collection["IdPersona"]);
            int IdUsuario = int.Parse(HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);

            if (!this.personaService.PersonaDeUsuario(IdPersona, IdUsuario))
                return RedirectToAction("Index", "Home"); ;

            TempData["IdPersona"] = IdPersona;

            switch (collection["actionType"])
            {
                case "Evento": return RedirectToAction(nameof(Index));
                case "Delete": return RedirectToAction("Delete", "Persona");
                case "Edit": return RedirectToAction("Edit", "Persona");
                case "Details": return RedirectToAction("Details", "Persona");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
