using Mysqlx.Crud;
using System.ComponentModel.DataAnnotations;

namespace GestorEventos.Servicios.Entidades
{
    public class Evento : Entidad
	{
        public override string SQL_GetAll() => "SELECT * FROM Eventos WHERE Borrado=0";
        public override string SQL_GetByID() => "SELECT * FROM Eventos WHERE Borrado=0 AND IdEvento={0}";
        public override string SQL_Add() => "INSERT INTO Eventos(NombreEvento, FechaEvento, CantidadPersonas, IdTipoEvento, IdPersonaAgasajada, IdUsuario, IdEstadoEvento)" +
                                                        "VALUES(@NombreEvento, @FechaEvento, @CantidadPersonas, @IdTipoEvento, @IdPersonaAgasajada, @IdUsuario, @IdEstadoEvento)";
        public override string SQL_Modify() => "UPDATE Eventos SET NombreEvento = @NombreEvento, FechaEvento = @FechaEvento, CantidadPersonas = @CantidadPersonas, IdTipoEvento = @IdTipoEvento, IdPersonaAgasajada = @IdPersonaAgasajada, IdEstadoEvento = @IdEstadoEvento WHERE IdEvento={0}";
        public override string SQL_Delete() => "UPDATE Eventos SET Borrado=1 WHERE IdEvento={0}";
        
        public int IdEvento { get; set; }
		public string NombreEvento { get; set; }
		public DateTime FechaEvento { get; set; }
		public int CantidadPersonas { get; set; }
		public int IdTipoEvento { get; set; }
		public int IdPersonaAgasajada { get; set; }
		public int IdUsuario { get; set; }
		public int IdEstadoEvento { get; set; }


		//public int IdPersonaContacto { get; set; }
    }
}
