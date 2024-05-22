
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQL;

namespace GestorEventos.Servicios.Servicios
{
    public class EventoService
	{
		public EventoService()
		{
		}

		public IEnumerable<Evento>? Get()
		{
			return SQLConnect.Query<Evento>("SELECT * FROM Eventos WHERE Borrado = 0");
		}

		public Evento? GetPorId(int IdEvento)
		{
			return SQLConnect.QueryFirst<Evento>("SELECT * FROM Eventos WHERE IdEvento = " + IdEvento);
        }


		public bool Crear(Evento evento)
		{
            string query = "INSERT INTO Eventos (NombreEvento, FechaEvento, CantidadPersonas, IdPersonaAgasajada, IdPersonaContacto, IdTipoEvento, Borrado, Visible) VALUES (@NombreEvento, @FechaEvento, @CantidadPersonas, @IdPersonaAgasajada, @IdPersonaContacto, @IdTipoEvento, 0, 0);";
            return SQLConnect.Execute(query, evento);

        }

        public bool Eliminar(int IdEvento)
        {
            string query = "UPDATE Eventos SET Borrado = 1 where IdEvento = " + IdEvento;
			return SQLConnect.Execute(query);
		}

        public  bool Modificar(int IdEvento, Evento evento)
        {
			string query = "UPDATE Eventos SET IdTipoEvento=@IdTipoEvento, IdPersonaAgasajada=@IdPersonaAgasajada, IdPersonaContacto=@IdPersonaContacto, NombreEvento=@NombreEvento, FechaEvento=@FechaEvento, CantidadPersonas=@CantidadPersonas  WHERE IdEvento=" + IdEvento;
            return SQLConnect.Execute(query, evento);
        }

    }
}
