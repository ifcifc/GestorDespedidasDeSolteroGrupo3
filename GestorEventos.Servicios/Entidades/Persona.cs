namespace GestorEventos.Servicios.Entidades
{
    public class Persona : Entidad
	{
		public int IdPersona { get; set; }
        public int IdLocalidad { get; set; }
        public string GoogleIdentifier { get; set; }
        public string Nombre { get; set; } 
		public string Apellido { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }

        public string DireccionCalle { get; set; }
        public int DireccionNumero { get; set; }
        public int DireccionPiso { get; set; }
        public string DireccionDepartamento { get; set; }

        public override string ToString()
        {
            return string.Format("Persona[IdPersona: {0}, IdLocalidad:{1}, Nombre: {2}, Apellido: {3}, Telefono:{4}, Email:{5}, DireccionCalle: {6}, DireccionNumero: {7}, DireccionPiso: {8}, DireccionDepartamento: {9}, IsDelete: {10}]",
                                          IdPersona,      IdLocalidad,     Nombre,      Apellido,      Telefono,     Email,     DireccionCalle,      DireccionNumero,      DireccionPiso,      DireccionDepartamento,      IsDelete);
        }
    }
}
