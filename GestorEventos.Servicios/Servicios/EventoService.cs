
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class EventoService : Service<Evento>
    {

		public EventoService()
		{
			
		}

		override public IEnumerable<Evento>? GetAll()
		{
			return SQLExecute
					.New()
					.Query<Evento>(SQLExecute.TEVENTO_GET_ALL);
		}

        override public Evento? GetByID(int IdEvento)
		{
            return SQLExecute
                    .New()
                    .QueryFirst<Evento>(SQLExecute.TEVENTO_GET_BY_ID, IdEvento);
        }


		override public bool Add(Evento evento)
		{
            return SQLExecute
                    .New()
					.Transaction(true)
                    .Execute(SQLExecute.TEVENTO_INSERT, 
								evento.IdTipoEvento, 
								evento.IdPersonaAgasajada, 
								evento.IdPersonaContacto, 
								evento.NombreEvento, 
								evento.FechaEvento.ToString(), 
								evento.CantidadPersonas);
        }

        override public bool Modify(int idEvento, Evento evento)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TEVENTO_MODIFY,
                                idEvento,
                                evento.IdTipoEvento,
                                evento.IdPersonaAgasajada,
                                evento.IdPersonaContacto,
                                evento.NombreEvento,
                                evento.FechaEvento.ToString(),
                                evento.CantidadPersonas);
        }

        override public bool Delete(int idEvento) 
		{
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TEVENTO_DELETE, idEvento);

        }

	}
}
