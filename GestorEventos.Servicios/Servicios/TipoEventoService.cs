﻿using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
	public class TipoEventoService
	{

		public IEnumerable<TipoEvento> TiposDeEvento { get; set; }

		public TipoEventoService() 
		{
			TiposDeEvento = new List<TipoEvento>
			{
				new TipoEvento {IdTipoEvento = 1, Descripcion = "Despedida de Solteros" },
				new TipoEvento {IdTipoEvento = 2, Descripcion = "Despedida de Solteras" },
			}; 

		}

		public IEnumerable<TipoEvento> Get ()
		{
			return this.TiposDeEvento;
		}

		public TipoEvento GetPorId(int IdTipoEvento)
		{
			var tiposDeEvento = TiposDeEvento.Where(x => x.IdTipoEvento == IdTipoEvento);

			if (tiposDeEvento == null)
				return null;

			return tiposDeEvento.First();
		}



	}
    public bool Eliminar(int ID)
    {
        return false;
    }

    public bool Modificar(int ID, TipoEvento entidad)
    {
        return false;
    }
}
