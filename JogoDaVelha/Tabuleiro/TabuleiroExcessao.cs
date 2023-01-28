using System;

namespace tabuleiro
{
     class TabuleiroExcessao : Exception
    {
        public TabuleiroExcessao(string msg) : base(msg){ 
        }

    }
}
