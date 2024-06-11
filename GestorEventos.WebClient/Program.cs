using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.Scopes;
using GestorEventos.Servicios.Servicios;
using GestorEventos.Servicios.SQLUtils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
//SQLConnect.DEFAULT_CONNECTION_STRING = builder.Configuration.GetValue<string>("SQLConnectionString");
//SQLConnect.DEFAULT_CONNECTION_STRING = builder.Configuration.GetValue<string>("SQLConnectionString");
SQLConnect.DEFAULT_CONNECTION_STRING = "Server=sql10.freesqldatabase.com;Port=3306;Database=sql10712945;Uid=sql10712945;Pwd=12snVJGCyw;\r\n";
SQLConnect.CONNECTION_TYPE = ConnectionTypes.MYSQL;


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
            var usuarioService = (UsuarioService)ctx.HttpContext.RequestServices.GetRequiredService<IService<Usuario>>();//
            string nameIdentifier = ctx.Identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            Usuario? usuario = usuarioService.GetByGoogleIdentifier(nameIdentifier);
            int idUsuario = usuario?.IdUsuario ?? 0;

            foreach (var item in ctx.Identity.Claims)
            {
                Console.WriteLine(item.Value);
                Console.WriteLine(item.Type);
                Console.WriteLine("===================");
            }


            if (usuario == null)
            {
                idUsuario = usuarioService.AddGetID(new Usuario
                {
                    Apellido = ctx.Identity.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Surname))?.Value ?? "",
                    Nombre = ctx.Identity.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.GivenName))?.Value ?? "",
                    GoogleIdentificador = nameIdentifier,
                    Email = ctx.Identity.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email))?.Value ?? "",
                    NombreCompleto = ctx.Identity.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name))?.Value ?? "",
                });
            }
            
            ctx.Identity.AddClaim(new System.Security.Claims.Claim("Usuario", idUsuario.ToString()));
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
