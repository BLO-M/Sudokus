using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.GameLogic
{
    //Para obtener un tableroCompleto llamar a GenerarSudokuCompletado() para obtener la matriz y luego
    //llamar a Ocultador.TableroCasillasOcultas(tablero) para obtener el tablero con el que se jugará realmente
    public static class GeneradorPartidas
    {
        private static Random rnd = new Random();
        const byte size = 9;

        public static byte[,] GenerarSudokuCompletado()
        {
            byte[,] tablero = new byte[9,9];

            RellenarBloques159(tablero); //Relleno libremente los bloques 1, 5 y 9 que no se afectan entre sí
            RellenarTableroSaltando159(tablero, 0, 3);

            return tablero;
        }

        private static void RellenarBloques159(byte[,] tablero)
        {
            List<byte> numeros = new List<byte>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int fil = 0; fil < size; fil++)
            {
                if (numeros.Count == 0) numeros = new List<byte> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int col = fil / 3 * 3;

                for (int i = 0; i < 3; col++, i++)
                {
                    int num = rnd.Next(numeros.Count);
                    tablero[fil, col] = numeros[num];
                    numeros.RemoveAt(num);
                }
            }
        }

        private static bool RellenarTableroSaltando159(byte[,] tablero, int fil, int col)
        {
            if (col >= size)
            {
                fil++;

                if (fil >= size)
                    return true;

                col = 0;
            }
                
            if (fil /3 == col / 3)
            {
                col += 3;
                if (col >= size)
                {
                    if (fil == size - 1) return true;
                    fil++;
                    col = 0;
                }
            }

            foreach (byte num in NumerosMezclados())
            {
                if (NumEsValido(tablero, fil, col, num))
                {
                    tablero[fil, col] = num;

                    if (RellenarTableroSaltando159(tablero, fil, col + 1))
                        return true;

                    tablero[fil, col] = 0; 
                }
            }
            return false; //No se puede completar el sudoku, aunque al estar creandolo no va a pasar
        }

        private static List<byte> NumerosMezclados()
        {
            List<byte> numeros = new List<byte>();
            for(byte i = 1; i <= 9; i++)
                numeros.Add(i);

            //Fisher-Yates, para "barajar"
            for (int i = numeros.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (numeros[i], numeros[j]) = (numeros[j], numeros[i]);
            }
            return numeros;
        }


        private static bool NumEsValido(byte[,] tablero, int fil, int col, int num)
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
