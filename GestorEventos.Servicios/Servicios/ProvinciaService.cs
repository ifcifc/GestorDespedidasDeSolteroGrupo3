
using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class ProvinciaService
	{
		public IEnumerable<Provincia> Provincias { get; set; }

		public ProvinciaService()
		{
			this.Provincias = new List<Provincia>
            {
                new Provincia{ IdProvincia = 1, Nombre="Buenos Aires"},
                new Provincia{ IdProvincia = 2, Nombre="Jujuy"},
                new Provincia{ IdProvincia = 3, Nombre="Cordoba"},
            };
		}

		public IEnumerable<Provincia> Get()
		{
			return this.Provincias;
		}

		public Provincia GetPorId(int idProvincia)
		{
			var provincia = this.Provincias.Where(x => x.IdProvincia == idProvincia);

			if (provincia == null)
				return null;

			return provincia.First();
		}


		public bool Crear(Provincia provincia)
		{
			try
			{
				List<Provincia> lista = this.Provincias.ToList();
				lista.Add(provincia);
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}

		}

	}
}
