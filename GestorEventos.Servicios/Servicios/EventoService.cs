using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class EventoService : Service<Evento>
    {
        private const string SQL_EventoDeUsuario = "SELECT count(*)  FROM Eventos WHERE IdUsuario={0} AND IdEvento={1}";
        private const string SQL_CheckDateEvent = """
                                                    SELECT count(*) 
                                                    FROM gestorevento.Eventos 
                                                    WHERE 	YEAR(FechaEvento)  = {0} AND
                                                            MONTH(FechaEvento) = {1} AND
                                                            DAY(FechaEvento)   = {2} AND
                                                            IdEstadoEvento     = 2
                                                  """;

        //IdEstadoEvento = 2 es cuando el evento fue aceptado
        public bool CheckDateEvent(DateTime date)
        {
            using (var db = SQLConnect.New())
            {
                int count = db.ExecuteScalar<int>(string.Format(
                    SQL_CheckDateEvent,
                    date.Year,
                    date.Month,
                    date.Day));

                return count > 0;
            }
        }

        public bool EventoDeUsuario(int IdPersona, int IdUsuario)
        {
            using (var db = SQLConnect.New())
            {
                int count = db.ExecuteScalar<int>(string.Format(
                    SQL_EventoDeUsuario,
                    IdUsuario, IdPersona));
                return count > 0;
            }
        }
    }
}
