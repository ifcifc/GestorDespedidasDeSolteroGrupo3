using GestorEventos.Compartido.Controller;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class EventoAdminController : WebController<EventoModel>
    {

        EventoModelService eventoService;
        IService<Servicio> sevicioService;
        IService<EstadoEvento> estadoEventoService;
        public EventoAdminController(IService<EventoModel> service, IService<Servicio> sevicioService, IService<EstadoEvento> estadoEventoService) : base(service)
        {
            this.eventoService = (EventoModelService)service;
            this.sevicioService = sevicioService;
            this.estadoEventoService = estadoEventoService;
        }

        public override ActionResult Index()
        {
            return View(this.eventoService.GetAllOrder());
        }

        public ActionResult ChangeState(int id, int idEstado)
        {
            this.eventoService.SetEstado(id, idEstado);

            return RedirectToAction("Index");
        }
        public override ActionResult Details(int id)
        {
            ViewBag.ListaServicios = this.sevicioService.GetAllByID(id);
            ViewBag.ListaEstadoEventos = this.estadoEventoService.GetAll();
            decimal total = 0;
            foreach (Servicio s in ViewBag.ListaServicios)
            {
                total += s.PrecioServicio;
            }
            ViewBag.ServicioTotal = total.ToString("F2");


            return base.Details(id);
        }
    }
}
