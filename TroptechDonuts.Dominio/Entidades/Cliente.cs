using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroptechDonuts.Dominio.Excecoes;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Cliente
    {

        public string Cpf { get; set; }
        public string Nome{ get; set; }
        public DateTime DataNascimento { get; set; }
        private double PontuacaoFidelidade { get; set; }

        public Cliente()
        {

        }

        public void AtualizaPontosFidelidade()
        {

        }

        public void ValidarDadosCliente()
        {
            if (string.IsNullOrEmpty(Cpf))
                throw new ClienteException("Ops, o CPF é obrigatório.");

            //if (string.IsNullOrEmpty(PrimeiroNome))
            //    throw new ClienteException("Primeiro nome é obrigatório!");

            //if (string.IsNullOrEmpty(Sobrenome))
            //    throw new ClienteException("Sobrenome é obrigatório!");

            //if (string.IsNullOrEmpty(Endereco.Bairro))
            //    throw new ClienteException("Bairro é obrigatório!");

            //if (string.IsNullOrEmpty(Endereco.Cep))
            //    throw new ClienteException("Cep é obrigatório!");

            //if (Endereco.Numero == 0)
            //    throw new ClienteException("Número é obrigatório!");

            //if (string.IsNullOrEmpty(Endereco.Rua))
            //    throw new ClienteException("Rua é obrigatório!");
        }


    }
}
