// See https://aka.ms/new-console-template for more information
using GestorEventos.Servicios.SQLUtils;

//Para evitar el problema de las comas en los numeros
Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
//SQLConnect.DEFAULT_CONNECTION_STRING = "Server=(localdb)\\programacion;Database=gestioneventos;User Id=admin;Password=1234";
SQLConnect.SetConfig(
    "Server=mysql-gestoreventos-grupo3-gestoreventos.g.aivencloud.com; Port=24355; Database=gestorevento; Uid=avnadmin; Pwd={0}; SslMode=Required;",
    ConnectionTypes.MYSQL.ToString()
);

