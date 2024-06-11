using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Usuario : Entidad
    {
        public override string SQL_GetAll() => "SELECT * FROM Usuarios WHERE IsDelete=0";
        public override string SQL_GetByID() => "SELECT * FROM Usuarios WHERE IsDelete=0 AND IdUsuario={0}";
        public override string SQL_Add() => "INSERT INTO Usuarios (GoogleIdentificador, NombreCompleto, Nombre, Apellido, Email) VALUES (@GoogleIdentificador, @NombreCompleto, @Nombre, @Apellido, @Email)";
        public override string SQL_Delete() => "UPDATE Usuarios SET IsDelete=1 WHERE IdUsuario={0}";
        public override string SQL_Modify() => "UPDATE Usuarios SET GoogleIdentificador=@GoogleIdentificador, NombreCompleto=@NombreCompleto, Nombre=@Nombre, Apellido=@Apellido, Email=@Email WHERE IdUsuario={0}";
        
        public const string SQL_GetByGoogleIdentificador = "UPDATE Usuarios SET GoogleIdentificador=@GoogleIdentificador, NombreCompleto=@NombreCompleto, Nombre=@Nombre, Apellido=@Apellido, Email=@Email WHERE IdUsuario={0}";
        public const string SQL_Add_GET_ID = "INSERT INTO Usuarios (GoogleIdentificador, NombreCompleto, Nombre, Apellido, Email) VALUES (@GoogleIdentificador, @NombreCompleto, @Nombre, @Apellido, @Email); SELECT {0}";

        public override string ToString() {
            return "";   
        }

        public int IdUsuario { get; set; }
        public string GoogleIdentificador { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }
    }
}
