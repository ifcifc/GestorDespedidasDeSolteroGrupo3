
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class ServicioService : Service<Servicio>
	{
        public override string SQL_GetAll => "SELECT * FROM servicios WHERE IsDelete=0;";
        public override string SQL_GetByID => "SELECT * FROM servicios WHERE IsDelete=0 AND IdServicio={0};";
        public override string SQL_Add => "INSERT INTO servicios ([Descripcion], [PrecioServicio]) " +
                                                         "VALUES (@Descripcion,  @PrecioServicio);";
        public override string SQL_Delete => "UPDATE servicios SET IsDelete=1 WHERE IdServicio={0};";
        public override string SQL_Modify => "UPDATE servicios SET Descripcion=@Descripcion, PrecioServicio=@PrecioServicio WHERE IdServicio={0};";

        public ServicioService ()
		{
            
        }
    }
}
