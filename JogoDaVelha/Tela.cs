using System;
using tabuleiro;

namespace JogoDaVelha
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine("-------------");
            for (int i = 0; i <tab.linhas; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.pecas[i,j] == null)
                    {
                        Console.Write(" ");
                    }
                    Console.Write($" | {tab.pecas[i,j]}" );
                }
                
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }
    }
}
