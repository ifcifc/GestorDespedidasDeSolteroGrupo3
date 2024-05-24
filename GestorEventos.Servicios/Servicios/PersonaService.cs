using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService : Service<Persona>
	{
        public override string SQL_GetAll => "SELECT * FROM Personas WHERE IsDelete=0;";
        public override string SQL_GetByID => "SELECT * FROM Personas WHERE IsDelete=0 AND IdPersona={0};";
        public override string SQL_Add => "INSERT INTO Personas ([IdLocalidad], [Nombre], [Apellido], [Telefono], [Email], [DireccionCalle], [DireccionNumero], [DireccionPiso], [DireccionDepartamento]) " +
                                                        "VALUES (@IdLocalidad,  @Nombre,  @Apellido,  @Telefono,  @Email,  @DireccionCalle,  @DireccionNumero,  @DireccionPiso,  @DireccionDepartamento);";
        public override string SQL_Delete => "UPDATE Personas SET IsDelete=1 WHERE IdPersona={0};";
        public override string SQL_Modify => "UPDATE Personas SET IdLocalidad=@IdLocalidad, Nombre=@Nombre, Apellido= @Apellido, Telefono=@Telefono, Email=@Email, DireccionCalle=@DireccionCalle, DireccionNumero=@DireccionNumero, DireccionPiso=@DireccionPiso, DireccionDepartamento=@DireccionDepartamento WHERE IdPersona={0};";

        public PersonaService()
		{
		}

    }
}
