using Sudoku.GameLogic;
using Sudokus.ApiService.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var sesiones = new Dictionary<string, Partida>();
const int size = 9;

app.MapGet("/nuevo/{dificultad}", (int dificultad) =>
{
    var idSesion = Guid.NewGuid().ToString();
    
    var tableroCompleto = GeneradorPartidas.GenerarSudokuCompletado();
    var tableroOculto = Ocultador.TableroCasillasOcultas(tableroCompleto, dificultad);

    Partida partida = new Partida(tableroOculto, tableroCompleto, dificultad);
    sesiones.Add(idSesion, partida);

    return Results.Json(new {idSesion, tableroOculto});
});

app.MapPost("/comprobar", (ComprobacionRequest IdYTableroActual) =>
{
    int[,] tableroActual = IdYTableroActual.TableroActual;
    if (sesiones.TryGetValue(IdYTableroActual.IdSesion, out Partida? partida))
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
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











app.Run();