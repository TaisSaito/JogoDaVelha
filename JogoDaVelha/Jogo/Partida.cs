using System;
using tabuleiro;

namespace jogo
{
    class Partida
    {
        public Tabuleiro tab;
        public int turno;
        public Tipo jogadorAtual;
        public bool terminada;

        public Partida()
        {
            tab = new Tabuleiro(3, 3);
            turno = 1;
            jogadorAtual = Tipo.X;
            terminada = false;
        }

        
        public void realizaJogada(Posicao pos, Tabuleiro tab)
        {
            if (jogadorAtual == Tipo.X)
            {
                tab.colocarPeca(new PecaX(tab, Tipo.X), pos);
            }
            else
            {
                tab.colocarPeca(new PecaO(tab, Tipo.O), pos);
            }
            turno++;
            mudaJogador();

        }

        public void mudaJogador()
        {
            if (jogadorAtual == Tipo.X)
            {
                jogadorAtual = Tipo.O;
            }
            else
            {
                jogadorAtual = Tipo.X;
            }

        }



    }
}
