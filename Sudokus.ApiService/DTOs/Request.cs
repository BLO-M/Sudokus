namespace Sudokus.ApiService.DTOs
{
    public record ComprobacionRequest (string IdSesion, int[,] TableroActual);
    public record PistaCasillaRequest (string IdSesion, int fil, int col);
}
