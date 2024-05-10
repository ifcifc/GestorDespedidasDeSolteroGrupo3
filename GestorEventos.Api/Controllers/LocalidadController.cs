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

            return (localidad == null) ? NotFound() : Ok(localidad);
        }

        [HttpPost("nuevo")]
        public IActionResult PostNuevaProvincia([FromBody] Localidad localidadNueva)
        {
            LocalidadService localidadService = new LocalidadService();
            localidadService.Agregar(localidadNueva);

            return Ok();
        }

        [HttpDelete("{idLocalidad:int}/Delete")]
        public IActionResult Delete(int idLocalidad)
        {
            LocalidadService service = new LocalidadService();

            return service.Eliminar(idLocalidad) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("{IdLocalidad:int}/Modificar")]
        public IActionResult Modificar(int IdLocalidad, [FromBody] Localidad localidad)
        {
            LocalidadService eventosService = new LocalidadService();
            return eventosService.Modificar(IdLocalidad, localidad) ? Ok() : UnprocessableEntity();
        }
    }
}
