using GestorEventos.Servicios.Controllers;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class EventoController : WebController<EventoModel>
    {
        IService<EventoModel> eventoService;
        public EventoController(IService<EventoModel> eventoService) : base(eventoService)
        {
            this.eventoService = eventoService;
        }
    }
}
