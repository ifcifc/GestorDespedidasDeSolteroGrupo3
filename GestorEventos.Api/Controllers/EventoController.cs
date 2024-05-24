using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;

namespace GestorEventos.Api.Controllers
{
    public class EventoController : BaseController<Evento>
    {
        public EventoController(IService<Evento> service) : base(service)
        {
        }
    }
}
