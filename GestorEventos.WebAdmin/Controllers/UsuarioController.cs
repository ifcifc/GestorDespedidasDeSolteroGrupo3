using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;
using GestorEventos.Servicios.Controllers;

namespace GestorEventos.WebAdmin.Controllers
{
    public class UsuarioController : WebController<Usuario>
    {
        public UsuarioController(IService<Usuario> service) : base(service)
        {
        }


    }
}
