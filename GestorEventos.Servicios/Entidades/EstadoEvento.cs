using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class EstadoEvento : Entidad
    {
        public override string SQL_Add() => "INSERT INTO EstadosEventos(Descripcion) VALUES (@Descripcion)";
        public override string SQL_Delete() => "UPDATE EstadosEventos SET Borrado=1 WHERE IdEstadoEvento={0}";
        public override string SQL_GetAll() => "SELECT * FROM EstadosEventos WHERE Borrado=False";
        public override string SQL_GetByID() => "SELECT * FROM EstadosEventos WHERE Borrado=False AND IdEstadoEvento={0}";
        public override string SQL_Modify() => "UPDATE EstadosEventos SET Descripcion=@Descripcion WHERE IdEstadoEvento={0}";
        public int IdEstadoEvento { get;set; }
        public string Descripcion { get; set; }
    }
}
