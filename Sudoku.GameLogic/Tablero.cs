using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    /* IDEAS:      
           -Añadir la función de cargar tableros guardados
    */
    public class Tablero
    {
        public Celda[,] tablero = new Celda [9,9];

        private Dificultad dificultad;
        public Dificultad Dificultad => dificultad;


        public Tablero(Dificultad dificultad)
        {
            this.dificultad = dificultad;
        }

        public void RellenarTableroInicio(Dificultad dificultad)
        {

        }
    }
}
