//Para evitar el problema de las comas en los numeros
using GestorEventos.Servicios.SQLUtils;

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
SQLExecute.DEFAULT_CONNECTION_STRING = "Server=(localdb)\\programacion;Database=gestioneventos;User Id=admin;Password=1234";

var builder = WebApplication.CreateBuilder(args);

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
