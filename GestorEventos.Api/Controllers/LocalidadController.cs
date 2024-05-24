using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    public class LocalidadController : BaseController<Localidad>
    {
        public LocalidadController(IService<Localidad> service) : base(service)
        {
        }
    }
}
