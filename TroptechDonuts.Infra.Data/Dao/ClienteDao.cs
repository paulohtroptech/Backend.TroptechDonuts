﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using TroptechDonuts.Dominio.Entidades;

namespace TroptechDonuts.Infra.Data.Dao
{
    public class ClienteDao
    {

        private const string _connectionString = @"server=NDD-NOT-DEV504\TROPTECH;database=DB_TROPTECHDONUTS;user id=sa;password=Xw6q2@12345678;Encrypt=False";

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
                            Nome = leitor["NOME"].ToString(),
                            Cpf = leitor["CPF"].ToString(),
                            DataNascimento = DateTime.Parse(leitor["DATANASCIMENTO"].ToString())
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
                                       DATANASCIMENTO
                                   FROM TB_CLIENTES WHERE CPF = @CPF_CLIENTE";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpf);

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteBuscado = new()
                        {
                            Cpf = leitor["CPF"].ToString(),
                            Nome = leitor["NOME"].ToString(),
                            DataNascimento = DateTime.Parse(leitor["DATANASCIMENTO"].ToString())
                        };

                        return clienteBuscado;
                    }
                }
            }

            return null;
        }


        public Cliente DaoCadastrarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT TB_CLIENTES
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

                    string sql = @"DELETE FROM TB_CLIENTES WHERE CPF = @CPF_CLIENTE";

                    comando.Parameters.AddWithValue("@CPF_CLIENTE", cpfCliente);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();

                }
            }
        }

        public Cliente DaoAtualizarCliente(Cliente cliente)
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

            return null;
        }


    }
}
