using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class LocalidadService : Service<Localidad>
    {
        public override string SQL_GetAll => "SELECT * FROM Localidades WHERE IsDelete=0;";
        public override string SQL_GetByID => "SELECT * FROM Localidades WHERE IsDelete=0 AND IdLocalidad={0};";
        public override string SQL_Add => "INSERT INTO Localidades ([IdProvincia], [Nombre], [CodigoArea]) " +
                                                           "VALUES (@IdProvincia,  @Nombre,  @CodigoArea);";
        public override string SQL_Delete => "UPDATE Localidades SET IsDelete=1 WHERE IdLocalidad={0};";
        public override string SQL_Modify => "UPDATE Localidades SET IdProvincia=@IdProvincia, Nombre=@Nombre, CodigoArea=@CodigoArea WHERE IdLocalidad={0};";

        public LocalidadService() {

        }
    }


}
