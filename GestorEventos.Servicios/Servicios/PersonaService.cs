using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using static Dapper.SqlMapper;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService : Service<Persona>
    {
        public override string SQL_GetAll => "SELECT * FROM Personas WHERE IsDelete=0;";
        public override string SQL_GetByID => "SELECT * FROM Personas WHERE IsDelete=0 AND IdPersona={0};";
        public override string SQL_Add => "INSERT INTO Personas ([IdLocalidad], [Nombre], [Apellido], [Telefono], [Email], [DireccionCalle], [DireccionNumero], [DireccionPiso], [DireccionDepartamento], [GoogleIdentifier]) " +
                                                        "VALUES (@IdLocalidad,  @Nombre,  @Apellido,  @Telefono,  @Email,  @DireccionCalle,  @DireccionNumero,  @DireccionPiso,  @DireccionDepartamento, @GoogleIdentifier);";
        public override string SQL_Delete => "UPDATE Personas SET IsDelete=1 WHERE IdPersona={0};";
        public override string SQL_Modify => "UPDATE Personas SET IdLocalidad=@IdLocalidad, Nombre=@Nombre, Apellido= @Apellido, Telefono=@Telefono, Email=@Email, DireccionCalle=@DireccionCalle, DireccionNumero=@DireccionNumero, DireccionPiso=@DireccionPiso, DireccionDepartamento=@DireccionDepartamento WHERE IdPersona={0};";

        private readonly string SQL_GetByGoogleIdentifier = "SELECT * FROM Personas WHERE IsDelete=0 AND GoogleIdentifier='{0}';";

        public PersonaService()
		{
		}

        public Persona? GetByGoogleIdentifier(string googleIdentifier) {
            return SQLExecute
                    .New()
                    .QueryFirst<Persona>(string.Format(SQL_GetByGoogleIdentifier, googleIdentifier));
        }

    }
}
