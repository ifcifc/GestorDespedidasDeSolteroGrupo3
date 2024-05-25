// See https://aka.ms/new-console-template for more information
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using Google.Protobuf.WellKnownTypes;

//Para evitar el problema de las comas en los numeros
Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
SQLExecute.DEFAULT_CONNECTION_STRING = "Server=(localdb)\\programacion;Database=gestioneventos;User Id=admin;Password=1234";
