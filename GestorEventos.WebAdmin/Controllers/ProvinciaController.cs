﻿using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestorEventos.Compartido.Controller;


namespace GestorEventos.WebAdmin.Controllers
{
    public class ProvinciaController : WebController<Provincia>
    {
        public ProvinciaController(IService<Provincia> service) : base(service)
        {
        }
    }
}
