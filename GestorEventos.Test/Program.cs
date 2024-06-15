// See https://aka.ms/new-console-template for more information
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using Google.Protobuf.WellKnownTypes;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using GestorEventos.Test;
using MySqlX.XDevAPI.Relational;
using System.Data.SqlServerCe;
using System.Globalization;

//Para evitar el problema de las comas en los numeros
Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
//SQLConnect.DEFAULT_CONNECTION_STRING = "Server=(localdb)\\programacion;Database=gestioneventos;User Id=admin;Password=1234";
SQLConnect.DEFAULT_CONNECTION_STRING = "Server=sql10.freesqldatabase.com;Port=3306;Database=sql10712945;Uid=sql10712945;Pwd=12snVJGCyw;\r\n";
SQLConnect.CONNECTION_TYPE = ConnectionTypes.MYSQL;