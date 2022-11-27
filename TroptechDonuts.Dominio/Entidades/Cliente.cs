using System;
using TroptechDonuts.Dominio.Excecoes;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Cliente
    {

        public string Cpf { get; set; }
        public string Nome{ get; set; }
        public DateTime DataNascimento { get; set; }
        public double PontosFidelidade { get; set; }

        public Cliente(string cpf, string nome, DateTime dataNascimento)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }


        public void ValidarDadosCliente()
        {
            if (string.IsNullOrEmpty(Cpf))
                throw new ClienteException("Ops, o CPF é obrigatório.");

            if (string.IsNullOrEmpty(Nome))
                throw new ClienteException("Ops, o Nome é obrigatório.");

            if (this.DataNascimento == DateTime.MinValue)
                throw new ClienteException("Ops, a Data de Nascimento é obrigatória.");
        }


    }
}
