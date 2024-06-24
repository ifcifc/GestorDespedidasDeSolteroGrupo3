using GestorEventos.Servicios.Controller;
using GestorEventos.Servicios.Controllers;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using GestorEventos.WebClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestorEventos.WebClient.Controllers
{
    [Authorize]
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

        public IActionResult Reserva()
        {
            return View();
        }
    }
}
