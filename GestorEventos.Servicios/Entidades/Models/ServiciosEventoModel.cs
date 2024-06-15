using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades.Models
{
    public class ServiciosEventoModel : Servicio
    {
        public override string SQL_GetAll() => "SELECT Servicios.Descripcion, Servicios.PrecioServicio, Eventos.NombreEvento FROM Servicios INNER JOIN EventosServicios on EventosServicios.IdServicio=Servicios.IdServicio INNER JOIN Eventos on EventosServicios.IdEvento=Eventos.IdEvento WHERE EventosServicios.Borrado=0";
        public override string SQL_GetByID() => "SELECT Servicios.Descripcion, Servicios.PrecioServicio FROM Servicios INNER JOIN Eventos on Eventos.IdEvento={0} INNER JOIN EventosServicios on EventosServicios.IdServicio=Servicios.IdServicio WHERE EventosServicios.Borrado=0";

        public string NombreEvento { get; set; }


    }
}
