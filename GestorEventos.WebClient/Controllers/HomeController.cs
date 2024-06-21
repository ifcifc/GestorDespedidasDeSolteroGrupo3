using GestorEventos.Servicios.Controller;
using GestorEventos.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestorEventos.WebClient.Controllers
{
    public class HomeController : SimpleController
    {

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Reserva()
        {
            return View();
        }
    }
}
