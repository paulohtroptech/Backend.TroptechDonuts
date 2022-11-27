using System;
using TroptechDonuts.Dominio.Excecoes;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao{ get; set; }
        public double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public DateTime DataValidade{ get; set; }
        public bool Ativo{ get; set; }

        public Produto(int id, string descricao, double preco, int quantidadeEstoque, DateTime dataValidade)
        {
            this.Id= id;
            this.Descricao = descricao;
            this.Preco = preco;
            this.QuantidadeEstoque = quantidadeEstoque;
            this.DataValidade = dataValidade.ToLocalTime();
        }

        public void ValidarDadosProduto()
        {
            if (string.IsNullOrEmpty(Descricao) || this.Descricao.Length < 3)
                throw new ProdutoException("Ops, a Descrição deve ter pelo menos 3 caracteres.");

            if (this.Preco <= 0)
                throw new ProdutoException("Ops, o preço deve ser maior que 0.");

            if (this.DataValidade < DateTime.Now)
                throw new ProdutoException("Ops, a Data de vencimento deve ser maior que a data atual.");
        }

    }
}
