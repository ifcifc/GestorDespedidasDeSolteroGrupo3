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
        IService<Servicio> sevicioService;
        public EventoController(IService<EventoModel> eventoService, IService<Usuario> usuarioService, IService<TipoEvento> tipoEventoService, IService<Persona> personaService, IService<EstadoEvento> estadoEventoService, IService<Servicio> sevicioService) : base(eventoService)
        {
            this.usuarioService = usuarioService;
            this.tipoEventoService = tipoEventoService;
            this.estadoEventoService = estadoEventoService;
            this.personaService = personaService;
            this.sevicioService = sevicioService;
        }

        public override ActionResult Create()
        {
            ViewBag.Usuarios = usuarioService.GetAll();
            ViewBag.TiposEventos = tipoEventoService.GetAll();
            ViewBag.Personas = personaService.GetAll();
            ViewBag.Servicios = sevicioService.GetAll();



            return base.Create();
        }
    }
}
