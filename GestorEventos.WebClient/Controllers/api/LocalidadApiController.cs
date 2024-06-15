using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using GestorEventos.WebAdmin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebClient.Controllers.api
{
    public class LocalidadApiController : GestorEventos.WebAdmin.Controllers.Api.LocalidadApiController
    {
        public LocalidadApiController(IService<LocalidadesProvincia> service) : base(service)
        {
        }
    }
}
