using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Scopes;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.SQLUtils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using GestorEventos.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);

SQLConnect.SetConfig(
    builder.Configuration.GetValue<string>("SQLConnectionString") ?? "",
    builder.Configuration.GetValue<string>("DBServer") ?? ""
);

//Registro todos los Scopes de Servicios
ServicesScopes.RegisterAllServices(builder);
//Registro las Apis compartidas
//Apis.RegisterAllApis(builder);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = builder.Configuration.GetSection("Google:ClientId").Value + ".apps.googleusercontent.com";
        options.ClientSecret = builder.Configuration.GetSection("Google:ClientSecret").Value;
        options.Events.OnCreatingTicket = ctx =>
        {
            var usuarioService = (UsuarioService)ctx.HttpContext.RequestServices.GetRequiredService<IService<Usuario>>();//
            string nameIdentifier = ctx.Identity?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

            Usuario? usuario = usuarioService.GetByGoogleIdentifier(nameIdentifier);
            int idUsuario = usuario?.IdUsuario ?? 0;

            if (usuario == null)
            {
                idUsuario = usuarioService.AddGetID(new Usuario
                {
                    Apellido = ctx.Identity?.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Surname))?.Value ?? "",
                    Nombre = ctx.Identity?.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.GivenName))?.Value ?? "",
                    GoogleIdentificador = nameIdentifier,
                    Email = ctx.Identity?.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value ?? "",
                    NombreCompleto = ctx.Identity?.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value ?? "",
                });
            }
            
            ctx.Identity?.AddClaim(new System.Security.Claims.Claim("UsuarioId", idUsuario.ToString()));
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
