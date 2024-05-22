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
        public IActionResult Get()
        {
            LocalidadService localidadService = new LocalidadService();

            return Ok(localidadService.Get());
        }

        [HttpGet("{idLocalidad:int}")]
        public IActionResult GetPorId(int idLocalidad)
        {
           LocalidadService localidadService = new LocalidadService();

            var localidad = localidadService.GetPorId(idLocalidad);

            if (localidad == null)
                return NotFound();
            else
                return Ok(localidad);
        }

        [HttpPost("nuevo")]
        public IActionResult Post([FromBody] Localidad localidadNueva)
        {
            LocalidadService localidadService = new LocalidadService();
            localidadService.Crear(localidadNueva);

            return Ok();
        }
    }
}
