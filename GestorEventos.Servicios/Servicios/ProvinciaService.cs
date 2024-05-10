
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

		public IEnumerable<Provincia> GetProvincias()
		{
			return this.Provincias.Where(e => !e.isDelete); ;
		}

		public Provincia GetProvinciaPorId(int idProvincia)
		{
			var provincia = this.Provincias.Where(x => x.IdProvincia == idProvincia);

			return (provincia == null)? null : provincia.First();
		}


		public bool Agregar(Provincia provincia)
		{
			try
			{
				List<Provincia> lista = this.Provincias.ToList();
				lista.Add(provincia);
			}
			catch(Exception ex)
			{
				return false;
            }
            return true;
        }

        public bool Eliminar(int idProvincia)
        {
            try
            {
                var e = this.Provincias.FirstOrDefault(x => x.IdProvincia == idProvincia);
                e.isDelete = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Modificar(int idProvincia, Provincia provincia)
        {

            var e = this.Provincias.FirstOrDefault(x => x.IdProvincia == idProvincia);
            if (e == null) return false;

            e.Nombre = e.Nombre;

            return true;
        }
    }
}
