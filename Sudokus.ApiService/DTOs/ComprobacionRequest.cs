namespace Sudokus.ApiService.DTOs
{
    public record ComprobacionRequest (string IdSesion, int[,] TableroActual);

}
