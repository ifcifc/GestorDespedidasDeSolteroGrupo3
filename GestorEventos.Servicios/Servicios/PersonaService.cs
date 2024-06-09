using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models.Persona;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService : Service<Persona>
    {
        PersonaService(): base() { }

        private const string SQL_GetByGoogleIdentifier = "SELECT * FROM Personas WHERE IsDelete=0 AND GoogleIdentifier='{0}';";

        public PersonaGoogleIdentifier? GetByGoogleIdentifier(string identifier) {
            using (var db = SQLConnect.New())
            {
                return db.QueryFirst<PersonaGoogleIdentifier>(string.Format(SQL_GetByGoogleIdentifier, identifier));
            }
        }

    }
}
