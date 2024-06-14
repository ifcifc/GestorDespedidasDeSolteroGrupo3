using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class EventoServicio : Entidad
    {
        public override string SQL_Add() => "INSERT INTO EventosServicios(IdEvento, IdServicio) VALUES (@IdEvento, @IdServicio)";
        public override string SQL_Delete() => "UPDATE EventosServicios SET Borrado=1 WHERE IdEventoServicio={0}";
        public override string SQL_GetAll() => "SELECT * FROM EventosServicios WHERE Borrado=False";
        public override string SQL_GetByID() => "SELECT * FROM EventosServicios WHERE Borrado=False AND IdEventoServicio={0}";
        public override string SQL_Modify() => "UPDATE EventosServicios SET IdEvento=@IdEvento, IdServicio=@IdServicio WHERE IdEventoServicio={0}";

        public int IdEventoServicio { get; set; }
        public int IdEvento { get; set; }
        public int IdServicio { get; set; }
    }
}
