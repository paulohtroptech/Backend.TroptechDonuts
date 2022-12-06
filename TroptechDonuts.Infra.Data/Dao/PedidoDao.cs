using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using TroptechDonuts.Dominio;
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
                    comando.CommandText =
                        @"SELECT 
                            PED.ID,
                            COALESCE(NOME, 'NÃO INFORMADO') as NOME_CLIENTE,
                            PED.DATAPEDIDO,
                            PED.VALORTOTAL,
                            PED.QUANTIDADE,
                            PED.STATUSPEDIDO,
                            PROD.PRECOUN 
                          FROM TB_PEDIDOS AS PED
                            LEFT JOIN TB_CLIENTES AS CLI
                              ON PED.CPF_CLIENTE = CLI.CPF
                            LEFT JOIN TB_PRODUTOS AS PROD
                              ON PED.ID_PRODUTO = PROD.ID";
                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Pedido pedidoBuscado = new();

                        pedidoBuscado.Id = int.Parse(leitor["ID"].ToString());
                        pedidoBuscado.Cliente = new()
                        {
                            Nome = leitor["NOME_CLIENTE"].ToString(),
                        };
                        pedidoBuscado.Produto = new()
                        {
                            Preco = double.Parse(leitor["PRECOUN"].ToString()),
                        };
                        pedidoBuscado.DataPedido = DateTime.Parse(leitor["DATAPEDIDO"].ToString());
                        pedidoBuscado.Quantidade = int.Parse(leitor["QUANTIDADE"].ToString());
                        pedidoBuscado.ValorTotal = double.Parse(leitor["VALORTOTAL"].ToString());
                        pedidoBuscado.Status = (StatusPedido)int.Parse((leitor["STATUSPEDIDO"].ToString()));

                        //Pedido pedidoBuscado = new()
                        //{
                        //    Id = int.Parse(leitor["ID"].ToString()),
                        //    Cliente = new Cliente()
                        //    {
                        //        Nome = leitor["NOME_CLIENTE"].ToString(),
                        //        Cpf = leitor["CPF"].ToString()
                        //    },
                        //    Produto = new Produto()
                        //    {
                        //        Id = int.Parse(leitor["ID_PRODUTO"].ToString())
                        //    },
                        //    Quantidade = int.Parse(leitor["QUANTIDADE"].ToString()),
                        //    ValorTotal = double.Parse(leitor["VALORTOTAL"].ToString()),
                        //    Status = (StatusPedido)int.Parse((leitor["STATUSPEDIDO"].ToString()))
                        //};
                        
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
                            int.Parse(leitor["ID"].ToString()),
                            new Cliente() {
                                Cpf = leitor["CPF_CLIENTE"].ToString()
                            },
                            new Produto()
                            {
                                Id = int.Parse(leitor["ID_PRODUTO"].ToString())
                            },
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
                    comando.CommandText = @"INSERT INTO TB_PEDIDOS (CPF_CLIENTE, ID_PRODUTO, DATAPEDIDO, QUANTIDADE, VALORTOTAL, STATUSPEDIDO)
                                            VALUES (@CPF_CLIENTE, @ID_PRODUTO, @DATAPEDIDO, @QUANTIDADE, @VALORTOTAL, @STATUSPEDIDO)";

                    if(pedido.Cliente != null) 
                    {
                        comando.Parameters.AddWithValue("@CPF_CLIENTE", pedido.Cliente.Cpf);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@CPF_CLIENTE", "");
                    }
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
