

using System.Reflection.PortableExecutable;

namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Tipo tipo { get; set; }
        public Tabuleiro tab { get; set; }


        public Peca(Posicao posicao, Tabuleiro tab, Tipo tipo)
        {
            this.posicao = posicao;
            this.tipo = tipo;
            this.tab = tab;
        }



    }
}
