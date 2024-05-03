
using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public IEnumerable<Evento> GetEventos()
		{
			return this.Eventos;
		}

		public Evento GetEventoPorId(int IdEvento)
		{
			var eventos = this.Eventos.Where(x => x.IdEvento == IdEvento);

			if (eventos == null)
				return null;

			return eventos.First();
		}


		public bool AgregarEvento(Evento evento)
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

	}
}
