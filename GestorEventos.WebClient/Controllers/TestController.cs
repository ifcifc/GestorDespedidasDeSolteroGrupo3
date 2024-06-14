using GestorEventos.Servicios.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebClient.Controllers
{
    [Authorize]
    public class TestController : SimpleController
    {
        
    }
}
