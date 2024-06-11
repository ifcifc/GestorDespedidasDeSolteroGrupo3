using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Entidades
{
    public class Localidad
    {
        public override string SQL_GetAll() => "SELECT * FROM Localidades WHERE Borrado=0";
        public override string SQL_GetByID() => "SELECT * FROM Localidades WHERE Borrado=0 AND IdLocalidad={0}";
        public override string SQL_Add() => "INSERT INTO Localidades (IdProvincia, Nombre, CodigoArea) " +
                                                           "VALUES (@IdProvincia,  @Nombre,  @CodigoArea)";
        public override string SQL_Delete() => "UPDATE Localidades SET Borrado=1 WHERE IdLocalidad={0}";
        public override string SQL_Modify() => "UPDATE Localidades SET IdProvincia=@IdProvincia, Nombre=@Nombre, CodigoArea=@CodigoArea WHERE IdLocalidad={0}";

        public int IdLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        public string CodigoArea { get; set;}
        public bool Borrado { get; set; }
    }
}
