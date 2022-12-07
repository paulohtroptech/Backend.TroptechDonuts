using System;
using TroptechDonuts.Dominio.Excecoes;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataPedido { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get { return CalculaValorTotal();  } set { } }
        public StatusPedido Status { get; set; }

        public Pedido(
            int id,
            Cliente cliente,
            Produto produto,
            int quantidade)
        {
            this.Id = id;
            this.Cliente = cliente;
            this.Produto = produto;
            this.DataPedido = DateTime.Now;
            this.Quantidade = quantidade;
            this.ValorTotal = this.CalculaValorTotal();
            this.Status = (StatusPedido)1;
        }

        public Pedido()
        {
        }

        private double CalculaValorTotal()
        {
            return this.Produto.Preco * this.Quantidade;
        }

        public double AtualizaPontosFidelidade()
        {
            return this.Cliente.PontosFidelidade = Math.Round(this.ValorTotal * 2);
        }


        public void ValidarDadosPedido()
        {

            if (this.Quantidade <= 0)
                throw new ProdutoException("Ops, a quantidade deve ser maior que 0.");

            if(this.Produto.Preco <= 0)
                throw new ProdutoException("Ops, o preço deve ser maior que 0.");
        }


    }
}
