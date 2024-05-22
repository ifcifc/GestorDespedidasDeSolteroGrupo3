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

			return Ok(personaService.Get());
		}

		[HttpGet("{idPersona:int}")]
		public IActionResult GetPorId(int idPersona)
		{
			PersonaService personaService = new PersonaService();



			Persona persona = personaService.GetPorId(idPersona);

			if (persona == null)
				return NotFound();
			else
				return Ok(persona);
		}

        [HttpPost("nuevo")]
        public IActionResult Post([FromBody] Persona persona)
        {
            PersonaService personaService = new PersonaService();
            personaService.Crear(persona);

            return Ok();
        }
    }
}
