namespace GestorEventos.Servicios.Entidades
{
    public class Persona : Entidad
	{
        public override string SQL_GetAll() => "SELECT * FROM Personas WHERE Borrado=0";
        public override string SQL_GetByID() => "SELECT * FROM Personas WHERE Borrado=0 AND IdPersona={0}";
        public override string SQL_Add() => "INSERT INTO Personas (IdLocalidad, Nombre, Apellido, Telefono, Email, DireccionCalle, DireccionNumero, DireccionPiso, DireccionDepartamento, GoogleIdentifier) " +
                                                        "VALUES (@IdLocalidad,  @Nombre,  @Apellido,  @Telefono,  @Email,  @DireccionCalle,  @DireccionNumero,  @DireccionPiso,  @DireccionDepartamento, @GoogleIdentifier)";
        public override string SQL_Delete() => "UPDATE Personas SET Borrado=1 WHERE IdPersona={0}";
        public override string SQL_Modify() => "UPDATE Personas SET IdLocalidad=@IdLocalidad, Nombre=@Nombre, Apellido= @Apellido, Telefono=@Telefono, Email=@Email, DireccionCalle=@DireccionCalle, DireccionNumero=@DireccionNumero, DireccionPiso=@DireccionPiso, DireccionDepartamento=@DireccionDepartamento WHERE IdPersona={0}";

        public int IdPersona { get; set; }
        public int IdLocalidad { get; set; }
        public string Nombre { get; set; } 
		public string Apellido { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }

        public string DireccionCalle { get; set; }
        public int DireccionNumero { get; set; }
        public int DireccionPiso { get; set; }
        public string DireccionDepartamento { get; set; }
    }
}
