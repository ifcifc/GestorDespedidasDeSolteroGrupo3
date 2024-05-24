using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Scopes;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.SQLUtils;

//Para evitar el problema de las comas en los numeros
Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

SQLExecute.DEFAULT_CONNECTION_STRING = builder.Configuration.GetSection("SQLConnectionString").Value;


//Registro todos los Scopes de Servicios
Scopes.RegisterAll(builder);

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