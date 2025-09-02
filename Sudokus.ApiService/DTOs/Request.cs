namespace Sudokus.ApiService.DTOs
{
    public record ComprobacionRequest (string IdSesion, byte[,] TableroActual);
    public record PistaCasillaRequest (string IdSesion, byte fil, byte col);
}
