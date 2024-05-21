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
		public IActionResult Get()
		{
			ServicioService servicioService = new ServicioService();

			return Ok(servicioService.Get());
		}

		[HttpGet("{idServicio:int}")]
		public IActionResult GetPorId(int idServicio)
		{
			ServicioService servicioService = new ServicioService();

			var servicio = servicioService.GetPorId(idServicio);

			if (servicio == null)
				return NotFound();
			else
				return Ok(servicio);
		}

		[HttpPost("nuevo")]
		public IActionResult Post([FromBody] Servicio servicionuevo)
		{

			ServicioService servicioService = new ServicioService();
            servicioService.Crear(servicionuevo);

			return Ok();
		}



	}
}
