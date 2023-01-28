using tabuleiro;

namespace jogo
{
    class PecaX : Peca
    {
        public PecaX(Tabuleiro tab, Tipo tipo) : base(tab, tipo) {
        }

        public override string ToString()
        {
            return "X";
        }
    }
    


    
}
