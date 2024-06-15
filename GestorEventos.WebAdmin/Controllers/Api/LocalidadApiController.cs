using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadApiController : Controller
    {
        IService<LocalidadesProvincia> service;
        public LocalidadApiController(IService<LocalidadesProvincia> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(this.service.GetAll());
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
                var entidad = this.service.GetAllByID(id);
                return entidad == null ? NotFound() : Ok(entidad);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
