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
        static int contador;

        public static bool UnaSolaSolucion(int[,] tablero)
        {
            contador = 0;
            //int[,] tableroPruebas = tableroOrig.Clone() as int[,];
            ComprobacionUnaSolaSolucion(tablero, 0, 0);
            return contador == 1;
        }

        private static void ComprobacionUnaSolaSolucion(int[,] tablero, int fil, int col)
        {
            if (col >= size)
            {
                fil++;

                if (fil >= size){
                    contador++;
                    return;
                }

                col = 0;
            }

            while(tablero[fil, col] != 0)
            {
                col++;

                if (col >= size)
                {
                    fil++;

                    if (fil >= size)
                    {
                        contador++;
                        return;
                    }

                    col = 0;
                }
            }

            for (int i = 1; i <= 9; i++)
            {
                if (NumEsValido(tablero, fil, col, i))
                {
                    tablero[fil, col] = i;
                    ComprobacionUnaSolaSolucion(tablero, fil, col + 1);
                    tablero[fil, col] = 0;
                }
            }
            return;
        }

        private static bool NumEsValido(int[,] tablero, int fil, int col, int num)
        {
            for (int i = 0; i < size; i++)
            {
                if (tablero[fil, i] == num || tablero[i, col] == num)
                    return false;
            }

            int filInicioBloque = fil - fil % 3;
            int colInicioBlque = col - col % 3;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (tablero[filInicioBloque + i, colInicioBlque + j] == num)
                        return false;
            return true;
        }
    }
}
