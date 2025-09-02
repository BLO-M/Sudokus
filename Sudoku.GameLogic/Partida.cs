using System;

public class Partida
{
    public byte[,] TableroJuego { get; set; }
    public byte[,] Solucion { get; set; }
    public int PistasDisponibles { get; private set; }
    public DateTime HoraCreacion { get; }
    public int Dificultad { get; }

    public Partida(byte[,] tableroJuego, byte[,] solucion, int dificultad) //Partidas Nuevas
    {
        this.TableroJuego = tableroJuego;
        this.Solucion = solucion;
        this.HoraCreacion = DateTime.Now;
        this.Dificultad = dificultad;
        switch(dificultad)
        {
            case 1: PistasDisponibles = 3; break;
            case 2: PistasDisponibles = 2; break;
            case 3: PistasDisponibles = 0; break;
        }
    }

    public Partida(byte[,] tableroJuego, byte[,] solucion, int pistasDisponibles, int dificultad) //Partidas cargadas
    {
        this.TableroJuego = tableroJuego;
        this.Solucion = solucion;
        this.PistasDisponibles = pistasDisponibles;
        this.HoraCreacion = DateTime.Now;
        this.Dificultad = dificultad;
    }

    public static bool usarPista(Partida partida)
    {
        if (partida.PistasDisponibles <= 0) 
            return false;

        partida.PistasDisponibles--;
        return true;
    }
}
