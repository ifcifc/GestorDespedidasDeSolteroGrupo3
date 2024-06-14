using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades.Models
{
    public class EventoModel : Evento
    {
        public override string SQL_GetAll() => "SELECT Eventos.*, TiposEventos.Descripcion, Personas.Nombre AS PersonaAgasajadaNombre, Personas.Apellido AS PersonaAgasajadaApellido, Personas.Telefono AS PersonaAgasajadaTelefono, Usuarios.NombreCompleto AS UsuarioNombre, Usuarios.Email AS UsuarioEmail, EstadosEventos.Descripcion AS Estado FROM Eventos INNER JOIN TiposEventos ON TiposEventos.IdTipoEvento=Eventos.IdTipoEvento INNER JOIN Personas ON Personas.IdPersona=Eventos.IdPersonaAgasajada INNER JOIN Usuarios ON Usuarios.IdUsuario=Eventos.IdUsuario INNER JOIN EstadosEventos ON EstadosEventos.IdEstadoEvento=Eventos.IdEstadoEvento WHERE Eventos.Borrado=0 ORDER BY Eventos.FechaEvento, Eventos.NombreEvento";

        public override string SQL_GetByID() => "SELECT Eventos.*, TiposEventos.Descripcion, Personas.Nombre AS PersonaAgasajadaNombre, Personas.Apellido AS PersonaAgasajadaApellido, Personas.Telefono AS PersonaAgasajadaTelefono, Usuarios.NombreCompleto AS UsuarioNombre, Usuarios.Email AS UsuarioEmail, EstadosEventos.Descripcion AS Estado FROM Eventos INNER JOIN TiposEventos ON TiposEventos.IdTipoEvento=Eventos.IdTipoEvento INNER JOIN Personas ON Personas.IdPersona=Eventos.IdPersonaAgasajada INNER JOIN Usuarios ON Usuarios.IdUsuario=Eventos.IdUsuario INNER JOIN EstadosEventos ON EstadosEventos.IdEstadoEvento=Eventos.IdEstadoEvento WHERE Eventos.Borrado=0 AND Eventos.IdEvento={0} ORDER BY Eventos.FechaEvento, Eventos.NombreEvento";

        
        public string Descripcion { get; set; }
        public string PersonaAgasajadaNombre { get; set; }
        public string PersonaAgasajadaApellido { get; set; }
        public string PersonaAgasajadaTelefono { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioEmail { get; set; }
        public string Estado { get; set; }
    }
}
