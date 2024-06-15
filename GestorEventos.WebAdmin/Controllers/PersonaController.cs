using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class PersonaController : WebController<PersonaModel>
    {
        private IService<PersonaModel> personaService;
        private IService<Provincia> provinciaService;
        private IService<LocalidadesProvincia> localidadService;
        public PersonaController(IService<PersonaModel> personaService, IService<Provincia> provinciaService, IService<LocalidadesProvincia> localidadService) : base(personaService)
        {
            this.personaService = personaService;
            this.provinciaService = provinciaService;
            this.localidadService = localidadService;
        }

        public override ActionResult Create()
        {
            IEnumerable<Provincia>? provincias = this.provinciaService.GetAll();
            ViewBag.Provincias = provincias;
            ViewBag.Localidad  = this.localidadService.GetAllByID(provincias?.FirstOrDefault(x=>true)?.IdProvincia ?? 1);
            
            return base.Create();
        }

        public override ActionResult Edit(int id)
        {
            IEnumerable<Provincia>? provincias = this.provinciaService.GetAll();
            ViewBag.Provincias = provincias;
            ViewBag.Localidad = this.localidadService.GetAllByID(provincias?.FirstOrDefault(x => true)?.IdProvincia ?? 1);

            return base.Edit(id);
        }
    }
}
