using GestorEventos.Compartido.Controller;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebClient.Controllers
{
    public class EventoController : WebController<EventoModel>
    {
        IService<EstadoEvento> estadoEventoService;
        IService<TipoEvento> tipoEventoService;
        ServiciosService sevicioService;
        IService<EventoServicio> eventoServicio;
        EventoService eventoService;
        public EventoController(
                        IService<EventoModel> eventoModelService, 
                        IService<TipoEvento> tipoEventoService, 
                        IService<EstadoEvento> estadoEventoService, 
                        IService<Servicio> sevicioService, 
                        IService<EventoServicio> eventoServicio, 
                        IService<Evento> eventoService) : base(eventoModelService)
        {
            this.tipoEventoService = tipoEventoService;
            this.estadoEventoService = estadoEventoService;
            this.sevicioService = (ServiciosService)sevicioService;
            this.eventoServicio = eventoServicio;
            this.eventoService = (EventoService)eventoService;


        }

        public override ActionResult Index()
        {
            int idUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            return View(this.Service.GetAllByID(idUsuario));
        }

        public override ActionResult Details(int id)
        {
            ViewBag.ListaServicios = this.sevicioService.GetServiciosByIdEvento(id);
            decimal total = 0;
            foreach (Servicio s in ViewBag.ListaServicios) {
                total += s.PrecioServicio;
            }
            ViewBag.ServicioTotal = total.ToString("F2");


            return base.Details(id);
        }

        public override ActionResult Create()
        {
            ViewBag.TiposEventos = tipoEventoService.GetAll();
            ViewBag.Servicios = sevicioService.GetAll();


            return base.Create();
        }

        public override ActionResult Create(IFormCollection collection)
        {
            EventoModel eventoModel = this.Service.FromFormCollection(collection);
            eventoModel.IdEstadoEvento = 1;
            eventoModel.IdPersonaAgasajada = (int)TempData["IdPersonaAgasajada"];
            eventoModel.IdUsuario = int.Parse(
                    HttpContext.User.Claims.First(x => x.Type == "UsuarioId").Value);
            
            TempData["IdPersonaAgasajada"] = null;

            int id = eventoService.AddGetID(eventoModel);

            foreach (var idServicio in (collection["Servicio"]))
            {
                this.eventoServicio.Add(new EventoServicio()
                {
                    IdEvento = id,
                    IdServicio = int.Parse(idServicio)
                });
            }

            return RedirectToAction(nameof(Index)); ;
        }
    }
}
