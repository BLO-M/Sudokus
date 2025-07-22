using Sudoku.GameLogic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var sesiones = new Dictionary<string, Partida>();
const int size = 9;

int[,]? tableroCompleto = null;

app.MapGet("/nuevo/{dificultad}", (int dificultad) =>
{
    tableroCompleto = GeneradorPartidas.GenerarSudokuCompletado();
    var tableroOculto = Ocultador.TableroCasillasOcultas(tableroCompleto, dificultad);
    return tableroOculto;
});

app.MapPost("/comprobar", (int[,] tableroActual) =>
{
    if (tableroCompleto == null)
        return false;
    for (int i = 0; i < size; i++)
        for (int j = 0; j < size; j++)
        {
            if (tableroActual[i, j] != tableroCompleto[i, j])
                return false;
        }
    return true;
});











app.Run();