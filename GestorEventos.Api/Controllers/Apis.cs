
namespace GestorEventos.Api.Controllers
{
    public class Apis
    {
        public static void RegisterAllApis(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<LocalidadController>();
            builder.Services.AddTransient<EventoControler>();
        }
    }
}
