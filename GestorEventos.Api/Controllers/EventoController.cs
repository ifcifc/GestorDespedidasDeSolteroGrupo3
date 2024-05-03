using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventoController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetEvento()
		{
			EventoService eventoService = new EventoService();

			return Ok(eventoService.GetEventos());
		}

		[HttpGet("{idEvento:int}")]
		public IActionResult GetEventoPorId(int idEvento)
		{
            EventoService eventoService = new EventoService();

			var evento = eventoService.GetEventoPorId(idEvento);

			if (evento == null)
				return NotFound();
			else
				return Ok(evento);
		}

		[HttpPost("nuevo")]
		public IActionResult PostNuevoEvento([FromBody] Evento eventoNuevo)
		{

            EventoService eventosService = new EventoService();
            eventosService.AgregarEvento(eventoNuevo);

			return Ok();
		}



	}
}
