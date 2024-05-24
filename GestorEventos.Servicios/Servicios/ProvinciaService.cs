
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
	public class ProvinciaService : Service<Provincia>
	{
        public override string SQL_GetAll => "SELECT * FROM Provincias WHERE IsDelete=0;";
        public override string SQL_GetByID => "SELECT * FROM Provincias WHERE IsDelete=0 AND IdProvincia={0};";
        public override string SQL_Add => "INSERT INTO Provincias ([Nombre]) VALUES (@Nombre);";
        public override string SQL_Delete => "UPDATE Provincias SET IsDelete=1 WHERE IdProvincia={0};";
        public override string SQL_Modify => "UPDATE Provincias SET Nombre=@Nombre WHERE IdProvincia={0};";

        public ProvinciaService()
		{

		}
    }
}
