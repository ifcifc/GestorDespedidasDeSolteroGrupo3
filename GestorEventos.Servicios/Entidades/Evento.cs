namespace GestorEventos.Servicios.Entidades
{
    public class Evento : Entidad
	{
		public int IdEvento { get; set; }
		public string NombreEvento { get; set; }
		public DateTime FechaEvento { get; set; }
		public int CantidadPersonas { get; set; }
		public int IdTipoEvento { get; set; }
		public int IdPersonaAgasajada { get; set; }

		public int IdPersonaContacto { get; set; }

        public override string ToString()
        {
            return string.Format("Evento[IdEvento: {0}, NombreEvento:{1}, FechaEvento: {2}, FechaEvento: {3}, CantidadPersonas:{4}, IdTipoEvento:{5}, IdPersonaAgasajada: {6}, IdPersonaContacto: {7}, IsDelete: {8}]",
                                IdEvento, NombreEvento, FechaEvento.ToString(), CantidadPersonas, IdTipoEvento, IdPersonaAgasajada, IdPersonaContacto, IsDelete);
        }
    }
}
