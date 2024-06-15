using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades.Models
{
    public class PersonaModel : Persona
    {

        public override string SQL_GetAll() => "SELECT Personas.*, Localidades.Nombre AS Localidad, Localidades.CodigoArea, Provincias.Nombre AS Provincia FROM Personas INNER JOIN Localidades ON Localidades.IdLocalidad = Personas.IdLocalidad INNER JOIN Provincias ON Provincias.IdProvincia = Localidades.IdProvincia WHERE Personas.Borrado = 0 ORDER BY Personas.Nombre, Personas.Apellido";

        public override string SQL_GetByID() => "SELECT Personas.*, Localidades.Nombre AS Localidad, Localidades.CodigoArea, Provincias.Nombre AS Provincia FROM Personas INNER JOIN Localidades ON Localidades.IdLocalidad = Personas.IdLocalidad INNER JOIN Provincias ON Provincias.IdProvincia = Localidades.IdProvincia WHERE Personas.Borrado = 0 AND Personas.IdPersona={0} ORDER BY Personas.Nombre, Personas.Apellido";

        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CodigoArea { get; set; }
    }
}
