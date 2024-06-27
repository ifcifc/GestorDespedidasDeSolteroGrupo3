using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Servicios
{
    public class EventoModelService : Service<EventoModel>
    {
        private const string SQL_GET_ALL_ORDER = """
                        SELECT 	Eventos.*, 
            		            TiposEventos.Descripcion, 
                                Personas.Nombre AS PersonaAgasajadaNombre, 
                                Personas.Apellido AS PersonaAgasajadaApellido, 
                                Personas.Telefono AS PersonaAgasajadaTelefono, 
                                Usuarios.Email AS UsuarioEmail, 
                                EstadosEventos.Descripcion AS Estado 
                        FROM Eventos 
                        INNER JOIN TiposEventos ON TiposEventos.IdTipoEvento=Eventos.IdTipoEvento 
                        INNER JOIN Personas ON Personas.IdPersona=Eventos.IdPersonaAgasajada 
                        INNER JOIN Usuarios ON Usuarios.IdUsuario=Eventos.IdUsuario 
                        INNER JOIN EstadosEventos ON EstadosEventos.IdEstadoEvento=Eventos.IdEstadoEvento 
                        WHERE Eventos.Borrado=0 
                        ORDER BY IdEstadoEvento, FechaEvento, CantidadPersonas DESC, NombreEvento
            """;

        private const string SQL_UPDATE_ESTADO = """
                                                        UPDATE Eventos 
                                                        SET IdEstadoEvento = {0}
                                                        WHERE IdEvento={1};
                                                 """;

        public void SetEstado(int idEvento, int idEstadoEvento) 
        {
            using (var db = SQLConnect.New().Transaction())
            {
                db.Execute(string.Format(
                    SQL_UPDATE_ESTADO,
                    idEstadoEvento,
                    idEvento));
            }
        }

        public IEnumerable<EventoModel>? GetAllOrder()
        {
            using (var db = SQLConnect.New())
            {
                return db.Query<EventoModel>(SQL_GET_ALL_ORDER);
            }
        }
    }
}
