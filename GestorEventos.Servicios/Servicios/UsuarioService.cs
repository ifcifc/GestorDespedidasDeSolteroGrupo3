using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class UsuarioService : Service<Usuario>
    {
        public const string SQL_GetByGoogleIdentificador = "SELECT * FROM Usuarios WHERE GoogleIdentificador={0}";
        public const string SQL_Add_GET_ID = "INSERT INTO Usuarios (GoogleIdentificador, NombreCompleto, Nombre, Apellido, Email) VALUES (@GoogleIdentificador, @NombreCompleto, @Nombre, @Apellido, @Email); SELECT {0}";

        public Usuario? GetByGoogleIdentifier(string identifier)
        {
            using (var db = SQLConnect.New())
            {
                return db.QueryFirst<Usuario>(string.Format(SQL_GetByGoogleIdentificador, identifier));
            }
        }

        public int AddGetID(Usuario entity)
        {
            using (var db = SQLConnect.New().Transaction())
            {
                return db.ExecuteScalar<int>(string.Format(SQL_Add_GET_ID,
                    (SQLConnect.CONNECTION_TYPE == ConnectionTypes.MSSQL) ?
                        "CAST(SCOPE_IDENTITY() AS int" : "LAST_INSERT_ID()")
                    , entity); ;
            }
        }
    }
}
