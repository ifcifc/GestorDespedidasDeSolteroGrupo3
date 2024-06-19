using GestorEventos.Servicios.Controllers;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebAdmin.Controllers
{
    public class EstadoEventoController : WebController<EstadoEvento>
    {
        public EstadoEventoController(IService<EstadoEvento> service) : base(service)
        {

        }
    }
}
