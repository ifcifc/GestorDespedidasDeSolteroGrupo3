using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQL;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService
	{
		
		//constructor
		public PersonaService()
		{
			
		}

        public IEnumerable<Persona>? Get()
        {
            return SQLConnect.Query<Persona>("SELECT * FROM Personas WHERE Borrado = 0");
        }

        public Persona? GetPorId(int IdPersona)
        {
            return SQLConnect.QueryFirst<Persona>("SELECT * FROM Personas WHERE IdPersona = " + IdPersona);
        }


        public bool Crear(Persona persona)
        {
            string query = "INSERT INTO Personas (Nombre, Apellido, Direccion, Telefono, Email) VALUES ( @Nombre, @Apellido, @Direccion, @Telefono, @Email);";
            return SQLConnect.Execute(query, persona);

        }

        public bool Eliminar(int idPersona)
        {
            string query = "UPDATE Personas SET Borrado = 1 where IdPersona = " + idPersona;
            return SQLConnect.Execute(query);
        }

        public bool Modificar(int idPersona, Persona persona)
        {
            string query = "UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono, Email = @Email  WHERE IdPersona = " + idPersona;
            return SQLConnect.Execute(query, persona);
        }


    }
}
