using Sudoku.GameLogic;
using Sudokus.ApiService.DTOs;
using Sudokus.ApiService.Services;
using System.Collections.Concurrent;
using Newtonsoft.Json;

var sesiones = new ConcurrentDictionary<string, Partida>();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(sesiones);
builder.Services.AddHostedService<LimpiezaSesionesService>();
var app = builder.Build();

const byte size = 9;

app.MapPost("/nuevo/{dificultad}", (int dificultad) =>
{   
    var tableroCompleto = GeneradorPartidas.GenerarSudokuCompletado();
    var tableroOculto = Ocultador.TableroCasillasOcultas(tableroCompleto, dificultad);

    Partida partida = new Partida(tableroOculto, tableroCompleto, dificultad);

    bool agregado;
    string idSesion;
    do
    {
        idSesion = Guid.NewGuid().ToString();
        agregado = sesiones.TryAdd(idSesion, partida);
    } while (!agregado);

    //return Results.Json(new {idSesion, tableroOculto}); System.Text.Json no funciona con [,], por no cambiar todo a [][] uso Newtonsoft para serializar y deserializar
    return Results.Content(JsonConvert.SerializeObject(new { idSesion, tableroOculto }), "application/json");
});

app.MapPost("/comprobar", (ComprobacionRequest IdYTableroActual) =>
{
    byte[,] tableroActual = IdYTableroActual.TableroActual;
    if (sesiones.TryGetValue(IdYTableroActual.IdSesion, out Partida? partida))
    {
        for (byte i = 0; i < size; i++)
            for (byte j = 0; j < size; j++)
            {
                if (tableroActual[i, j] != partida.Solucion[i, j])
                    return Results.Ok(false);
            }
        return Results.Ok(true);
    }
    else
    {
        return Results.NotFound(new { error = "Sesión no encontrada" });
    }
});

app.MapPost("/usarPista", (PistaCasillaRequest IdyFilyCol) =>
{
    if (!sesiones.TryGetValue(IdyFilyCol.IdSesion, out Partida? partida))
        return Results.NotFound(new { error = "Sesión no encontrada" });

    if (Partida.usarPista(partida)) //Si quedan pistas disponibles
        return Results.Ok(partida.Solucion[IdyFilyCol.fil, IdyFilyCol.col]);
    else
        return Results.Ok(false);
});






app.Run();