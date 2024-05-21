using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProvinciaController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetProvincia()
		{
			ProvinciaService provinciaService = new ProvinciaService();

			return Ok(provinciaService.Get());
		}

		[HttpGet("{idProvincia:int}")]
		public IActionResult GetPorId(int idProvincia)
		{
            ProvinciaService provinciaService = new ProvinciaService();

			var provincia = provinciaService.GetPorId(idProvincia);

			if (provincia == null)
				return NotFound();
			else
				return Ok(provincia);
		}

		[HttpPost("nuevo")]
		public IActionResult Post([FromBody] Provincia provinciaNueva)
		{

            ProvinciaService provinciaService = new ProvinciaService();
            provinciaService.Crear(provinciaNueva);

			return Ok();
		}



	}
}
