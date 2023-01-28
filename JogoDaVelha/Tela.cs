using System;
using tabuleiro;
using jogo;

namespace JogoDaVelha
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine("-------------");
            for (int i = 0; i <tab.linhas; i++)
            {
                Console.Write("|");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.pecas[i,j] == null)
                    {
                        Console.Write(" ");
                    }
                    Console.Write($" {tab.pecas[i,j]} |" );
                }
                
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }
        //printando a peca de cores diferentes
        public static void imprimirPeca(Peca peca)
        {
            if(peca.tipo == Tipo.X)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(peca);
                Console.ForegroundColor = aux;

            }
        }


        //lendo a posição que o usuário digitar
        public static Posicao lerPosicaodaPeca()
        {
            string[] posicaoDaPeca = Console.ReadLine().Split();
            int linhaEscolhida = int.Parse(posicaoDaPeca[0]);
            int colunaEscolhida = int.Parse(posicaoDaPeca[1]);
            return new Posicao(linhaEscolhida, colunaEscolhida);


            

        }

        
    }
}
