using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;

namespace GestorEventos.WebAdmin.Controllers
{
    public class LocalidadController : WebController<Localidad>
    {
        public LocalidadController(IService<Localidad> service) : base(service)
        {
        }
    }
}
