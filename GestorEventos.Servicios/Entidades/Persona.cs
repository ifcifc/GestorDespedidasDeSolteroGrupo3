﻿using System.Text;

namespace GestorEventos.Servicios.Entidades
{
    public class Persona : Entidad
	{
        public override string SQL_GetAll() => "SELECT * FROM Personas WHERE Borrado=0 ORDER BY Nombre";
        public override string SQL_GetByID() => "SELECT * FROM Personas WHERE Borrado=0 AND IdPersona={0} ORDER BY Nombre";
        public override string SQL_Add() => "INSERT INTO Personas (IdLocalidad, Nombre, Apellido, Telefono, Email, DireccionCalle, DireccionNumero, DireccionPiso, DireccionDepartamento, IdUsuario) " +
                                                        "VALUES (@IdLocalidad,  @Nombre,  @Apellido,  @Telefono,  @Email,  @DireccionCalle,  @DireccionNumero,  @DireccionPiso,  @DireccionDepartamento, @IdUsuario)";
        public override string SQL_Delete() => "UPDATE Personas SET Borrado=1 WHERE IdPersona={0}";
        public override string SQL_Modify() => "UPDATE Personas SET IdLocalidad=@IdLocalidad, Nombre=@Nombre, Apellido= @Apellido, Telefono=@Telefono, Email=@Email, DireccionCalle=@DireccionCalle, DireccionNumero=@DireccionNumero, DireccionPiso=@DireccionPiso, DireccionDepartamento=@DireccionDepartamento WHERE IdPersona={0}";

        public int IdPersona { get; set; }
        public int IdLocalidad { get; set; }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } 
		public string Apellido { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }

        public string DireccionCalle { get; set; }
        public int DireccionNumero { get; set; }
        public int DireccionPiso { get; set; }
        public string DireccionDepartamento { get; set; }

        public string getBasicInfo() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.Nombre);
            stringBuilder.Append(" ");
            stringBuilder.Append(this.Apellido);
            stringBuilder.Append(" ");
            stringBuilder.Append(this.Email);
            return stringBuilder.ToString();
        }
    }
}
