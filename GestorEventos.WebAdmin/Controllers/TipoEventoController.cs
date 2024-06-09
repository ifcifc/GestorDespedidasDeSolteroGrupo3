﻿using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;

namespace GestorEventos.WebAdmin.Controllers
{
    public class TipoEventoController : WebController<TipoEvento>
    {
        public TipoEventoController(IService<TipoEvento> service) : base(service)
        {
        }
    }
}