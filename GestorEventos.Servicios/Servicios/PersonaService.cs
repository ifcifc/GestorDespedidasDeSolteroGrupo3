using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;

namespace GestorEventos.Servicios.Servicios
{
    public class PersonaService : Service<Persona>
    {

        private const string SQL_PersonaDeUsuario = "SELECT count(*)  FROM Personas WHERE IdUsuario={0} AND IdPersona={1}";


        //Verifica si la Persona pertenece al usuario
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
