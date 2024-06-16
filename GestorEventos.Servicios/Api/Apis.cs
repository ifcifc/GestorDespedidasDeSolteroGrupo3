using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEventos.Servicios.Api
{
    public class Apis
    {
        public static void RegisterAllApis(WebApplicationBuilder builder) {
            builder.Services.AddTransient<LocalidadApiController>();
        }
    }
}
