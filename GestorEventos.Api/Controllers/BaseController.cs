using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController <V> : Controller where V : Entidad, new()
    {
        protected IService<V> Service;
        public BaseController(IService<V> service) { 
            this.Service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.Service.GetAll());
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
                var entidad = this.Service.GetByID(id);
                return (entidad == null) ? NotFound() : Ok(entidad);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        /*
        [HttpPost("Add")]
        public IActionResult Add([FromBody] V entidad)
        {
            try {
                return this.Service.Add(entidad)? Ok() : UnprocessableEntity();
            } catch (Exception) {
                return UnprocessableEntity();   
            }
        }

        [HttpPut("{id:int}/Modify")]
        public IActionResult ModificarEvento(int id, [FromBody] V entidad)
        {
            try
            {
                return this.Service.Modify(id, entidad) ? Ok() : UnprocessableEntity();
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
                return this.Service.Delete(id) ? Ok() : UnprocessableEntity();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }*/

        [HttpGet("GetAllByID/{id:int}")]
        public IActionResult GetAllById(int id)
        {
            try
            {
                var entidad = this.Service.GetAllByID(id);
                return entidad == null ? NotFound() : Ok(entidad);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
