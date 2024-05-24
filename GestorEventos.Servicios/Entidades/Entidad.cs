using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public abstract class Entidad
    {

        public Entidad(){}

        [ScaffoldColumn(false)]
        public bool IsDelete { get; set; }

        public abstract string ToString();
    }
}
