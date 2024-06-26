using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades.Models
{
    public class LocalidadModel : Localidad
    {
        public override string SQL_GetAll() => "SELECT Localidades.*, Provincias.Nombre AS Provincia FROM Localidades INNER JOIN Provincias ON Localidades.IdProvincia = Provincias.IdProvincia WHERE Localidades.Borrado=0 ORDER BY Localidades.Nombre";

        public override string SQL_GetByID() => "SELECT Localidades.*, Provincias.Nombre AS Provincia FROM Localidades INNER JOIN Provincias ON Localidades.IdProvincia = Provincias.IdProvincia WHERE Localidades.Borrado=0 AND Localidades.IdLocalidad={0} ORDER BY Localidades.Nombre";

        public string Provincia { get; set; }
    }
}
