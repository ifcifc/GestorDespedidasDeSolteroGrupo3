﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
	//Una entidad que represente a las personas del sistema
	public class Persona
	{
		/*
		 IdPersona, Nombre, Apellido, Dirección, Teléfono, Email

		 */
		public int IdPersona { get; set; }

		public string Nombre { get; set; } 
		public string Apellido { get; set; }
		//public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }

		public int IdLocalidad {  get; set; }

        public string DireccionCalle { get; set; }
        public int DireccionNumero { get; set; }
        public int DireccionPiso { get; set; }
        public string DireccionDepartamento { get; set; }

    }
}
