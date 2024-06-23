using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService : Service<Persona>
    {

        private const string SQL_PersonaDeUsuario = "SELECT count(*)  FROM Personas WHERE IdUsuario={0} AND IdPersona={1}";



        public bool PersonaDeUsuario(int IdPersona, int IdUsuario) 
        {
            using (var db = SQLConnect.New())
            {
                int count = db.ExecuteScalar<int>(string.Format(
                    SQL_PersonaDeUsuario,
                    IdUsuario, IdPersona));

                return count > 0;
            }
        }
    }
}
