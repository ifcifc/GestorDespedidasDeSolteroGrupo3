using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
	public class Servicio : Entidad
    {
        public int IdServicio { get; set; }
		public string Descripcion { get; set; }

        //decimal->similar a float, muy alta precision decimal, usar para manejar dinero 
        public decimal PrecioServicio { get; set; }
        public override string ToString()
        {
            return string.Format(
                "Servicio[IdServicio: {0}, Descripcion: {1}, PrecioServicio: {2}, isDelete]: {3}",
                this.IdServicio, this.Descripcion, this.PrecioServicio, this.IsDelete);
        }
    }
}
