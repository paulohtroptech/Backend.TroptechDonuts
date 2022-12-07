using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using TroptechDonuts.Dominio.Entidades;

namespace TroptechDonuts.Infra.Data.Dao
{
    public class ProdutoDao
    {

        private const string _connectionString = @"server=NDD-NOT-DEV504\TROPTECH;database=DB_TROPTECHDONUTS;user id=sa;password=Xw6q2@12345678;Encrypt=False";


        public List<Produto> DaoBuscarTodosProdutos()
        {
            var listaProdutos = new List<Produto>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM TB_PRODUTOS";

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoBuscado = new()
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            Descricao = leitor["DESCRICAO"].ToString(),
                            Preco = double.Parse(leitor["PRECOUN"].ToString()),
                            QuantidadeEstoque = int.Parse(leitor["QUANTIDADEESTOQUE"].ToString()),
                            DataValidade = DateTime.Parse(leitor["DATAVALIDADE"].ToString()),
                            Ativo = Boolean.Parse(leitor["ATIVO"].ToString())
                        };

                        listaProdutos.Add(produtoBuscado);
                    }
                }

                return listaProdutos;
            }
        }

        public List<Produto> DaoBuscarTodosProdutosAtivos()
        {
            var listaProdutos = new List<Produto>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM TB_PRODUTOS WHERE ATIVO = 1";

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoBuscado = new()
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            Descricao = leitor["DESCRICAO"].ToString(),
                            Preco = double.Parse(leitor["PRECOUN"].ToString()),
                            QuantidadeEstoque = int.Parse(leitor["QUANTIDADEESTOQUE"].ToString()),
                            DataValidade = DateTime.Parse(leitor["DATAVALIDADE"].ToString()),
                            Ativo = Boolean.Parse(leitor["ATIVO"].ToString())
                        };

                        listaProdutos.Add(produtoBuscado);
                    }
                }

                return listaProdutos;
            }
        }


        public Produto DaoBuscarProdutoPorId(int id)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM TB_PRODUTOS WHERE ID = @ID_PRODUTO";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@ID_PRODUTO", id);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoBuscado = new()
                        {
                            Id = int.Parse(leitor["ID"].ToString()),
                            Descricao = leitor["DESCRICAO"].ToString(),
                            Preco = double.Parse(leitor["PRECOUN"].ToString()),
                            QuantidadeEstoque = int.Parse(leitor["QUANTIDADEESTOQUE"].ToString()),
                            DataValidade = DateTime.Parse(leitor["DATAVALIDADE"].ToString())
                        };

                        return produtoBuscado;
                    }
                }
            }

            return null;
        }


        public Produto DaoCadastrarProduto(Produto produto)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"INSERT INTO TB_PRODUTOS (DESCRICAO, PRECOUN, QUANTIDADEESTOQUE, DATAVALIDADE, ATIVO)
                                            VALUES (@DESCRICAO,
                                                    @PRECOUN, 
                                                    @QUANTIDADE,
                                                    @DATAVALIDADE,
                                                    @ATIVO)";

                    comando.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
                    comando.Parameters.AddWithValue("@PRECOUN", produto.Preco.ToString(CultureInfo.InvariantCulture));
                    comando.Parameters.AddWithValue("@QUANTIDADE", produto.QuantidadeEstoque);
                    comando.Parameters.AddWithValue("@DATAVALIDADE", produto.DataValidade);
                    comando.Parameters.AddWithValue("@ATIVO", produto.Ativo);

                    comando.ExecuteNonQuery();
                }
            }

            return produto;
        }


        public void DaoDeletarProduto(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"DELETE FROM TB_PRODUTOS WHERE ID = @ID_PRODUTO";

                    comando.Parameters.AddWithValue("@ID_PRODUTO", id);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }
            }
        }


        public void DaoAtualizarProduto(Produto produto)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE TB_PRODUTOS 
                                   SET DESCRICAO = @DESCRICAO,
                                       PRECOUN = @PRECOUN,
                                       DATAVALIDADE = @DATAVALIDADE
                                   WHERE ID = @ID_PRODUTO";

                    comando.Parameters.AddWithValue("@ID_PRODUTO", produto.Id);
                    comando.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
                    comando.Parameters.AddWithValue("@PRECOUN", produto.Preco.ToString(CultureInfo.InvariantCulture));
                    comando.Parameters.AddWithValue("@DATAVALIDADE", produto.DataValidade);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }


        public void DaoAtualizarStatusProduto(Produto produto)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE TB_PRODUTOS 
                                   SET ATIVO = @NOVO_STATUS
                                   WHERE ID = @ID_PRODUTO";

                    comando.Parameters.AddWithValue("@ID_PRODUTO", produto.Id);
                    comando.Parameters.AddWithValue("@NOVO_STATUS", produto.Ativo);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }


        public void DaoAtualizarQuantidadeEstoqueProduto(int id, int novaQuantidade)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE TB_PRODUTOS 
                                   SET QUANTIDADEESTOQUE = @NOVA_QUANTIDADE
                                   WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", id);
                    comando.Parameters.AddWithValue("@NOVA_QUANTIDADE", novaQuantidade);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

    }
}
