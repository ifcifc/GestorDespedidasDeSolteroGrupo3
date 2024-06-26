﻿using GestorEventos.Servicios.Entidades;
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
        //IdEstadoEvento = 2 es cuando el evento fue aceptado
        private const string SQL_CheckDateEvent = """
                                                    SELECT count(*) 
                                                    FROM gestorevento.Eventos 
                                                    WHERE 	YEAR(FechaEvento)  = {0} AND
                                                            MONTH(FechaEvento) = {1} AND
                                                            DAY(FechaEvento)   = {2} AND
                                                            IdEstadoEvento     = 2
                                                  """;

        

        //Comprueba si hay un evento aceptado en cierta fecha
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

        //Comprueba si el evento es del usuario
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
