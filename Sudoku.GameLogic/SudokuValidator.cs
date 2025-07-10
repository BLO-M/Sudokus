using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    public static class SudokuValidator
    {
        const int size = 9;
        static int contador = 0;

        public static bool UnaSolaSolucion(int[,] tablero)
        {

        }

        private static bool ComprobacionUnaSolaSolucion(int[,] tablero, int fil, int col)
        {
            if (col >= size)
            {
                fil++;

                if (fil >= size)
                    return true;

                col = 0;
            }

            while(tablero[fil, col] != 0)
            {
                col++;

                if (col >= size)
                {
                    fil++;

                    if (fil >= size)
                        return true;

                    col = 0;
                }
            }
                
        }
    }
}
