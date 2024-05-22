
using GestorEventos.Servicios.Entidades;

namespace GestorEventos.Servicios.Servicios
{
    public class EventoService
	{
		public IEnumerable<Evento> Eventos { get; set; }

		public EventoService()
		{
			this.Eventos = new List<Evento>
            {
                new Evento{ IdEvento = 1, NombreEvento = "Evento 1", FechaEvento = DateTime.Now,  CantidadPersonas=30, IdTipoDespedida=1, IdPersonaAgasajada=1, IdPersonaContacto=2},
                new Evento{ IdEvento = 2, NombreEvento = "Evento 2", FechaEvento = DateTime.Now,  CantidadPersonas=33, IdTipoDespedida=2, IdPersonaAgasajada=1, IdPersonaContacto=2},
                new Evento{ IdEvento = 3, NombreEvento = "Evento 3", FechaEvento = DateTime.Now,  CantidadPersonas=36, IdTipoDespedida=1, IdPersonaAgasajada=1, IdPersonaContacto=2},
            };
		}

		public IEnumerable<Evento> Get()
		{
			return this.Eventos;
		}

		public Evento GetPorId(int IdEvento)
		{
			var eventos = this.Eventos.Where(x => x.IdEvento == IdEvento);

			if (eventos == null)
				return null;

			return eventos.First();
		}


		public bool Crear(Evento evento)
		{
			try
			{
				List<Evento> lista = this.Eventos.ToList();
				lista.Add(evento);
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}

		}

        public bool Eliminar(int ID)
        { 
			return false ;
		}

        public  bool Modificar(int ID, Evento entidad)
        {
            return false;
        }

}
}
