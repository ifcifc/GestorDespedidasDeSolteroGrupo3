using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TipoEventoController : Controller
	{

		[HttpGet]
		public IActionResult Get()
		{
			TipoEventoService tipoEventoService = new TipoEventoService();

			return Ok(tipoEventoService.Get());
		}


		[HttpGet("{idTipoEvento:int}")]
		public IActionResult GetPorId(int idTipoEvento)
		{
			TipoEventoService tipoEventoService = new TipoEventoService();
			TipoEvento tipoEvento = null;

			tipoEvento = tipoEventoService.GetPorId(idTipoEvento);

			if (tipoEvento == null)
				return NotFound();
			else
				return Ok(tipoEvento);
		}


	}
}
