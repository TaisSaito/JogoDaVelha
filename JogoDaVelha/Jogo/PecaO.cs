using tabuleiro;

namespace jogo
{
    class PecaO : Peca
    {
        public PecaO(Tabuleiro tab, Tipo tipo) : base(tab, tipo)
        {
        }

        public override string ToString()
        {
            return "O";
        }
    }




}
