using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;
using GestorEventos.Compartido.Controller;


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

        public override ActionResult Index()
        {//this.localidadService.GetAllByID(19)
            ViewBag.Provincias = provinciaService.GetAll();
            return View(new List<LocalidadModel>());
        }

        [HttpPost]
        public  ActionResult Lista(IFormCollection collection)
        {
            if (collection["IdProvincia"] == 0) Index();

            ViewBag.Provincias = provinciaService.GetAll();
            return View("Index", this.localidadService.GetAllByID(int.Parse(collection["IdProvincia"])));
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
