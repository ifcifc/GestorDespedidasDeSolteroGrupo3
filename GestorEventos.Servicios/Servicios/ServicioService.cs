
using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class ServicioService
	{
		public IEnumerable<Servicio> Servicios { get; set; }

		public ServicioService ()
		{
			this.Servicios = new List<Servicio>
			{
				new Servicio{ IdServicio = 1, Descripcion = "Bar Hopping", PrecioServicio = 25000 },
				new Servicio{ IdServicio = 2, Descripcion = "Servicio de Transporte", PrecioServicio = 20000 },
				new Servicio{ IdServicio = 3, Descripcion = "Entradas de Boliches Incluidas", PrecioServicio = 10000 }
			};
		}

		public IEnumerable<Servicio> GetServicios()
		{
			return this.Servicios.Where(e => !e.isDelete); ;
		}

		public Servicio GetServicioPorId(int IdServicio)
		{
			var servicios = Servicios.Where(x => x.IdServicio == IdServicio);

            return (servicios == null)? null : servicios.First();
		}


		public bool Agregar(Servicio servicio)
		{
			try
			{
				List<Servicio> lista = this.Servicios.ToList();
				lista.Add(servicio);
//				this.Servicios.ToList().Add(servicio);
			}
			catch(Exception ex)
			{
				return false;
			}

            return true;
        }
        public bool Eliminar(int idServicio)
        {
            try
            {
                var e = this.Servicios.FirstOrDefault(x => x.IdServicio == idServicio);
                e.isDelete = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Modificar(int idServicio, Servicio servicio)
        {

            var e = this.Servicios.FirstOrDefault(x => x.IdServicio == idServicio);
            if (e == null) return false;

            e.Descripcion = servicio.Descripcion;
            e.PrecioServicio = servicio.PrecioServicio;

            return true;
        }
    }
}
