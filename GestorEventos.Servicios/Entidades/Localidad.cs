using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Localidad : Entidad
    {
        public int IdLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        public int CodigoArea { get; set;}

        public override string ToString()
        {
            return string.Format("Localidad[IdLocalidad: {0}, IdProvincia:{1}, Nombre: {2}, CodigoArea: {3}]", IdLocalidad, IdProvincia, Nombre, CodigoArea);
        }
    }
}
