using System;

namespace TroptechDonuts.Dominio.Excecoes
{
    public class ClienteException : Exception
    {
        public ClienteException(string mensagem) : base(mensagem)
        {

        }
    }
}
