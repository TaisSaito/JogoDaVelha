using System;
using tabuleiro;
using jogo;

namespace jogo
{
    class Partida
    {
        public Tabuleiro tab;
        public int turno;
        public Tipo jogadorAtual;
        public bool terminada;
        public PecaX pecaX;
        public PecaO pecaO;

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

        public Tuple<Tipo, bool> ganhouPartida(Tabuleiro tab)
        {
            //testando as colunas
            
            for (int j = 0; j < tab.colunas; j++)
            {
                
                
                if (tab.pecas[0,j]?.tipo == tab.pecas[1,j]?.tipo && tab.pecas[0,j]?.tipo == tab.pecas[2,j]?.tipo && tab.pecas[0,j]?.tipo != null)
                {
                    return Tuple.Create(tab.pecas[0,j].tipo, true);
                }
                
            }

            // testando as linhas            
            for (int j = 0; j < tab.colunas; j++)
            {
                if (tab.pecas[j, 0]?.tipo == tab.pecas[j, 1]?.tipo && tab.pecas[j, 2]?.tipo == tab.pecas[j, 1]?.tipo && tab.pecas[j, 0]?.tipo != null)
                {
                  
                        return Tuple.Create(tab.pecas[j, 0].tipo, true); 

                    
                }
                
            }
            // testando a diagonal principal
            if (tab.pecas[0, 0]?.tipo == tab.pecas[1, 1]?.tipo && tab.pecas[2, 2]?.tipo == tab.pecas[1, 1]?.tipo && tab.pecas[0, 0]?.tipo != null)
            {
                return Tuple.Create(tab.pecas[0, 0].tipo, true);
            }
            else if (tab.pecas[0, 2]?.tipo == tab.pecas[1, 1]?.tipo && tab.pecas[2, 0]?.tipo == tab.pecas[1, 1]?.tipo && tab.pecas[0, 2]?.tipo != null)
            {
                return Tuple.Create(tab.pecas[0, 2].tipo, true);
            }

            else if(turno == 10)
            {
                return Tuple.Create(Tipo.Empate, false);
            }
            else
            {
                return Tuple.Create(Tipo.Null, false);
            }
            
           


        }



        /*public bool velhaPartida(Posicao pos, Tabuleiro tab)
        {
            if (turno == 10)
            {
                return true;
            }

        }*/



            /*int cont = 1;
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.linhas; j++)
                {
                    if (tab.pecas[i,j] != null)
                    {
                        cont++;
                        if (cont == 10)
                        {
                            terminada = true;
                            return terminada;
                        }
                    }
                }
            }*/
            /* return false;

         }*/



            /* public string resultadoDoJogo(Tabuleiro tab, Tipo jogadorAtual)
             { int cont = 0;
                 //Nunca pode sair do for
                 for (int i = 0; i < tab.linhas; i++)
                 {
                     if (tab.pecas[i, 0] == tab.pecas[i, 1] && tab.pecas[i, 1] == tab.pecas[i, 2] && tab.pecas[i,2] != null)
                     {
                         terminada = true;
                         return "O vencedor é " + jogadorAtual;
                     }
                     else if (tab.pecas[0, i] == tab.pecas[1, i] && tab.pecas[1, i] == tab.pecas[2, i] && tab.pecas[2, i] != null)
                     {
                         terminada = true;
                         return "O vencedor é " + jogadorAtual;
                     }
                     else if (tab.pecas[0, 0] == tab.pecas[1,1] && tab.pecas[1, 1] == tab.pecas[2, 2] && tab.pecas[2, 2] != null)
                     {
                         terminada = true;
                         return "O vencedor é " + jogadorAtual;
                     }
                     else if(tab.pecas[0, 2] == tab.pecas[1, 1] && tab.pecas[2, 0] == tab.pecas[1, 1] && tab.pecas[1, 1] != null)
                     {
                         terminada = true;
                         return "O vencedor é " + jogadorAtual;
                     }
                     for(int j = 0; j < tab.linhas; j++)
                     {
                         if (tab.pecas[i,j]!= null)
                         {
                             cont++;
                             if(cont == 9)
                             {
                                 terminada = true;
                                 return "Velha!";
                             }
                         }
                     }

                 }
                 return "OK";

             }*/


        }
}
