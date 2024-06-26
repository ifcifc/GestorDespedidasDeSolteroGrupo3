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
        public const string SQL_Add_GET_ID = "INSERT INTO Eventos(NombreEvento, FechaEvento, CantidadPersonas, IdTipoEvento, IdPersonaAgasajada, IdUsuario, IdEstadoEvento)" +
                                                          "VALUES(@NombreEvento, @FechaEvento, @CantidadPersonas, @IdTipoEvento, @IdPersonaAgasajada, @IdUsuario, @IdEstadoEvento); SELECT {0}";
        public int AddGetID(Evento entity)
        {
            using (var db = SQLConnect.New().Transaction())
            {
                return db.ExecuteScalar<int>(string.Format(SQL_Add_GET_ID,
                    (SQLConnect.CONNECTION_TYPE == ConnectionTypes.MSSQL) ?
                        "CAST(SCOPE_IDENTITY() AS int)" : "LAST_INSERT_ID()")
                    , entity); ;
            }
        }

        

    }
}
