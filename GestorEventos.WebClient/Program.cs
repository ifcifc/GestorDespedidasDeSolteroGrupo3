using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Scopes;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.SQLUtils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
SQLExecute.DEFAULT_CONNECTION_STRING = builder.Configuration.GetValue<string>("SQLConnectionString");

ServicesScopes.RegisterAllServices(builder);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = builder.Configuration.GetSection("Google:ClientId").Value;
        options.ClientSecret = builder.Configuration.GetSection("Google:ClientSecret").Value;
        options.Events.OnCreatingTicket = ctx =>
        {
            var personaService = (PersonaService)ctx.HttpContext.RequestServices.GetRequiredService<IService<Persona>>();//
            string nameIdentifier = ctx.Identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            Persona? persona = personaService.GetByGoogleIdentifier(nameIdentifier);

            foreach (var item in ctx.Identity.Claims)
            {
                Console.WriteLine(item.Value);
                Console.WriteLine(item.Type);
                Console.WriteLine("===================");
            }


            if (persona == null)
            {
                personaService.Add(new Persona
                {
                    Apellido = ctx.Identity.Claims.First(x => x.Type.Equals(ClaimTypes.Surname)).Value.ToString(),
                    Nombre = ctx.Identity.Claims.First(x => x.Type.Equals(ClaimTypes.Name)).Value.ToString(),
                    GoogleIdentifier = nameIdentifier,
                    Email = ctx.Identity.Claims.First(x => x.Type.Equals(ClaimTypes.Email)).Value.ToString()
                });
                persona = personaService.GetByGoogleIdentifier(nameIdentifier);
            }
            
            ctx.Identity.AddClaim(new System.Security.Claims.Claim("Usuario", persona.IdPersona.ToString()));
            Console.WriteLine(persona.IdPersona);
            return Task.CompletedTask;
        };
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
