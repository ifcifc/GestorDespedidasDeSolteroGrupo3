using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
	public class TipoEvento : Entidad
	{
		public int IdTipoEvento { get; set; }
		public string Descripcion { get; set; }

        public override string ToString()
        {
            return string.Format(
                "TipoEvento[IdTipoEvento: {0}, Descripcion: {1}, isDelete]: {2}",
                this.IdTipoEvento, this.Descripcion,  this.IsDelete);
        }
    }
}
