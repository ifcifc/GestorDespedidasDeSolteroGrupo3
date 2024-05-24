using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GestorEventos.Servicios.Scopes
{
    public class Scopes
    {
        public static void RegisterAll(WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IService<Evento>, EventoService>();
            builder.Services.AddScoped<IService<Localidad>, LocalidadService>();
            builder.Services.AddScoped<IService<Persona>, PersonaService>();
            builder.Services.AddScoped<IService<Provincia>, ProvinciaService>();
            builder.Services.AddScoped<IService<Servicio>, ServicioService>();
            builder.Services.AddScoped<IService<TipoEvento>, TipoEventoService>();
        }
    }
}
