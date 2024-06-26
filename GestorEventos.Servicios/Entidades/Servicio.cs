﻿using GestorEventos.Servicios.Entidades;
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

        public override string SQL_GetAllByID() => "SELECT Servicios.* FROM EventosServicios INNER JOIN Servicios ON Servicios.idServicio = EventosServicios.IdServicio WHERE EventosServicios.Borrado = 0 AND EventosServicios.IdEvento = {0}";

        public int IdServicio { get; set; }
		public string Descripcion { get; set; }

        //decimal->similar a float, muy alta precision decimal, usar para manejar dinero 
        public decimal PrecioServicio { get; set; }

        public string FormatoPrecioServicio() {
            return this.PrecioServicio.ToString("F2");
        }
    }
}
