using System;

public class Partida
{
    public int[,] TableroJuego { get; set; }
    public int[,] Solucion { get; set; }
    public int PistasDisponibles { get; set; }
    public DateTime HoraCreacion { get; }
    public int Dificultad { get; }

    public Partida(int[,] tableroJuego, int[,] solucion, int pistasDisponibles, int dificultad)
    {
        this.TableroJuego = tableroJuego;
        this.Solucion = solucion;
        this.PistasDisponibles = pistasDisponibles;
        this.HoraCreacion = DateTime.Now;
        this.Dificultad = dificultad;
    }
}
