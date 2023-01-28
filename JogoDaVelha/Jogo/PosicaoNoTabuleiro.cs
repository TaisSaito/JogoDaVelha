using System;


namespace jogo
{
    class PosicaoNoTabuleiro
    {
        public int coluna { get; set; }
        public int linha { get; set; }

        public PosicaoNoTabuleiro(int coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public override string ToString()
        {
            return " " + coluna + linha;
        }
    }
}
