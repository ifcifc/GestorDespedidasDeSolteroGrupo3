using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicioController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetServicios()
		{
			ServicioService servicioService = new ServicioService();

			return Ok(servicioService.GetServicios());
		}

		[HttpGet("{idServicio:int}")]
		public IActionResult GetServicioPorId(int idServicio)
		{
			ServicioService servicioService = new ServicioService();

			var servicio = servicioService.GetServicioPorId(idServicio);

            return (servicio == null) ? NotFound() : Ok(servicio);
        }

		[HttpPost("nuevo")]
		public IActionResult PostNuevoServicio([FromBody] Servicio servicionuevo)
		{
			ServicioService servicioService = new ServicioService();
            servicioService.Agregar(servicionuevo);

			return Ok();
		}

        [HttpDelete("{idServicio:int}/Delete")]
        public IActionResult Delete(int idServicio)
        {
            ServicioService service = new ServicioService();

            return service.Eliminar(idServicio) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("{idServicio:int}/Modificar")]
        public IActionResult Modificar(int idServicio, [FromBody] Servicio servicio)
        {
            ServicioService service = new ServicioService();

            return service.Modificar(idServicio, servicio) ? Ok() : UnprocessableEntity();
        }

    }
}
