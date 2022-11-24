using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Cliente
    {

        public string Nome{ get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public double PontuacaoFidelidade { get; set; }

        public Cliente()
        {

        }

        public void AtualizaPontosFidelidade()
        {

        }

    }
}
