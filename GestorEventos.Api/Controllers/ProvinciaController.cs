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

			return Ok(provinciaService.GetProvincias());
		}

		[HttpGet("{idProvincia:int}")]
		public IActionResult GetProvinciaPorId(int idProvincia)
		{
            ProvinciaService provinciaService = new ProvinciaService();

			var provincia = provinciaService.GetProvinciaPorId(idProvincia);

			if (provincia == null)
				return NotFound();
			else
				return Ok(provincia);
		}

		[HttpPost("nuevo")]
		public IActionResult PostNuevaProvincia([FromBody] Provincia provinciaNueva)
		{

            ProvinciaService provinciaService = new ProvinciaService();
            provinciaService.AgregarProvincia(provinciaNueva);

			return Ok();
		}



	}
}
