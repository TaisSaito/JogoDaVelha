using JogoDaVelha;
using System;
using tabuleiro;
using jogo;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using tutorial;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace jogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {

            FuncoesDoTutorial.opcaoDeVerTutorial();
            bool querJogarDeNovo = true;
            int pontuacao1 = 0;
            int pontuacao2 = 0;

            while (querJogarDeNovo)
            {


                Tabuleiro tab = new Tabuleiro(3, 3);


                Partida partida = new Partida();

                Console.Clear();
                FuncoesDoTutorial.TabuleiroTutorialComPosicoes();
                Console.WriteLine();
                Tela.imprimirTabuleiro(tab);
                

                while (!partida.terminada)
                {


                    try
                    {

                        var jogador = Ranking.mostrarRanking();
                        Console.Clear();

                        FuncoesDoTutorial.TabuleiroTutorialComPosicoes();
                        Console.WriteLine();
                        Tela.imprimirTabuleiro(tab);

                        while (!partida.terminada)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Jogador X: {jogador.Item1.NomeJogador} | Jogador O: {jogador.Item2.NomeJogador}");
                            Console.WriteLine("Turno:" + partida.turno);
                            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                            Console.Write("Digite a posição da peça: ");
                            Posicao posicaoEscolhida = Tela.lerPosicaodaPeca();
                            tab.validarPosicao(posicaoEscolhida);

                            partida.realizaJogada(posicaoEscolhida, tab);
                            Console.Clear();
                            FuncoesDoTutorial.TabuleiroTutorialComPosicoes();
                            Console.WriteLine();
                            Tela.imprimirTabuleiro(tab);

                            var (tipoJogador, vitoria) = partida.ganhouPartida(tab);

                            string vencedor;
                            if (tipoJogador == Tipo.X)
                            {
                                vencedor = jogador.Item1.NomeJogador;



                            }
                            else
                            {
                                vencedor = jogador.Item2.NomeJogador;
                            }



                            if (vitoria)
                            {
                                Console.WriteLine($"Parabéns! {vencedor} ganhou!");
                                Console.ReadLine();


                                if (vencedor == jogador.Item1.NomeJogador)
                                {
                                    pontuacao1++;
                                    jogador.Item1.NumeroDeVitorias = pontuacao1;

                                }

                                else if (vencedor == jogador.Item2.NomeJogador)
                                {
                                    pontuacao2++;
                                    jogador.Item2.NumeroDeVitorias = pontuacao2;
                                }

                                partida.terminada = true;
                                /*Ranking.Serializacao();*/
                               

                            }
                            else if (tipoJogador == Tipo.Empate)
                            {
                                Console.WriteLine($"Empate!! Deu velha");
                                Console.ReadLine();
                                partida.terminada = true;
                            }


                            
                            if (vitoria || (tipoJogador == Tipo.Empate))
                            {
                                Console.WriteLine();
                                Console.WriteLine("Ranking:");
                                Console.WriteLine($"Nome: {jogador.Item1.NomeJogador} | Número de vitórias: {jogador.Item1.NumeroDeVitorias}");
                                Console.WriteLine();
                                Console.WriteLine($"Nome: {jogador.Item2.NomeJogador} | Número de vitórias: {jogador.Item2.NumeroDeVitorias}");

                                Console.WriteLine();
                                Console.WriteLine("Deseja jogar novamente?");
                                Console.Write("1 - SIM  | 2 - NÃO ");

                                string jogarNovamente = Console.ReadLine();


                                if (jogarNovamente.Equals("1"))
                                {
                                    querJogarDeNovo = true;
                                }
                                else
                                {
                                    querJogarDeNovo = false;
                                }

                            }

                            
                        }















                    }























                    catch (TabuleiroExcessao e)
                    {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.ReadLine();



                    }



                }



            }
        }
    }
}




