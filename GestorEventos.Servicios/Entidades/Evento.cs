using System.ComponentModel.DataAnnotations;

namespace GestorEventos.Servicios.Entidades
{
    public class Evento : Entidad
	{
        public override string SQL_GetAll() => "SELECT * FROM Eventos WHERE IsDelete=0";
        public override string SQL_GetByID() => "SELECT * FROM Eventos WHERE IsDelete=0 AND IdEvento={0}";
        public override string SQL_Add() => "INSERT INTO Eventos (IdTipoEvento, IdPersonaAgasajada, IdPersonaContacto, NombreEvento, FechaEvento, CantidadPersonas) " +
                                                       "VALUES (@IdTipoEvento,  @IdPersonaAgasajada,  @IdPersonaContacto,  @NombreEvento,  @FechaEvento,  @CantidadPersonas)";
        public override string SQL_Delete() => "UPDATE Eventos SET IdTipoEvento=@IdTipoEvento, IdPersonaAgasajada=@IdPersonaAgasajada, IdPersonaContacto=@IdPersonaContacto, NombreEvento=@NombreEvento, FechaEvento=@FechaEvento, CantidadPersonas=@CantidadPersonas  WHERE IdEvento={0}";
        public override string SQL_Modify() => "UPDATE Eventos SET IsDelete=1 WHERE IdEvento={0}";
      

        public int IdEvento { get; set; }
		public string NombreEvento { get; set; }
		public DateTime FechaEvento { get; set; }
		public int CantidadPersonas { get; set; }
		public int IdTipoEvento { get; set; }
		public int IdPersonaAgasajada { get; set; }

		public int IdPersonaContacto { get; set; }

        public override string ToString()
        {
            return string.Format("Evento[IdEvento: {0}, NombreEvento:{1}, FechaEvento: {2}, FechaEvento: {3}, CantidadPersonas:{4}, IdTipoEvento:{5}, IdPersonaAgasajada: {6}, IdPersonaContacto: {7}, IsDelete: {8}]",
                                IdEvento, NombreEvento, FechaEvento.ToString(), CantidadPersonas, IdTipoEvento, IdPersonaAgasajada, IdPersonaContacto, IsDelete);
        }
    }
}
