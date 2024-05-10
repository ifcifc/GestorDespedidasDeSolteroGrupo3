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

			return Ok(tipoEventoService.GetTipoEventos());
		}


		[HttpGet("{idTipoEvento:int}")]
		public IActionResult Get(int idTipoEvento)
		{
			TipoEventoService tipoEventoService = new TipoEventoService();
            TipoEvento tipoEvento = tipoEventoService.GetTipoEventoPorId(idTipoEvento);

            return (tipoEvento == null) ? NotFound() : Ok(tipoEvento);
        }


        [HttpDelete("{idTipoEvento:int}/Delete")]
        public IActionResult Delete(int idTipoEvento)
        {
            TipoEventoService service = new TipoEventoService();

            return service.Eliminar(idTipoEvento) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("{idTipoEvento:int}/Modificar")]
        public IActionResult Modificar(int idTipoEvento, [FromBody] TipoEvento tipoEvento)
        {
            TipoEventoService service = new TipoEventoService();

            return service.Modificar(idTipoEvento, tipoEvento) ? Ok() : UnprocessableEntity();
        }

        [HttpPost("nuevo")]
        public IActionResult PostNuevo([FromBody] TipoEvento tipoEvento)
        {

            TipoEventoService service = new TipoEventoService();

            return service.Agregar(tipoEvento) ? Ok() : UnprocessableEntity();//UnprocessableEntity -> 422 error
        }
    }
}
