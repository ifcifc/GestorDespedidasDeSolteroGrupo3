using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController <T, V> : Controller where T : Service<V>, new() where V : Entidad
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new T().GetAll());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var entidad = new T().GetByID(id);
                return (entidad == null) ? NotFound() : Ok(entidad);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] V entidad)
        {
            try {
                return new T().Add(entidad)? Ok() : UnprocessableEntity();
            } catch (Exception) {
                return UnprocessableEntity();   
            }
        }

        [HttpPut("{id:int}/Modify")]
        public IActionResult ModificarEvento(int id, [FromBody] V entidad)
        {
            try
            {
                return new T().Modify(id, entidad) ? Ok() : UnprocessableEntity();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }


        [HttpDelete("{id:int}/Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                return new T().Delete(id) ? Ok() : UnprocessableEntity();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

    }
}
