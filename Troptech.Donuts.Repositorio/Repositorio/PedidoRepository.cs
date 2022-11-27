using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroptechDonuts.Dominio.Entidades;
using TroptechDonuts.Dominio.Excecoes;
using TroptechDonuts.Dominio.Interfaces;
using TroptechDonuts.Infra.Data.Dao;

namespace Troptech.Donuts.Repositorio
{
    public class PedidoRepository : IPedidoRepositorio
    {

        private readonly PedidoDao _pedidoDao = new();
        private readonly ClienteDao _clienteDao = new();
        private readonly ProdutoDao _produtoDao = new();


        public List<Pedido> BuscarTodosPedidos()
        {
            var listaDePedidos = _pedidoDao.DaoBuscarTodosPedidos();

            if (listaDePedidos.Count == 0)
                throw new PedidoException("Ops, parece que não existe nenhum pedido cadastrado.");

            return listaDePedidos;
        }

        public Pedido BuscarPedidoPorId(int id)
        {
            var pedidoBuscado = _pedidoDao.DaoBuscarPedidoPorId(id);

            if (pedidoBuscado == null)
                throw new PedidoException("Ops, parece que esse pedido não está cadastrado.");

            return pedidoBuscado;
        }

        public Pedido CadastrarPedido(Pedido pedido)
        {
            pedido.ValidarDadosPedido();

            var clienteBuscado = _clienteDao.DaoBuscarClientePorCPF(pedido.Cliente.Cpf);
            var produtoBuscado = _produtoDao.DaoBuscarProdutoPorId(pedido.Produto.Id);

            if (clienteBuscado != null)
                _clienteDao.DaoAtualizaPontosFidelidadeCliente(pedido.Cliente);

            if(produtoBuscado.QuantidadeEstoque < pedido.Quantidade)
                throw new PedidoException("Ops, não temos esta quantidade no estoque.");

            _produtoDao.DaoAtualizarQuantidadeEstoqueProduto(pedido.Produto);

            _pedidoDao.DaoCadastrarPedido(pedido);

            return pedido;
        }

        public void DeletarPedido(int id)
        {
            var pedidoBuscado = _pedidoDao.DaoBuscarPedidoPorId(id);

            if (pedidoBuscado == null)
                throw new PedidoException("Ops, parece que esse pedido não está cadastrado.");

            if (pedidoBuscado.Status == 0)
                throw new PedidoException("Ops, este pedido não pode ser excluído.");

            _pedidoDao.DaoDeletarPedido(id);
        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            var pedidoBuscado = _pedidoDao.DaoBuscarPedidoPorId(pedido.Id);

            if (pedidoBuscado.Status == 0)
                throw new PedidoException("Ops, este pedido não pode ser alterado.");

            _pedidoDao.DaoAtualizarStatusPedido(pedido);

            return pedido;
        }

        public Pedido AtualizarStatusPedido(Pedido pedido)
        {
            _pedidoDao.DaoAtualizarPedido(pedido);

            return pedido;
        }


    }
}
