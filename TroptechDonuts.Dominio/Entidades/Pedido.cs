using System;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Pedido
    {

        public Cliente Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get; set; }
        public StatusPedido Status { get; set; }

        public Pedido(Cliente cliente, DateTime dataPedido, double valorTotal)
        {
            Cliente = cliente;
            DataPedido = dataPedido;
            ValorTotal = valorTotal;
        }

        public double AtualizaPontosFidelidade()
        {
            return this.Cliente.PontosFidelidade = this.ValorTotal * 2;
        }



    }
}
