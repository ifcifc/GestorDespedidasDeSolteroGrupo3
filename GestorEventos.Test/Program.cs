// See https://aka.ms/new-console-template for more information
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;

//Para evitar el problema de las comas en los numeros
Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

IEnumerable<Provincia>? enumerable = SQLExecute
            .New()
            .Query<Provincia>(SQLExecute.TPROVINCIAS_GET_ALL);

foreach(Provincia s in enumerable){
    Console.WriteLine(s.ToString());
}




Console.WriteLine("Hello, World!");
