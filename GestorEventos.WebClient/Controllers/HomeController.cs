using GestorEventos.Compartido.Controller;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.WebClient.Controllers
{
    public class HomeController : SimpleController
    {
        public override ActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
