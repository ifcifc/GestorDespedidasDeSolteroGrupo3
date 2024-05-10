using GestorEventos.Servicios.Entidades;
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

		public IEnumerable<TipoEvento> GetTipoEventos ()
		{
			return this.TiposDeEvento.Where(e => !e.isDelete); ;
		}

		public TipoEvento GetTipoEventoPorId(int IdTipoEvento)
		{
			var tiposDeEvento = TiposDeEvento.Where(x => x.IdTipoEvento == IdTipoEvento);

			return (tiposDeEvento == null) ? null: tiposDeEvento.First();
        }
        public bool Eliminar(int idTipoEvento)
        {
            try
            {
                var e = this.TiposDeEvento.FirstOrDefault(x => x.IdTipoEvento == idTipoEvento);
                e.isDelete = true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Agregar(TipoEvento tipoEvento)
        {
            try
            {
                List<TipoEvento> lista = this.TiposDeEvento.ToList();
                lista.Add(tipoEvento);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Modificar(int idTipoEvento, TipoEvento tipoEvento)
        {

            var e = this.TiposDeEvento.FirstOrDefault(x => x.IdTipoEvento == idTipoEvento);
            if (e == null) return false;

            e.Descripcion = tipoEvento.Descripcion;

            return true;
        }
    }
}
