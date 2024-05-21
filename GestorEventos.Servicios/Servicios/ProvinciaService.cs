
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class ProvinciaService : Service<Provincia>
	{

		public ProvinciaService()
		{

		}

        override public IEnumerable<Provincia>? GetAll()
        {
            return SQLExecute
                .New()
                .Query<Provincia>(SQLExecute.TPROVINCIAS_GET_ALL);
        }

        override public Provincia? GetByID(int idProvincia)
		{
			return SQLExecute
                .New()
                .QueryFirst<Provincia>(SQLExecute.TPROVINCIAS_GET_BY_ID, idProvincia);
		}

        override public bool Add(Provincia provincia)
		{
            return SQLExecute
                .New()
                .Transaction(true)
                .Execute(SQLExecute.TPROVINCIAS_INSERT, provincia.Nombre);
        }

        override public bool Delete(int idProvincia)
        {
            return SQLExecute
                .New()
                .Transaction(true)
                .Execute(SQLExecute.TPROVINCIAS_DELETE, idProvincia);
        }


        override public bool Modify(int idProvincia, Provincia provincia)
        {
            return SQLExecute
                .New()
                .Transaction(true)
                .Execute(SQLExecute.TPROVINCIAS_MODIFY, idProvincia, provincia.Nombre);
        }
    }
}
