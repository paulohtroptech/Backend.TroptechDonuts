using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using TroptechDonuts.Dominio.Entidades;

namespace TroptechDonuts.Infra.Data.Dao
{
    public class ClienteDao
    {

        private const string _connectionString = @"server=\TROPTECH;database=DB_TROPTECHDONUTS;user id=sa;password=;Encrypt=False";

        public List<Cliente> DaoBuscarTodosClientes()
        {
            var listaDeClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    comando.CommandText = @"SELECT * FROM TB_CLIENTES;";

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = new()
                        {
                            Cpf = leitor["CPF"].ToString(),
                            Nome = leitor["NOME"].ToString(),
                            DataNascimento = DateTime.Parse(leitor["DATANASCIMENTO"].ToString()),
                            PontosFidelidade = double.Parse(leitor["PONTOSFIDELIDADE"].ToString())
                        };

                        listaDeClientes.Add(clienteBuscado);
                    }
                }

                return listaDeClientes;
            }
        }

        public Cliente DaoBuscarClientePorCPF(string cpf)
        {

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT
                                        CPF,
                                        NOME,
                                        DATANASCIMENTO,
                                        PONTOSFIDELIDADE
                                   FROM TB_CLIENTES 
                                   WHERE CPF = @CPF_CLIENTE";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = new()
                        {
                            Cpf = leitor["CPF"].ToString(),
                            Nome = leitor["NOME"].ToString(),
                            DataNascimento = DateTime.Parse(leitor["DATANASCIMENTO"].ToString()),
                            PontosFidelidade = double.Parse(leitor["PONTOSFIDELIDADE"].ToString())
                        };

                        return clienteBuscado;
                    }
                }
            }

            return null;
        }

//        public Pedido DaoBuscarPedidoPorCpfCliente(string cpf)
//        {

//            using (var conexao = new SqlConnection(_connectionString))
//            {
//                conexao.Open();

//                using (var comando = new SqlCommand())
//                {

//                    comando.Connection = conexao;

//                    string sql = @"SELECT * FROM TB_PEDIDOS WHERE CPF_CLIENTE = @CPF";

//                    comando.CommandText = sql;

//                    comando.Parameters.AddWithValue("@CPF", cpf);

//                    var leitor = comando.ExecuteReader();

//                    while (leitor.Read())
//                    {
//                        Pedido pedidoBuscado = new(
//                            int.Parse(leitor["CODIGO"].ToString()),
//                            new Cliente(leitor["CPF"].ToString()),
//                            new Produto(int.Parse(leitor["ID_PRODUTO"].ToString())),
//                            int.Parse(leitor["QUANTIDADE"].ToString())
//                     );

//                        return pedidoBuscado;
//                    }
//                }
//            }

////SELECT TB_CLIENTES.CPF, TB_PEDIDOS.ID FROM TB_CLIENTES
////INNER JOIN TB_PEDIDOS ON TB_CLIENTES.CPF = TB_PEDIDOS.CPF_CLIENTE

//            return null;
//        }


        public Cliente DaoCadastrarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT INTO TB_CLIENTES (CPF, NOME, DATANASCIMENTO)
                                   VALUES (@CPF,
                                           @NOME,
                                           @DATANASCIMENTO)";

                    comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
                    comando.Parameters.AddWithValue("@NOME", cliente.Nome);
                    comando.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }

            return cliente;
        }


        public void DaoDeletarCliente(string cpfCliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"DELETE FROM TB_PEDIDOS
                                   WHERE CPF_CLIENTE IN(select CPF from TB_CLIENTES WHERE CPF_CLIENTE = @CPF_CLIENTE)
                                   DELETE FROM TB_CLIENTES WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpfCliente);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }
            }
        }

        public void DaoAtualizarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE TB_CLIENTES 
                                   SET  NOME = @NOME,
                                   DATANASCIMENTO = @DATANASCIMENTO
                                   WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cliente.Cpf);
                    comando.Parameters.AddWithValue("@NOME", cliente.Nome);
                    comando.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DaoAtualizaPontosFidelidadeCliente(string cpf, double novosPontos)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE TB_CLIENTES 
                                   SET  PONTOSFIDELIDADE = @PONTOS_CLIENTE
                                   WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);
                    comando.Parameters.AddWithValue("@PONTOS_CLIENTE", novosPontos);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }


    }
}
