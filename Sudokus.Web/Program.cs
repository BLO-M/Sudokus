using Sudokus.Web;
using Sudokus.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Agregamos Razor Components para el frontend interactivo
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registramos el cliente HTTP para llamar al backend
builder.Services.AddHttpClient("SudokuApi", client =>
{
    client.BaseAddress = new Uri("https+http://apiservice");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Seguridad extra para HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery(); // Protección contra CSRF

// Mapeo de componentes Razor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
