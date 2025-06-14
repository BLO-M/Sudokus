namespace Sudoku.GameLogic
{
    /* IDEAS: 
            Se pueden añadir dificultades y jugar más con el tiempo 
    */
    public class Dificultad
    {
        public string Nombre { get; }
        public int CeldasIniciales { get; }
        public int PistasDisponibles { get; }
        public TimeSpan? TiempoLímite { get; }

        private Dificultad(string nombre, int celdasIniciales, int pistasDisponibles, TimeSpan? tiempoLímite)
        {
            Nombre = nombre;
            CeldasIniciales = celdasIniciales;
            PistasDisponibles = pistasDisponibles;
            TiempoLímite = tiempoLímite;
        }

        public static readonly Dificultad PaTontos = new Dificultad(
            nombre: "PT",
            celdasIniciales: 60,
            pistasDisponibles: 21, //81 - celdas iniciales
            tiempoLímite: TimeSpan.FromHours(33)
            );

        public static readonly Dificultad Fácil = new Dificultad(
            nombre: "Fácil",
            celdasIniciales: 40,
            pistasDisponibles: 10,
            tiempoLímite: null
            );

        public static readonly Dificultad Intermedia = new Dificultad(
            nombre: "Intermedia",
            celdasIniciales: 30,
            pistasDisponibles: 5,
            tiempoLímite: null
            );

        public static readonly Dificultad Difícil = new Dificultad(
            nombre: "Difícil",
            celdasIniciales: 20,
            pistasDisponibles: 1,
            tiempoLímite: null
            );
    }
}