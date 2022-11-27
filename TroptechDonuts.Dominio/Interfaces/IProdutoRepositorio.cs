using System.Collections.Generic;
using TroptechDonuts.Dominio.Entidades;

namespace TroptechDonuts.Dominio.Interfaces
{
    public interface IProdutoRepositorio
    {

        List<Produto> BuscarTodosProdutos();

        Produto BuscarProdutoPorId(int id);

        Produto CadastrarProduto(Produto produto);

        void DeletarProduto(int id);

        Produto AtualizarProduto(Produto produto);

        Produto AtualizarStatusProduto(Produto produto);

        Produto AtualizarQuantidadeProduto(Produto produto);
    }
}
