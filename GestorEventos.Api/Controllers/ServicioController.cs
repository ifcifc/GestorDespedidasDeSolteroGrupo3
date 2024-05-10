﻿using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorEventos.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicioController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetServicios()
		{
			ServicioService servicioService = new ServicioService();

			return Ok(servicioService.GetServicios());
		}

		[HttpGet("{idServicio:int}")]
		public IActionResult GetServicioPorId(int idServicio)
		{
			ServicioService servicioService = new ServicioService();

			var servicio = servicioService.GetServicioPorId(idServicio);

			if (servicio == null)
				return NotFound();
			else
				return Ok(servicio);
		}

		[HttpPost("nuevo")]
		public IActionResult PostNuevoServicio([FromBody] Servicio servicionuevo)
		{

			ServicioService servicioService = new ServicioService();
            servicioService.AgregarServicio(servicionuevo);

			return Ok();
		}



	}
}