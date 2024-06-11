using GestorEventos.Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
	public class Servicio : Entidad
    {
        public override string SQL_GetAll() => "SELECT * FROM Servicios WHERE Borrado=0";
        public override string SQL_GetByID() => "SELECT * FROM Servicios WHERE Borrado=0 AND IdServicio={0}";
        public override string SQL_Add() => "INSERT INTO Servicios (Descripcion, PrecioServicio) " +
                                                         "VALUES (@Descripcion,  @PrecioServicio)";
        public override string SQL_Delete() => "UPDATE Servicios SET Borrado=1 WHERE IdServicio={0}";
        public override string SQL_Modify() => "UPDATE Servicios SET Descripcion=@Descripcion, PrecioServicio=@PrecioServicio WHERE IdServicio={0}";
        public int IdServicio { get; set; }
		public string Descripcion { get; set; }

        //decimal->similar a float, muy alta precision decimal, usar para manejar dinero 
        public decimal PrecioServicio { get; set; }
        public override string ToString()
        {
            return string.Format(
                "Servicio[IdServicio: {0}, Descripcion: {1}, PrecioServicio: {2}, Borrado]: {3}",
                this.IdServicio, this.Descripcion, this.PrecioServicio, this.Borrado);
        }
    }
}
