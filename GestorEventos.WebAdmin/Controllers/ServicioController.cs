﻿using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestorEventos.WebAdmin.Controllers
{
    public class ServicioController : WebController<ServicioService, Servicio>
    {
      
    }
}
