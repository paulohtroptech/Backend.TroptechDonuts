using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                    comando.CommandText = @"SELECT * FROM TB_CLIENTES WHERE ID = 0;";

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
    }
}
