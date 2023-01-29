using JogoDaVelha;
using System;
using tabuleiro;
using jogo;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace jogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            var rankingList = new List<Ranking>();

            var jogador1 = new Ranking();
            var jogador2 = new Ranking();

            if (File.Exists($@"C:\Users\user\Desktop\Salvardados\ranking.json"))
            {
                var ranking = File.ReadAllText($@"C:\Users\user\Desktop\Salvardados\ranking.json");
                rankingList = JsonConvert.DeserializeObject<List<Ranking>>(ranking);
            }

            Console.WriteLine("Digite seu nome:");
            string nome = Console.ReadLine();

            if (nome != null && (rankingList.Where(b => b.NomeJogador == nome)?.Select(b => b)?.FirstOrDefault() != null))
            {
                jogador1 = rankingList.Where(b => b.NomeJogador == nome)?.Select(b => b)?.FirstOrDefault();
            }
            else
            {
                jogador1 = new Ranking()
                {
                    NomeJogador = nome,
                    NumeroDeDerrotas = 0,
                    NumeroDeVitorias = 0,
                    NumeroDeEmpates = 0,
                    NumeroDePartidas = 0,
                };
                rankingList.Add(jogador1);
            }

            Console.WriteLine("Digite seu nome:");
            string nome2 = Console.ReadLine();

            if (nome2 != null && (rankingList.Where(b => b.NomeJogador == nome2)?.Select(b => b)?.FirstOrDefault() != null))
            {
                jogador2 = rankingList.Where(b => b.NomeJogador == nome2)?.Select(b => b)?.FirstOrDefault();
            }
            else
            {
                jogador2 = new Ranking()
                {
                    NomeJogador = nome2,
                    NumeroDeDerrotas = 0,
                    NumeroDeVitorias = 0,
                    NumeroDeEmpates = 0,
                    NumeroDePartidas = 0,
                };
                rankingList.Add(jogador2);
            }

            

            Tabuleiro tab = new Tabuleiro(3, 3);


                Partida partida = new Partida();
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
                    Console.WriteLine("Turno:" + partida.turno);
                    Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                    Console.Write("Digite a posição da peça, linha espaço coluna: ");
                    Posicao posicaoEscolhida = Tela.lerPosicaodaPeca();
                    tab.validarPosicao(posicaoEscolhida);
                    
                    partida.realizaJogada(posicaoEscolhida, tab);
                    Console.Clear();
                    Tela.imprimirTabuleiro(tab);

                    var (tipoJogador, vitoria) = partida.ganhouPartida(tab);
                    if (vitoria)
                    {
                        Console.WriteLine($"Parabéns! {tipoJogador} ganhou!");
                        Console.ReadLine();
                        partida.terminada = true;
                    }
                    else if(tipoJogador == Tipo.Empate)
                    {
                        Console.WriteLine($"Empate!! Deu velha");
                        var rankingSaving = JsonConvert.SerializeObject(rankingList);
                        File.WriteAllText($@"C:\Users\user\Desktop\Salvardados\ranking.json", rankingSaving);
                        Console.ReadLine();
                        partida.terminada = true;
                    }

                 

                    




                    /*partida.velhaPartida(posicaoEscolhida, tab);
                    partida.terminada = partida.velhaPartida(posicaoEscolhida,  tab);
*/







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



//Antes de iniciar o jogo, perguntar o nome do jogador 1 e jogador 2
//Criar objeto do tipo Ranking, se o jogador não tiver salvo na lista. Se tiver na lista, recupera
//Executar a partida
//Atualizar as estatísticas de quem venceu, perdeu ou empatou
//Salvar a lista
//Finalizar o jogo
