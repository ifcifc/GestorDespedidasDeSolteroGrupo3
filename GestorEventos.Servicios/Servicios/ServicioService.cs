
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioService : Service<Servicio>
	{

		public ServicioService ()
		{
            
        }

        override public IEnumerable<Servicio>? GetAll()
		{
            return SQLExecute.New().Query<Servicio>(SQLExecute.TSERVICIOS_GET_ALL);
		}

        override public Servicio? GetByID(int IdServicio)
		{
            return SQLExecute.New().QueryFirst<Servicio>(SQLExecute.TSERVICIOS_GET_BY_ID, IdServicio);

        }


        override public bool Add(Servicio servicio)
		{
			try
			{
                return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(
                        SQLExecute.TSERVICIOS_INSERT,
                        servicio.Descripcion,
                        servicio.PrecioServicio);
            }
			catch(Exception)
			{
				return false;
			}
        }

        override public bool Delete(int idServicio)
        {
            try
            {
                return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TSERVICIOS_DELETE, idServicio);
            }
            catch (Exception)
            {
                return false;
            }
        }

       override public bool Modify(int idServicio, Servicio servicio)
        {
            try
            {
                return SQLExecute
                    .New()
                    .Transaction(true)
                    .Execute(SQLExecute.TSERVICIOS_MODIFY, idServicio, servicio.Descripcion, servicio.PrecioServicio);
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
