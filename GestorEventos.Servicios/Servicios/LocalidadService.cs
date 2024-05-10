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
            return this.Localidades.Where(e => !e.isDelete); ;
        }

        public Localidad GetLocalidadPorId(int idLocalidad)
        {
            var localidad = this.Localidades.Where(x => x.IdLocalidad == idLocalidad);

            return (localidad == null) ? null : localidad.First();
        }

        public bool Agregar(Localidad localidad)
        {
            try
            {
                List<Localidad> lista = this.Localidades.ToList();
                lista.Add(localidad);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Modificar(int idLocalidad, Localidad localidad)
        {

            var e = this.Localidades.FirstOrDefault(x => x.IdLocalidad == idLocalidad);
            if (e == null) return false;

            e.IdProvincia = localidad.IdProvincia;
            e.CodigoArea = localidad.CodigoArea;
            e.Nombre = localidad.Nombre;

            return true;
        }

        public bool Eliminar(int idLocalidad)
        {
            try
            {
                var e = this.Localidades.FirstOrDefault(x => x.IdLocalidad == idLocalidad);
                e.isDelete = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }


}
