using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PersonaController : Controller
	{

		[HttpGet]
		public IActionResult Get()
		{
			PersonaService personaService = new PersonaService();

			return Ok(personaService.GetPersonas());
		}

		[HttpGet("{idPersona:int}")]
		public IActionResult GetPersonaPorId(int idPersona)
		{
			PersonaService personaService = new PersonaService();
			Persona persona = personaService.GetPersonaPorId(idPersona);

            return (persona == null) ? NotFound() : Ok(persona);
        }

        [HttpDelete("{idPersona:int}/Delete")]
        public IActionResult Delete(int idPersona)
        {
            PersonaService service = new PersonaService();

            return service.Eliminar(idPersona) ? Ok() : UnprocessableEntity();
        }


        [HttpPut("{idPersona:int}/Modificar")]
        public IActionResult Modificar(int idPersona, [FromBody] Persona persona)
        {
            PersonaService service = new PersonaService();

            return service.Modificar(idPersona, persona) ? Ok() : UnprocessableEntity();
        }

        [HttpPost("nuevo")]
        public IActionResult PostNuevo([FromBody] Persona persona)
        {

            PersonaService service = new PersonaService();

            return service.Agregar(persona) ? Ok() : UnprocessableEntity();//UnprocessableEntity -> 422 error
        }
    }
}
