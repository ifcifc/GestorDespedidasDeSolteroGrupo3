using GestorEventos.Compartido.Controllers;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;

namespace GestorEventos.Api.Controllers
{
    public class LocalidadController : ApiController<Localidad>
    {
        public LocalidadController(IService<Localidad> service) : base(service)
        {
        }
    }
}
