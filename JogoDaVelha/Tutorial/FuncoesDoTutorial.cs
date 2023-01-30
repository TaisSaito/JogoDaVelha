using System;
using tabuleiro;
using jogo;

namespace tutorial
{
    class FuncoesDoTutorial
    {

        static string[,] tabuleiro = new string[3, 3];


        





        public static bool opcaoDeVerTutorial()
        {
            string opcaoTutorial;
            do
            {
                Console.Clear();
                Console.WriteLine("Olá, seja bem-vindo ao jogo da velha!");
                Console.WriteLine();
                Console.WriteLine("Você gostaria de ver um tutorial para aprender a jogar? (Aperte 1 ou 2)");
                Console.Write("1 - SIM  | 2 - NÃO ");
                opcaoTutorial = Console.ReadLine();

                if (opcaoTutorial.Equals("1"))
                {
                    EnsinandoRegrasDoJogo();
                    Console.WriteLine("Gostaria de ver o tutorial novamente?");
                    Console.Write("1 - SIM  | 2 - NÃO ");
                    string verNovamenteTutorial = Console.ReadLine(); 
                    if (verNovamenteTutorial.Equals("1"))
                    {
                        Console.Clear();
                        EnsinandoRegrasDoJogo();
                    }
                    
                    return true;
                }
                else if (opcaoTutorial.Equals("2"))
                {
                    Console.WriteLine("Vamos Jogar!");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            while (false);
        }


        public static void EnsinandoRegrasDoJogo()
        {
            Console.WriteLine();
            Console.WriteLine("O jogo é simples");
            Console.WriteLine("Primeiro, os dois jogadores escolhem entre X e O para jogar, o X começa.");
            Console.WriteLine("Depois,vocês vão ver um tabuleiro como esse na tela");
            TabuleiroTutorialVazio();

            Console.WriteLine();
            Console.WriteLine("Aperte Enter para continuar...");
            Console.ReadLine();
            Console.WriteLine("Cada jogador escolhe um número para colocar o X ou O");
            TabuleiroTutorialComPosicoes();
            Console.WriteLine();
            Console.WriteLine("Ganha quem preencher uma LINHA");

            Console.WriteLine();
            //Linha
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        tabuleiro[i, j] = "X";
                    }
                    else
                    {
                        tabuleiro[i, j] = " ";
                    }

                }
            }
            TabuleiroDeJogo();

            Console.WriteLine();
            Console.WriteLine("Aperte Enter para continuar...");
            Console.ReadLine();
            Console.WriteLine("ou uma COLUNA");
            
            //Coluna
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        tabuleiro[i, j] = "O";
                    }
                    else
                    {
                        tabuleiro[i, j] = " ";
                    }

                }
            }
            TabuleiroDeJogo();

            Console.WriteLine();
            Console.WriteLine("Aperte Enter para continuar...");
            Console.ReadLine();
            Console.WriteLine("ou uma DIAGONAL");
            
            //Diagonal Principal
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        tabuleiro[i, j] = "X";
                    }
                    else
                    {
                        tabuleiro[i, j] = " ";
                    }

                }
            }
            TabuleiroDeJogo();

            Console.WriteLine();
            //Diagonal Secundária
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i + j == 2)
                    {
                        tabuleiro[i, j] = "O";
                    }
                    else
                    {
                        tabuleiro[i, j] = " ";
                    }

                }
            }
            TabuleiroDeJogo();

            Console.WriteLine();
            Console.WriteLine("Aperte Enter para continuar...");
            Console.ReadLine();
        }
        


        public static void TabuleiroTutorialComPosicoes()
        {
            //Posições dentro do tabuleiro
            int cont = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = cont.ToString();
                    cont++;
                }
            }
            TabuleiroDeJogo();
        }


        public static void TabuleiroDeJogo()
        {

            Console.WriteLine("------------");
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"| {tabuleiro[i, j]} ");

                }
                Console.Write("|");
                Console.WriteLine();
                Console.WriteLine("------------");
            }
        }




        public static void TabuleiroTutorialVazio()
        {



            Console.WriteLine("------------");
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|   ");

                }
                Console.Write("|");
                Console.WriteLine();
                Console.WriteLine("------------");
            }
        }




    }
}

