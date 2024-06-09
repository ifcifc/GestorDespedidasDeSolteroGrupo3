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
        public abstract string SQL_GetAll();
        public abstract string SQL_GetByID();
        public abstract string SQL_Add();
        public abstract string SQL_Delete();
        public abstract string SQL_Modify();

        public Entidad(){}

        [ScaffoldColumn(false)]
        public bool IsDelete { get; set; }

        public abstract string ToString();
    }
}
