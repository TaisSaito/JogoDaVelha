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


                var rankingList = new List<Ranking>();

                var jogador1 = new Ranking();
                var jogador2 = new Ranking();

                if (File.Exists($@"C:\Users\user\Desktop\Salvardados\ranking.json"))
                {
                    var ranking = File.ReadAllText($@"C:\Users\user\Desktop\Salvardados\ranking.json");
                    rankingList = JsonConvert.DeserializeObject<List<Ranking>>(ranking);
                }




                Console.Clear();
                Console.WriteLine("Digite o nome do jogador X:");
                string nomeJogador1 = Console.ReadLine();

                if (nomeJogador1 != null && (rankingList.Where(b => b.NomeJogador == nomeJogador1)?.Select(b => b)?.FirstOrDefault() != null))
                {
                    jogador1 = rankingList.Where(b => b.NomeJogador == nomeJogador1)?.Select(b => b)?.FirstOrDefault();
                }
                else
                {
                    jogador1 = new Ranking()
                    {
                        NomeJogador = nomeJogador1,
                        NumeroDeVitorias = 0,
                        /*NumeroDeDerrotas = 0,
                        NumeroDeEmpates = 0,
                        NumeroDePartidas = 0,*/
                    };
                    rankingList.Add(jogador1);
                }


                Console.WriteLine();
                Console.WriteLine("Digite o nome do jogador O:");
                string nomeJogador2 = Console.ReadLine();

                if (nomeJogador2 != null && (rankingList.Where(b => b.NomeJogador == nomeJogador2)?.Select(b => b)?.FirstOrDefault() != null))
                {
                    jogador2 = rankingList.Where(b => b.NomeJogador == nomeJogador2)?.Select(b => b)?.FirstOrDefault();
                }
                else
                {
                    jogador2 = new Ranking()
                    {
                        NomeJogador = nomeJogador2,
                        NumeroDeVitorias = 0,
                        /*NumeroDeDerrotas = 0,
                        NumeroDeEmpates = 0,
                        NumeroDePartidas = 0,*/
                    };
                    rankingList.Add(jogador2);
                }



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


                        /*var listRanking = new List<Ranking>()
                        {
                            new Ranking()
                            {
                                NomeJogador = "João",
                                NumeroDeDerrotas = 1,
                                NumeroDeVitorias = 2,
                                NumeroDeEmpates = 3,
                                NumeroDePartidas= 4,
                            },
                            new Ranking()
                            {
                                NomeJogador = "Maria",
                                NumeroDeDerrotas = 1,
                                NumeroDeVitorias = 0,
                                NumeroDeEmpates = 3,
                                NumeroDePartidas= 4,
                            }
                        };*/







                        Console.WriteLine();
                        Console.WriteLine($"Jogador X: {nomeJogador1} | Jogador O: {nomeJogador2}");
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
                            vencedor = nomeJogador1;



                        }
                        else
                        {
                            vencedor = nomeJogador2;
                        }



                        if (vitoria)
                        {
                            Console.WriteLine($"Parabéns! {vencedor} ganhou!");
                            Console.ReadLine();


                            if (vencedor == nomeJogador1)
                            {
                                pontuacao1++;
                                jogador1.NumeroDeVitorias = pontuacao1;

                            }

                            else if (vencedor == nomeJogador2)
                            {
                                pontuacao2++;
                                jogador2.NumeroDeVitorias = pontuacao2;
                            }



                            var rankingSaving = JsonConvert.SerializeObject(rankingList);
                            File.WriteAllText($@"C:\Users\user\Desktop\Salvardados\ranking.json", rankingSaving);
                            partida.terminada = true;

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
                            Console.WriteLine($"Nome: {jogador1.NomeJogador} | Número de vitórias: {jogador1.NumeroDeVitorias}");
                            Console.WriteLine();
                            Console.WriteLine($"Nome: {jogador2.NomeJogador} | Número de vitórias: {jogador2.NumeroDeVitorias}");

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











                    /*Console.WriteLine();
                    Console.WriteLine("Ranking:");
                    Console.WriteLine($"Nome: {jogador1.NomeJogador} | Número de vitórias: {jogador1.NumeroDeVitorias}");
                    Console.WriteLine();
                    Console.WriteLine($"Nome: {jogador2.NomeJogador} | Número de vitórias: {jogador2.NumeroDeVitorias}");

                    Console.WriteLine();
                    Console.WriteLine("Deseja jogar novamente?");
                    Console.Write("1 - SIM  | 2 - NÃO ");

                    string jogarNovamente = Console.ReadLine();


                    if (jogarNovamente.Equals(1))
                    {
                        querJogarDeNovo = true;
                    }
                    else
                    {
                        querJogarDeNovo = false;
                    }*/














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



//Antes de iniciar o jogo, perguntar o nome do jogador 1 e jogador 2
//Criar objeto do tipo Ranking, se o jogador não tiver salvo na lista. Se tiver na lista, recupera
//Executar a partida
//Atualizar as estatísticas de quem venceu, perdeu ou empatou
//Salvar a lista
//Finalizar o jogo
