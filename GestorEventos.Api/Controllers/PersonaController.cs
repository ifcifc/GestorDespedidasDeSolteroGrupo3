using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{

    public class PersonaController : BaseController<Persona>
    {
        public PersonaController(IService<Persona> service) : base(service)
        {
        }
    }
}
