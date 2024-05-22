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
		public IActionResult Get()
		{
			EventoService eventoService = new EventoService();

			return Ok(eventoService.Get());
		}

		[HttpGet("{idEvento:int}")]
		public IActionResult GetPorId(int idEvento)
		{
            EventoService eventoService = new EventoService();

			var evento = eventoService.GetPorId(idEvento);

			if (evento == null)
				return NotFound();
			else
				return Ok(evento);
		}

		[HttpPost("nuevo")]
		public IActionResult Post([FromBody] Evento eventoNuevo)
		{

            EventoService eventosService = new EventoService();
            eventosService.Crear(eventoNuevo);

			return Ok();
		}


        [HttpPut("{id:int}/modificar")]
        public IActionResult Modificar(int id, [FromBody] Evento entidad)
        {
            try
            {
                return new EventoService().Modificar(id, entidad) ? Ok() : UnprocessableEntity();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }


        [HttpDelete("{id:int}/Eliminar")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                return new EventoService().Eliminar(id) ? Ok() : UnprocessableEntity();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }
    }
}
