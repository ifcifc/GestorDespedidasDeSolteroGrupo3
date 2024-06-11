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
        public Usuario? GetByGoogleIdentifier(string identifier)
        {
            using (var db = SQLConnect.New())
            {
                return db.QueryFirst<Usuario>(string.Format(Usuario.SQL_GetByGoogleIdentificador, identifier));
            }
        }

        public int AddGetID(Usuario entity)
        {
            using (var db = SQLConnect.New().Transaction())
            {

                string sql = string.Format(Usuario.SQL_Add_GET_ID, ((SQLConnect.CONNECTION_TYPE == ConnectionTypes.MSSQL) ? "CAST(SCOPE_IDENTITY() AS int" : "LAST_INSERT_ID()"));
                return db.ExecuteScalar<int>(sql, entity); 
            }
        }
    }
}
