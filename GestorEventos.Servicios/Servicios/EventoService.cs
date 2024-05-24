
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class EventoService : Service<Evento>
    {
        public override string SQL_GetAll => "SELECT * FROM Eventos WHERE IsDelete=0;";
        public override string SQL_GetByID => "SELECT * FROM Eventos WHERE IsDelete=0 AND IdEvento={0};";
        public override string SQL_Add => "INSERT INTO Eventos ([IdTipoEvento], [IdPersonaAgasajada], [IdPersonaContacto], [NombreEvento], [FechaEvento], [CantidadPersonas]) " +
                                                       "VALUES (@IdTipoEvento,  @IdPersonaAgasajada,  @IdPersonaContacto,  @NombreEvento,  @FechaEvento,  @CantidadPersonas);";
        public override string SQL_Delete => "UPDATE Eventos SET IdTipoEvento=@IdTipoEvento, IdPersonaAgasajada=@IdPersonaAgasajada, IdPersonaContacto=@IdPersonaContacto, NombreEvento=@NombreEvento, FechaEvento=@FechaEvento, CantidadPersonas=@CantidadPersonas  WHERE IdEvento={0}";
        public override string SQL_Modify => "UPDATE Eventos SET IsDelete=1 WHERE IdEvento={0};";

        public EventoService()
		{
			
		}


	}
}
