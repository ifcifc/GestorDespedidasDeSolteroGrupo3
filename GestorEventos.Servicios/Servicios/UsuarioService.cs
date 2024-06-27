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

        //Obtiene un Usuario segun su GoogleIdentifier
        public Usuario? GetByGoogleIdentifier(string identifier)
        {
            using (var db = SQLConnect.New())
            {
                return db.QueryFirst<Usuario>(string.Format(SQL_GetByGoogleIdentificador, identifier));
            }
        }

    }
}
