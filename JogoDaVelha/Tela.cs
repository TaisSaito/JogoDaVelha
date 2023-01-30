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



            int[] posicaoDaPeca = new int[2];
            int opcaoDoUsuario = int.Parse(Console.ReadLine());

            if (opcaoDoUsuario == 1)
            {
                posicaoDaPeca[0] = 0;
                posicaoDaPeca[1] = 0;
            }
            else if (opcaoDoUsuario == 2)
            {
                posicaoDaPeca[0] = 0;
                posicaoDaPeca[1] = 1;
            }
            else if (opcaoDoUsuario == 3)
            {
                posicaoDaPeca[0] = 0;
                posicaoDaPeca[1] = 2;
            }
            else if (opcaoDoUsuario == 4)
            {
                posicaoDaPeca[0] = 1;
                posicaoDaPeca[1] = 0;
            }
            else if (opcaoDoUsuario == 5)
            {
                posicaoDaPeca[0] = 1;
                posicaoDaPeca[1] = 1;
            }
            else if (opcaoDoUsuario == 6)
            {
                posicaoDaPeca[0] = 1;
                posicaoDaPeca[1] = 2;
            }
            else if (opcaoDoUsuario == 7)
            {
                posicaoDaPeca[0] = 2;
                posicaoDaPeca[1] = 0;
            }
            else if (opcaoDoUsuario == 8)
            {
                posicaoDaPeca[0] = 2;
                posicaoDaPeca[1] = 1;
            }
            else if (opcaoDoUsuario == 9)
            {
                posicaoDaPeca[0] = 2;
                posicaoDaPeca[1] = 2;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Digite uma opção válida");
                lerPosicaodaPeca();
            }

            int linhaEscolhida = posicaoDaPeca[0];
            int colunaEscolhida = posicaoDaPeca[1];
            return new Posicao(linhaEscolhida, colunaEscolhida);


            

        }

        
    }
}
