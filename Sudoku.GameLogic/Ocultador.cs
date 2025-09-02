using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    public static class Ocultador
    {
        public static byte[,] TableroCasillasOcultas(byte[,] tablero, int dificultad)
        {
            byte[,] tableroOcultar = new byte[9,9];
            for (byte fil = 0; fil < 9; fil++)
            {
                for (byte col = 0; col < 9; col++)
                {
                    tableroOcultar[fil, col] = tablero[fil, col];
                }
            }

            Random rnd = new Random();
            switch (dificultad)
            {
                case 1: // Facil
                    if (OcultarCasillas(tableroOcultar, rnd.Next(30, 41)))
                        return tableroOcultar;
                    break;
                case 2: // Medio
                    if (OcultarCasillas(tableroOcultar, rnd.Next(41, 50)))
                        return tableroOcultar;
                    break;
                case 3: //Dificil
                    if (OcultarCasillas(tableroOcultar, rnd.Next(50, 55)))
                        return tableroOcultar;
                    break;
            }
            return TableroCasillasOcultas(tablero, dificultad);
        }

        private static bool OcultarCasillas(byte[,] tablero, int CasillasOcultar)
        {
            var coordenadas = ObtenerCoordenadasSudoku();
            Random rnd = new Random();
            int r;
            byte numOcultado;
            int i = 0;
            while (i < CasillasOcultar)
            {
                r = rnd.Next(coordenadas.Count);
                var cord = coordenadas[r];
                coordenadas.RemoveAt(r);
                numOcultado = tablero[cord.Item1, cord.Item2];
                tablero[cord.Item1,cord.Item2] = 0;
                if (i > 3)
                {
                    if (SudokuValidator.UnaSolaSolucion(tablero))
                        i++;
                    else
                        tablero[cord.Item1, cord.Item2] = numOcultado;

                    if (CasillasOcultar - i > coordenadas.Count)
                        return false;
                } 
                else
                    i++;
            }
            return true;
        }

        private static List<(byte, byte)> ObtenerCoordenadasSudoku()
        {
            return new List<(byte, byte)>
        {
            (0, 0), (0, 1), (0, 2), (0, 3), (0, 4), (0, 5), (0, 6), (0, 7), (0, 8),
            (1, 0), (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 6), (1, 7), (1, 8),
            (2, 0), (2, 1), (2, 2), (2, 3), (2, 4), (2, 5), (2, 6), (2, 7), (2, 8),
            (3, 0), (3, 1), (3, 2), (3, 3), (3, 4), (3, 5), (3, 6), (3, 7), (3, 8),
            (4, 0), (4, 1), (4, 2), (4, 3), (4, 4), (4, 5), (4, 6), (4, 7), (4, 8),
            (5, 0), (5, 1), (5, 2), (5, 3), (5, 4), (5, 5), (5, 6), (5, 7), (5, 8),
            (6, 0), (6, 1), (6, 2), (6, 3), (6, 4), (6, 5), (6, 6), (6, 7), (6, 8),
            (7, 0), (7, 1), (7, 2), (7, 3), (7, 4), (7, 5), (7, 6), (7, 7), (7, 8),
            (8, 0), (8, 1), (8, 2), (8, 3), (8, 4), (8, 5), (8, 6), (8, 7), (8, 8)
        };
        }
    }
}
