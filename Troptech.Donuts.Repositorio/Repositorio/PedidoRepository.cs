using System.Collections.Generic;
using TroptechDonuts.Dominio;
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

        public Pedido BuscarDetalhePedidoPorId(int id)
        {
            var pedidoBuscado = _pedidoDao.DaoBuscarDetalhePedidoPorId(id);

            if (pedidoBuscado == null)
                throw new PedidoException("Ops, parece que esse pedido não está cadastrado.");

            return pedidoBuscado;
        }

        public Pedido CadastrarPedido(Pedido pedido)
        {
            pedido.ValidarDadosPedido();


            if(pedido.Cliente != null)
            {
                var clienteBuscado = _clienteDao.DaoBuscarClientePorCPF(pedido.Cliente.Cpf);

                if (clienteBuscado != null)
                {
                    var novosPontosFidelidade = clienteBuscado.PontosFidelidade + pedido.AtualizaPontosFidelidade();
                    _clienteDao.DaoAtualizaPontosFidelidadeCliente(pedido.Cliente.Cpf, novosPontosFidelidade);
                }

            }

            var produtoBuscado = _produtoDao.DaoBuscarProdutoPorId(pedido.Produto.Id);

            if(produtoBuscado.QuantidadeEstoque < pedido.Quantidade)
                throw new PedidoException("Ops, não temos esta quantidade no estoque.");
                
            var novaQuantidade = produtoBuscado.QuantidadeEstoque - pedido.Quantidade;

            _produtoDao.DaoAtualizarQuantidadeEstoqueProduto(pedido.Produto.Id, novaQuantidade);

            _pedidoDao.DaoCadastrarPedido(pedido);

            return pedido;
        }



    public void DeletarPedido(int id)
        {
            var pedidoBuscado = _pedidoDao.DaoBuscarPedidoPorId(id);

            if (pedidoBuscado == null)
                throw new PedidoException("Ops, parece que esse pedido não está cadastrado.");

            if ((int)pedidoBuscado.Status == (int)StatusPedido.Finalizado)
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
            _pedidoDao.DaoAtualizarStatusPedido(pedido);

            return pedido;
        }


    }
}
