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

            return (provincia == null) ? NotFound() : Ok(provincia);
        }

		[HttpPost("nuevo")]
		public IActionResult PostNuevaProvincia([FromBody] Provincia provinciaNueva)
		{
            ProvinciaService provinciaService = new ProvinciaService();
            provinciaService.Agregar(provinciaNueva);

			return Ok();
		}

        [HttpDelete("{idProvincia:int}/Delete")]
        public IActionResult Delete(int idProvincia)
        {
            ProvinciaService service = new ProvinciaService();

            return service.Eliminar(idProvincia) ? Ok() : UnprocessableEntity();
        }


        [HttpPut("{idProvincia:int}/Modificar")]
        public IActionResult Modificar(int idProvincia, [FromBody] Provincia provincia)
        {
            ProvinciaService service = new ProvinciaService();

            return service.Modificar(idProvincia, provincia) ? Ok() : UnprocessableEntity();
        }

    }
}
