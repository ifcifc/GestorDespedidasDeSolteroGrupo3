using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;

namespace GestorEventos.Servicios.Servicios
{
    public class LocalidadService : Service<Localidad>
    {
        public LocalidadService() {

        }

        override public IEnumerable<Localidad>? GetAll()
        {
            return SQLExecute
                    .New()
                    .Query<Localidad>(SQLExecute.TLOCALIDADES_GET_ALL);
        }

        override public Localidad? GetByID(int idLocalidad)
        {
            return SQLExecute
                .New()
                .QueryFirst<Localidad>(SQLExecute.TLOCALIDADES_GET_BY_ID, idLocalidad);
        }

        override public bool Add(Localidad localidad)
        {
            return SQLExecute
                .New()
                .Transaction(true)
                .Execute(SQLExecute.TLOCALIDADES_INSERT, localidad.IdProvincia, localidad.Nombre, localidad.CodigoArea);
        }

        override public bool Modify(int idLocalidad, Localidad localidad)
        {

            return SQLExecute
                .New()
                .Transaction(true)
                .Execute(SQLExecute.TLOCALIDADES_MODIFY, idLocalidad, localidad.IdProvincia, localidad.Nombre, localidad.CodigoArea);
        }

        override public bool Delete(int idLocalidad)
        {
            return SQLExecute
                .New()
                .Transaction(true)
                .Execute(SQLExecute.TLOCALIDADES_DELETE, idLocalidad);
        }
    }


}
