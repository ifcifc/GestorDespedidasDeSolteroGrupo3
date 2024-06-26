using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Compartido.Controller;

namespace GestorEventos.WebAdmin.Controllers
{
    public class TipoEventoController : WebController<TipoEvento>
    {
        public TipoEventoController(IService<TipoEvento> service) : base(service)
        {
        }
    }
}
