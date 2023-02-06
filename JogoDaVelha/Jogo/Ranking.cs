using Newtonsoft.Json;
using System;


namespace jogo
{
    public class Ranking
    {
        public string NomeJogador { get; set; }
        public int NumeroDePartidas { get; set; }

        public int NumeroDeVitorias { get; set; }

        public int NumeroDeDerrotas { get; set; }

        public int NumeroDeEmpates { get; set; }


        public static void Serializacao()
        {
            var rankingSaving = JsonConvert.SerializeObject(item3);
            File.WriteAllText($@"C:\Users\user\Desktop\Salvardados\ranking.json", rankingSaving);

        }




        public static Tuple<Ranking, Ranking, List<Ranking>> mostrarRanking()
        {
            var rankingList = new List<Ranking>();



            var jogador1 = new Ranking();
            var jogador2 = new Ranking();

            if (File.Exists($@"C:\Users\user\Desktop\Salvardados\ranking.json"))
            {
                var ranking = File.ReadAllText($@"C:\Users\user\Desktop\Salvardados\ranking.json");
                rankingList = JsonConvert.DeserializeObject<List<Ranking>>(ranking);
            }

          
            Console.Write("Digite o nome do jogador X: ");
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
            Console.Write("Digite o nome do jogador O: ");
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
            return Tuple.Create(jogador1, jogador2, rankingList);
        }


        static List<Ranking> item3 = mostrarRanking().Item3;

     

        



    }
}

