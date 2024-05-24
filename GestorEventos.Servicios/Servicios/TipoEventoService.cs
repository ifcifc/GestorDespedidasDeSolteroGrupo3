using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class TipoEventoService : Service<TipoEvento>
    {
        public override string SQL_GetAll => "SELECT * FROM TipoEventos WHERE IsDelete=0;";
        public override string SQL_GetByID => "SELECT * FROM TipoEventos WHERE IsDelete=0 AND IdTipoEvento={0};";
        public override string SQL_Add => "INSERT INTO TipoEventos ([Descripcion]) VALUES (@Descripcion);";
        public override string SQL_Delete => "UPDATE TipoEventos SET IsDelete=1 WHERE IdTipoEvento={0};";
        public override string SQL_Modify => "UPDATE TipoEventos SET Descripcion=@Descripcion WHERE IdTipoEvento={0};";

        public TipoEventoService() 
		{

		}
    }
}
