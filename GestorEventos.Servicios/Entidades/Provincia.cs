using System.ComponentModel.DataAnnotations;

namespace GestorEventos.Servicios.Entidades
{
    public class Provincia : Entidad
    {
        public override string SQL_GetAll() => "SELECT * FROM Provincias WHERE IsDelete=0;";
        public override string SQL_GetByID() => "SELECT * FROM Provincias WHERE IsDelete=0 AND IdProvincia={0};";
        public override string SQL_Add() => "INSERT INTO Provincias ([Nombre]) VALUES (@Nombre);";
        public override string SQL_Delete() => "UPDATE Provincias SET IsDelete=1 WHERE IdProvincia={0};";
        public override string SQL_Modify() => "UPDATE Provincias SET Nombre=@Nombre WHERE IdProvincia={0};";
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return string.Format("Provincia[IdProvincia: {0}, Nombre: {1}, IsDelete: {2}]", this.IdProvincia, this.Nombre, this.IsDelete);
        }
    }
}
