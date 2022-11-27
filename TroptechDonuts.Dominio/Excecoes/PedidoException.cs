using System;

namespace TroptechDonuts.Dominio.Excecoes
{
    public class PedidoException : Exception
    {
        public PedidoException(string mensagem) : base(mensagem)
        {

        }
    }
}
