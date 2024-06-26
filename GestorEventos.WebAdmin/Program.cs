//Para evitar el problema de las comas en los numeros
//using GestorEventos.Compartido.Api;
using GestorEventos.Compartido.Scopes;
using GestorEventos.Servicios.SQLUtils;
using GestorEventos.Api.Controllers;
using Google.Protobuf.WellKnownTypes;

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
var builder = WebApplication.CreateBuilder(args);

SQLConnect.SetConfig(
    builder.Configuration.GetValue<string>("SQLConnectionString") ?? "",
    builder.Configuration.GetValue<string>("DBServer") ?? ""
);

//Registro todos los Scopes de Servicios
ServicesScopes.RegisterAllServices(builder);
//Registro las Apis compartidas
Apis.RegisterAllApis(builder);

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
