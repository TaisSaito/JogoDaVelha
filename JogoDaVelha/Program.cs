using JogoDaVelha;
using System;
using tabuleiro;
using jogo;

namespace jogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {

            Tabuleiro tab = new Tabuleiro(3, 3);
           

            Partida partida = new Partida();

            while (!partida.terminada)
            {
                Console.Clear();
                Tela.imprimirTabuleiro(tab);
                Console.WriteLine();
                Console.WriteLine("Turno:" + partida.turno);
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);



                Console.Write("Digite a posição da peça, linha espaço coluna: ");
                Posicao posicaoEscolhida = Tela.lerPosicaodaPeca();                
                partida.realizaJogada(posicaoEscolhida, tab);
               

                
            }






        }
    }
}
