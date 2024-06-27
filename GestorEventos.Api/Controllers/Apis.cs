
namespace GestorEventos.Api.Controllers
{
    public class Apis
    {
        //Usado para registrar las APIs en los otros proyectos
        public static void RegisterAllApis(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<LocalidadController>();
            builder.Services.AddTransient<EventoControler>();
        }
    }
}
