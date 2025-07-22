using System;

public class Partida
{
    public int[,] TableroJuego { get; set; }
    public int[,] Solucion { get; set; }
    public int PistasUsadas { get; set; }
    public DateTime HoraCreacion { get; }

    public Partida(int[,] tableroJuego, int[,] solucion, int pistasUsadas, DateTime horaCreacion)
    {
        this.TableroJuego = tableroJuego;
        this.Solucion = solucion;
        this.PistasUsadas = pistasUsadas;
        this.HoraCreacion = horaCreacion;
    }

    public PartidaRecargada(int[,] tableroJuego, int[,] solucion, int pistasUsadas)
    {
        this.TableroJuego = tableroJuego;
        this.Solucion = solucion;
        this.PistasUsadas = pistasUsadas;
    }
}
