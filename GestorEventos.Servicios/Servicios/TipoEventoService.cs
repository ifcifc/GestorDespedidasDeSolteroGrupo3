using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;

namespace GestorEventos.Servicios.Servicios
{
    public class TipoEventoService : Service<TipoEvento>
    {


		public TipoEventoService() 
		{

		}

		override public IEnumerable<TipoEvento>? GetAll ()
		{
            return SQLExecute
                    .New()
                    .Query<TipoEvento>(SQLExecute.TTIPOEVENTO_GET_ALL);
		}

        override public TipoEvento? GetByID(int idTipoEvento)
		{
            return SQLExecute
                .New()
                .QueryFirst<TipoEvento>(SQLExecute.TTIPOEVENTO_GET_BY_ID, idTipoEvento);
        }
        override public bool Delete(int idTipoEvento)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TTIPOEVENTO_DELETE, idTipoEvento);
        }

        override public bool Add(TipoEvento tipoEvento)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TTIPOEVENTO_INSERT, tipoEvento.Descripcion);
        }

        override public bool Modify(int idTipoEvento, TipoEvento tipoEvento)
        {
            return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TTIPOEVENTO_MODIFY, idTipoEvento, tipoEvento.Descripcion);
        }
    }
}
