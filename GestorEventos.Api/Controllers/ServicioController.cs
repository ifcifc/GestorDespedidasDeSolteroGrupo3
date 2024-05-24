using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    public class ServicioController : BaseController<Servicio>
    {
        public ServicioController(IService<Servicio> service) : base(service)
        {
        }
    }
}
