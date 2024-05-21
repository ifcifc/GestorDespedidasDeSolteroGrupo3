namespace GestorEventos.Servicios.Entidades
{
    public class Provincia : Entidad
    {
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return string.Format("Provincia[IdProvincia: {0}, Nombre: {1}, IsDelete: {2}]", this.IdProvincia, this.Nombre, this.IsDelete);
        }
    }
}
