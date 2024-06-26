using GestorEventos.Servicios.Entidades;
using GestorEventos.Compartido.Scopes;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.SQLUtils;

//Para evitar el problema de las comas en los numeros
Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

//Establece la configuracion para conectarse a la base de datos
SQLConnect.SetConfig(
    builder.Configuration.GetValue<string>("SQLConnectionString") ?? "",
    builder.Configuration.GetValue<string>("DBServer") ?? "",
    builder.Configuration.GetValue<bool>("EnableTransactions")
);

//Registro todos los Scopes de Servicios
ServicesScopes.RegisterAllServices(builder);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();