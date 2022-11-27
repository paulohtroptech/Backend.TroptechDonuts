using System.Collections.Generic;
using TroptechDonuts.Dominio.Entidades;
using TroptechDonuts.Dominio.Excecoes;
using TroptechDonuts.Dominio.Interfaces;
using TroptechDonuts.Infra.Data.Dao;

namespace Troptech.Donuts.Repositorio
{
    public class ProdutoRepository:IProdutoRepositorio
    {

        private readonly ProdutoDao _produtoDao = new();

        
        public List<Produto> BuscarTodosProdutos()
        {
            var listaDeProdutos = _produtoDao.DaoBuscarTodosProdutos();

            if (listaDeProdutos.Count == 0)
                throw new ProdutoException("Ops, parece que não existe nenhum produto cadastrado.");

            return listaDeProdutos;
        }

        public Produto BuscarProdutoPorId(int id)
        {
            var produtoBuscado = _produtoDao.DaoBuscarProdutoPorId(id);

            if (produtoBuscado == null)
                throw new ProdutoException("Ops, parece que esse produto não está cadastrado.");

            return produtoBuscado;
        }

        public Produto CadastrarProduto(Produto produto)
        {
            produto.ValidarDadosProduto();

            _produtoDao.DaoCadastrarProduto(produto);

            return produto;
        }

        public void DeletarProduto(int id)
        {
            var produtoBuscado = _produtoDao.DaoBuscarProdutoPorId(id);

            if (produtoBuscado == null)
                throw new ProdutoException("Ops, parece que esse produto não está cadastrado.");

            _produtoDao.DaoDeletarProduto(id);
        }



        public Produto AtualizarProduto(Produto produto)
        {
            produto.ValidarDadosProduto();

            var produtoBuscado = _produtoDao.DaoBuscarProdutoPorId(produto.Id);

            if (produtoBuscado == null)
                throw new ProdutoException("Ops, parece que esse produto não está cadastrado.");

            _produtoDao.DaoAtualizarProduto(produto);

            return produto;
        }

        public Produto AtualizarQuantidadeProduto(Produto produto)
        {
            produto.ValidarDadosProduto();

            var produtoBuscado = _produtoDao.DaoBuscarProdutoPorId(produto.Id);

            if (produtoBuscado == null)
                throw new ProdutoException("Ops, parece que esse produto não está cadastrado.");

            _produtoDao.DaoAtualizarQuantidadeEstoqueProduto(produto);

            return produto;
        }

        public Produto AtualizarStatusProduto(Produto produto)
        {
            produto.ValidarDadosProduto();

            var produtoBuscado = _produtoDao.DaoBuscarProdutoPorId(produto.Id);

            if (produtoBuscado == null)
                throw new ProdutoException("Ops, parece que esse produto não está cadastrado.");

            _produtoDao.DaoAtualizarStatusProduto(produto);

            return produto;
        }




    }
}
