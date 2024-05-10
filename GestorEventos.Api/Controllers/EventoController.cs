using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

			return (evento == null) ? NotFound() : Ok(evento);
		}

		[HttpPost("nuevo")]
		public IActionResult PostNuevoEvento([FromBody] Evento eventoNuevo)
		{

			EventoService eventosService = new EventoService();

			return eventosService.Agregar(eventoNuevo)? Ok(): UnprocessableEntity();//UnprocessableEntity -> 422 error
        }

		[HttpPut("{idEvento:int}/Modificar")]
		public IActionResult ModificarEvento(int idEvento, [FromBody] Evento evento)
		{
			EventoService eventosService = new EventoService();

			return eventosService.Modificar(idEvento, evento) ? Ok() : UnprocessableEntity();
		}


		[HttpDelete("{idEvento:int}/Delete")]
        public IActionResult Delete(int idEvento)
        {
            EventoService service = new EventoService();

            return service.Eliminar(idEvento) ? Ok() : UnprocessableEntity();
        }
    }
}
