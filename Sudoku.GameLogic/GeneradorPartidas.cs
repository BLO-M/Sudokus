using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    internal static class GeneradorPartidas
    {
        public static int[,] GenerarSudoku()
        {
            int[,] tablero = new int[9,9];


            //Relleno libremente los bloques 1, 5 y 9 que no se afectan
            List<int> numeros = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rnd = new Random();
            for (int fil = 0; fil < 9; fil++)
            {
                if (numeros.Count == 0) numeros = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int col = fil / 3 * 3;

                for (int i = 0; i < 3 ; col++, i++)
                {
                    int num = rnd.Next(numeros.Count);
                    tablero[fil, col] = numeros[num];
                    numeros.RemoveAt(num);
                }
            }
            





            return tablero;
        }
    }
}
