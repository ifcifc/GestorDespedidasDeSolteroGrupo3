using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.Controller;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class EventoController : WebController<Evento>
    {
        public EventoController(IService<Evento> service) : base(service)
        {
        }
}
}
