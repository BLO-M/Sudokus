using Newtonsoft.Json;

namespace Sudokus.Web.Components.DTOs
{
    public record NuevaPartidaResponse(string IdSesion, [property: JsonProperty("tableroOculto")] byte[,] Tablero);
    public record ComprobacionRequest(string IdSesion, byte[,] TableroActual);
    public record PistaCasillaRequest(string IdSesion, byte fil, byte col);

}
