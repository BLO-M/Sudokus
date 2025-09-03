using Newtonsoft.Json;

namespace Sudokus.Web.Components.DTOs
{
    public record NuevaPartidaResponse(string IdSesion, [property: JsonProperty("tableroOculto")] byte[,] Tablero);

}
