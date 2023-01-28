

using System.Diagnostics.SymbolStore;

namespace tabuleiro
{
     class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas;

       
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        


        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroExcessao("Posição inválida");
            }
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }




        public void colocarPeca (Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroExcessao("Essa posição já está preenchida");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha <0 || pos.coluna <0 || pos.linha >= linhas || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

       

    }

}
