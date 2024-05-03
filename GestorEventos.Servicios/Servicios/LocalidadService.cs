using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorEventos.Servicios.Servicios
{
    public class LocalidadService
    {
        public IEnumerable<Localidad> Localidades { get; set; }
        public LocalidadService() {
            this.Localidades = new List<Localidad> {
                new Localidad{IdLocalidad=1, IdProvincia=1, Nombre="Ciudad 1", CodigoArea=1},
                new Localidad{IdLocalidad=2, IdProvincia=2, Nombre="Ciudad 2", CodigoArea=2},
                new Localidad{IdLocalidad=3, IdProvincia=3, Nombre="Ciudad 3", CodigoArea=3},
            };
        }

        public IEnumerable<Localidad> GetLocalidades()
        {
            return this.Localidades;
        }

        public Localidad GetLocalidadPorId(int idLocalidad)
        {
            var localidad = this.Localidades.Where(x => x.IdLocalidad == idLocalidad);

            if (localidad == null)
                return null;

            return localidad.First();
        }

        public bool AgregarLocalidad(Localidad localidad)
        {
            try
            {
                List<Localidad> lista = this.Localidades.ToList();
                lista.Add(localidad);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
