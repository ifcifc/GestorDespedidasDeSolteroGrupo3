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
            Persona? persona = new PersonaService().GetPorId(idPersona);

			if (persona == null)
				return NotFound();
			else
				return Ok(persona);
		}

        [HttpPost("nuevo")]
        public IActionResult Post([FromBody] Persona persona)
        {
            return new PersonaService().Crear(persona)? Ok(): UnprocessableEntity();
        }

        [HttpPut("{id:int}/modificar")]
        public IActionResult Modificar(int id, [FromBody] Persona persona)
        {
            try
            {
                return new PersonaService().Modificar(id, persona) ? Ok() : UnprocessableEntity();
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
                return new PersonaService().Eliminar(id) ? Ok() : UnprocessableEntity();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }
    }
}
