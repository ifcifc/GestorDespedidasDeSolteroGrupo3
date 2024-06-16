using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;
using GestorEventos.Servicios.Controllers;


namespace GestorEventos.WebAdmin.Controllers
{
    public class LocalidadController : WebController<LocalidadModel>
    {

        private IService<LocalidadModel> localidadService;
        private IService<Provincia> provinciaService;
        public LocalidadController(IService<LocalidadModel> localidadService, IService<Provincia> provinciaService) : base(localidadService)
        {
            this.localidadService = localidadService;
            this.provinciaService = provinciaService;
        }

        public override ActionResult Create()
        {
            ViewBag.Provincias = provinciaService.GetAll();


            return base.Create();
        }
        public override ActionResult Edit(int id)
        {
            LocalidadModel? localidadModel = this.localidadService.GetByID(id);
            ViewBag.Provincias = provinciaService.GetAll();
            ViewBag.IdProvincia = localidadModel?.IdProvincia;


            return View(localidadModel);
        }
    }
}
