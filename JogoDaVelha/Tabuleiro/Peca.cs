

using System.Reflection.PortableExecutable;

namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Tipo tipo { get; set; }
        public Tabuleiro tab { get; set; }


        public Peca(Tabuleiro tab, Tipo tipo)
        {
            this.posicao = null;
            
            this.tab = tab;
            this.tipo = tipo;
        }



    }
}
