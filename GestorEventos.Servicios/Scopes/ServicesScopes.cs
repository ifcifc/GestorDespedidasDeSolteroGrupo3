using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Entidades.Models;
using GestorEventos.Servicios.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GestorEventos.Servicios.Scopes
{
    public class ServicesScopes
    {
        public static void RegisterAllServices(WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IService<Evento>, EventoService>();
            builder.Services.AddScoped<IService<Localidad>, Service<Localidad>>();
            builder.Services.AddScoped<IService<Persona>, PersonaService>();
            builder.Services.AddScoped<IService<Usuario>, UsuarioService>();

            builder.Services.AddScoped<IService<Provincia>, Service<Provincia>>();
            builder.Services.AddScoped<IService<Servicio>, ServiciosService>();
            builder.Services.AddScoped<IService<TipoEvento>, Service<TipoEvento>>();


            builder.Services.AddScoped<IService<EventoModel>, Service<EventoModel>>();
            builder.Services.AddScoped<IService<LocalidadModel>, Service<LocalidadModel>>();
            builder.Services.AddScoped<IService<PersonaModel>, Service<PersonaModel>>();
            builder.Services.AddScoped<IService<LocalidadesProvincia>, Service<LocalidadesProvincia>>();
            builder.Services.AddScoped<IService<EstadoEvento>, Service<EstadoEvento>>();
            builder.Services.AddScoped<IService<EventoServicio>, Service<EventoServicio>>();

        }
    }
}
