using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GestorEventos.Servicios.Controllers;

namespace GestorEventos.WebAdmin.Controllers
{
    public class ServicioController : WebController<Servicio>
    {
        public ServicioController(IService<Servicio> service) : base(service)
        {
        }
    }
}
