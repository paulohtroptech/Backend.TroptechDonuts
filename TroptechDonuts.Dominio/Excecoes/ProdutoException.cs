using System;

namespace TroptechDonuts.Dominio.Excecoes
{
    public class ProdutoException : Exception
    {
        public ProdutoException(string mensagem) : base(mensagem)
        {

        }
    }
}
