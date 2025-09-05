using Sudokus.Web;
using Sudokus.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// builder.AddServiceDefaults(); //No necesito cookies

// Agregamos Razor Components para el frontend interactivo
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Detecta la URL del backend según entorno
var apiUrl = Environment.GetEnvironmentVariable("SUDOKU_API_URL");

// Si no hay variable, asumimos Aspire y usamos el nombre del servicio con esquema válido
if (string.IsNullOrWhiteSpace(apiUrl))
    apiUrl = "https://apiservice"; // Aspire resolverá el nombre del servicio

// Validación extra: si la URL no es válida, lanza excepción clara
if (!Uri.TryCreate(apiUrl, UriKind.Absolute, out var baseUri))
    throw new InvalidOperationException($"La URL para el backend no es válida: {apiUrl}");

// Registramos el cliente HTTP para llamar al backend
builder.Services.AddHttpClient("SudokuApi", client =>
{
    client.BaseAddress = baseUri;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Seguridad extra para HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseAntiforgery(); // Protección contra CSRF No quiero cookies

// Mapeo de componentes Razor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .DisableAntiforgery();

app.Run();
