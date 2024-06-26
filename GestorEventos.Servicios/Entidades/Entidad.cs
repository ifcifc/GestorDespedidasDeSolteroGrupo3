using GestorEventos.Servicios.Entidades.Models;
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
        public virtual string SQL_GetAllByID() => "";
        public virtual string SQL_Add_GET_ID() => "";

        public Entidad(){}

        [ScaffoldColumn(false)]
        public bool Borrado { get; set; }

        public string ToString() {
            System.Type type = this.GetType();


            StringBuilder toString = new StringBuilder();
            toString.Append(type.Name).Append("[");

            foreach (var item in type.GetProperties())
            {
                var value = item.GetValue(this) ?? "";
                toString.Append(item.Name).Append(":").Append(value).Append(", ");
            }

            toString.Length -= 2;
            toString.Append("]");
            return toString.ToString();
        }
    }
}
