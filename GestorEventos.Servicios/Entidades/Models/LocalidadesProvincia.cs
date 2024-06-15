using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades.Models
{
    public class LocalidadesProvincia : Localidad
    {
        public override string SQL_GetAllByID() => "SELECT * FROM Localidades WHERE Borrado=0 AND IdProvincia={0}";
        public override string SQL_Add() => "";
        public override string SQL_Delete() => "";
        public override string SQL_Modify() => "";

        
    }
}
