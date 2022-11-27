using System.Collections.Generic;
using TroptechDonuts.Dominio.Entidades;

namespace TroptechDonuts.Dominio.Interfaces
{
    public interface IPedidoRepositorio
    {

        List<Pedido> BuscarTodosPedidos();

        Pedido BuscarPedidoPorId(int id);

        Pedido CadastrarPedido(Pedido pedido);

        Pedido AtualizarPedido(Pedido pedido);

        Pedido AtualizarStatusPedido(Pedido pedido);

        void DeletarPedido(int id);

    }
}

