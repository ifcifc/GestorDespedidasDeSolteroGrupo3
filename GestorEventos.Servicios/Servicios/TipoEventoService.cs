using GestorEventos.Servicios.Entidades;

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

        public bool Crear(TipoEvento tipoDeEvento)
        {
            try
            {
                List<TipoEvento> lista = this.TiposDeEvento.ToList();
                lista.Add(tipoDeEvento);
                //				this.Servicios.ToList().Add(servicio);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
}
