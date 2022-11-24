namespace TroptechDonuts.WebApi
{
    public class Resultado
    {
        public int Codigo { get; private set; }
        public string Mensagem { get; private set; }

        public Resultado(int codigo, string mensagem)
        {
            this.Codigo = codigo;
            this.Mensagem = mensagem;
        }
    }
}
