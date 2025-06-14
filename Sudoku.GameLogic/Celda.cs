namespace Sudoku.GameLogic
{
    public class Celda
    {
        private int x;
        private int y;
        public int X => x;
        public int Y => y;

        private int? valor;
        public int? Valor => valor;

        private bool esInicial;
        public bool EsInicial => esInicial;

        internal bool esCongruente;
        public bool EsCongruente => esCongruente;


        public Celda(int x, int y, int? valor)
        {
            this.x = x;
            this.y = y;
            this.valor = valor;
            esInicial = valor == null ? false : true;
            esCongruente = true;
        }

        public bool AsignarValor(int? nuevoValor)
        {
            if (esInicial == true) return false;
            if (nuevoValor is < 1 or > 9) return false;
            valor = nuevoValor;
            return true;
        }

        public void BorrarValor()
        {
            if (!esInicial)
            {
                valor = null;
                
            }     
        }
    }
    
}
