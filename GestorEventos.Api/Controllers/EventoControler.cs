using GestorEventos.Compartido.Controllers;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Api para validar si hay algun evento en una fecha
    public class EventoControler : Microsoft.AspNetCore.Mvc.Controller
    {
        EventoService service;
        public EventoControler(IService<Evento> service) 
        {
            this.service = (EventoService)service;
        }

        [HttpGet("{date:DateTime}")]
        public IActionResult GetById(DateTime date)
        {
            try
            {
                //Console.WriteLine(this.service.CheckDateEvent(date));
                return  Ok(this.service.CheckDateEvent(date));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
