using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class EventoController : WebController<TipoEvento>
    {
        public EventoController(IService<TipoEvento> service) : base(service)
        {
        }
}
}
