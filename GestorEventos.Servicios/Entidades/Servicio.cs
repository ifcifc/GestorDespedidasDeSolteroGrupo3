using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
	public class Servicio
	{
		public int IdServicio { get; set; }
		public string Descripcion { get; set; }

        //decimal->similar a float, muy alta precision decimal, usar para manejar dinero 
        public decimal PrecioServicio { get; set; }

        public bool isDelete;
    }
}
