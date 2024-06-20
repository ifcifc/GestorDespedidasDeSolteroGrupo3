using GestorEventos.Servicios.Controllers;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class EventoController : WebController<EventoModel>
    {
        IService<Usuario> usuarioService;
        IService<EstadoEvento> estadoEventoService;
        IService<TipoEvento> tipoEventoService;
        IService<Persona> personaService;
        ServiciosService sevicioService;
        IService<EventoServicio> eventoServicio;
        EventoService eventoService;
        public EventoController(
                        IService<EventoModel> eventoModelService, 
                        IService<Usuario> usuarioService, 
                        IService<TipoEvento> tipoEventoService, 
                        IService<Persona> personaService, 
                        IService<EstadoEvento> estadoEventoService, 
                        IService<Servicio> sevicioService, 
                        IService<EventoServicio> eventoServicio, 
                        IService<Evento> eventoService) : base(eventoModelService)
        {
            this.usuarioService = usuarioService;
            this.tipoEventoService = tipoEventoService;
            this.estadoEventoService = estadoEventoService;
            this.personaService = personaService;
            this.sevicioService = (ServiciosService)sevicioService;
            this.eventoServicio = eventoServicio;
            this.eventoService = (EventoService)eventoService;


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
            ViewBag.Usuarios = usuarioService.GetAll();
            ViewBag.TiposEventos = tipoEventoService.GetAll();
            ViewBag.Personas = personaService.GetAll();
            ViewBag.Servicios = sevicioService.GetAll();



            return base.Create();
        }

        public override ActionResult Create(IFormCollection collection)
        {
            int id = eventoService.AddGetID(this.Service.FromFormCollection(collection));

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
