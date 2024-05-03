using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : Controller
    {
        [HttpGet]
        public IActionResult GetLocalidad()
        {
            LocalidadService localidadService = new LocalidadService();

            return Ok(localidadService.GetLocalidades());
        }

        [HttpGet("{idLocalidad:int}")]
        public IActionResult GetProvinciaPorId(int idLocalidad)
        {
           LocalidadService localidadService = new LocalidadService();

            var localidad = localidadService.GetLocalidadPorId(idLocalidad);

            if (localidad == null)
                return NotFound();
            else
                return Ok(localidad);
        }

        [HttpPost("nuevo")]
        public IActionResult PostNuevaProvincia([FromBody] Localidad localidadNueva)
        {
            LocalidadService localidadService = new LocalidadService();
            localidadService.AgregarLocalidad(localidadNueva);

            return Ok();
        }
    }
}
