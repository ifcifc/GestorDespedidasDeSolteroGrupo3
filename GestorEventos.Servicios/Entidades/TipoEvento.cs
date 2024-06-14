using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
	public class TipoEvento : Entidad
	{
        public override string SQL_GetAll() => "SELECT * FROM TiposEventos WHERE Borrado=0";
        public override string SQL_GetByID() => "SELECT * FROM TiposEventos WHERE Borrado=0 AND IdTipoEvento={0}";
        public override string SQL_Add() => "INSERT INTO TiposEventos (Descripcion) VALUES (@Descripcion)";
        public override string SQL_Delete() => "UPDATE TiposEventos SET Borrado=1 WHERE IdTipoEvento={0}";
        public override string SQL_Modify() => "UPDATE TiposEventos SET Descripcion=@Descripcion WHERE IdTipoEvento={0}";
        public int IdTipoEvento { get; set; }
		public string Descripcion { get; set; }
    }
}
