using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Globalization;
using TroptechDonuts.Dominio.Entidades;

namespace TroptechDonuts.Infra.Data.Dao
{
    public class PedidoDao
    {

        private const string _connectionString = @"server=NDD-NOT-DEV504\TROPTECH;database=DB_TROPTECHDONUTS;user id=sa;password=Xw6q2@12345678;Encrypt=False";


        public List<Pedido> DaoBuscarTodosPedidos()
        {
            var listaPedidos = new List<Pedido>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"SELECT * FROM TB_PEDIDOS";

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Pedido pedidoBuscado = new(
                            int.Parse(leitor["CODIGO"].ToString()),
                            new Cliente(leitor["CPF"].ToString()),
                            new Produto(int.Parse(leitor["ID_PRODUTO"].ToString())),
                            int.Parse(leitor["QUANTIDADE"].ToString())
                        );
                        
                        listaPedidos.Add(pedidoBuscado);
                    }
                }

                return listaPedidos;
            }
        }

        public Pedido DaoBuscarPedidoPorId(int id)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM TB_PEDIDOS WHERE ID = @ID_PEDIDO";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@ID_PEDIDO", id);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Pedido pedidoBuscado = new(
                            int.Parse(leitor["CODIGO"].ToString()),
                            new Cliente(leitor["CPF"].ToString()),
                            new Produto(int.Parse(leitor["ID_PRODUTO"].ToString())),
                            int.Parse(leitor["QUANTIDADE"].ToString())
                     );

                        return pedidoBuscado;
                    }
                }
            }

            return null;
        }

        public Pedido DaoCadastrarPedido(Pedido pedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = @"INSERT INTO TB_PEDIDOS 
                                            VALUES (@CPF_CLIENTE, @ID_PRODUTO, @DATAPEDIDO, @QUANTIDADE, @VALORTOTAL, @STATUSPEDIDO)";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", pedido.Cliente.Cpf);
                    comando.Parameters.AddWithValue("@ID_PRODUTO", pedido.Produto.Id);
                    comando.Parameters.AddWithValue("@DATAPEDIDO", pedido.DataPedido);
                    comando.Parameters.AddWithValue("@QUANTIDADE", pedido.Quantidade);
                    comando.Parameters.AddWithValue("@VALORTOTAL", pedido.ValorTotal.ToString(CultureInfo.InvariantCulture));
                    comando.Parameters.AddWithValue("@STATUSPEDIDO", pedido.Status);

                    comando.ExecuteNonQuery();
                }
            }

            return pedido;
        }

        public void DaoDeletarPedido(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"DELETE FROM TB_PEDIDOS WHERE ID = @ID_PEDIDO";

                    comando.Parameters.AddWithValue("@ID_PEDIDO", id);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }
            }
        }

        public void DaoAtualizarPedido(Pedido pedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE TB_PEDIDOS 
                                   SET CPF_CLIENTE = @CPFCLIENTE,
                                       ID_PRODUTO = @IDPRODUTO, 
                                       DATAPEDIDO = @DATA_PEDIDO,
                                       QUANTIDADE = @QUANTIDADE_PEDIDO,
                                       VALORTOTAL = @VALOR_TOTAL,
                                       STATUSPEDIDO = @STATUS_PEDIDO
                                   WHERE ID = @ID_PEDIDO";

                    comando.Parameters.AddWithValue("@ID_PEDIDO", pedido.Id);
                    comando.Parameters.AddWithValue("@CPFCLIENTE", pedido.Cliente.Cpf);
                    comando.Parameters.AddWithValue("@IDPRODUTO", pedido.Produto.Id);
                    comando.Parameters.AddWithValue("@DATA_PEDIDO", pedido.DataPedido);
                    comando.Parameters.AddWithValue("@QUANTIDADE_PEDIDO", pedido.Quantidade);
                    comando.Parameters.AddWithValue("@VALOR_TOTAL", pedido.ValorTotal);
                    comando.Parameters.AddWithValue("@STATUS_PEDIDO", pedido.Status);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DaoAtualizarStatusPedido(Pedido pedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE TB_PEDIDOS 
                                   SET STATUSPEDIDO = @NOVO_STATUS
                                   WHERE ID = @ID_PRODUTO";

                    comando.Parameters.AddWithValue("@ID_PRODUTO", pedido.Id);
                    comando.Parameters.AddWithValue("@NOVO_STATUS", pedido.Status);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }



    }
}
