﻿using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
    public class ProvinciaController : BaseController<Provincia>
    {
        public ProvinciaController(IService<Provincia> service) : base(service)
        {
        }
    }
}
