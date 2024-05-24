using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    public class TipoEventoController : BaseController<TipoEvento>
    {
        public TipoEventoController(IService<TipoEvento> service) : base(service)
        {
        }
    }
}
