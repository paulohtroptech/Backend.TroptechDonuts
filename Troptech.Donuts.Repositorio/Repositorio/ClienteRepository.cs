using System;
using System.Collections.Generic;
using TroptechDonuts.Dominio.Entidades;
using TroptechDonuts.Dominio.Interfaces;
using TroptechDonuts.Infra.Data.Dao;

namespace Troptech.Donuts.Repositorio
{
    public class ClienteRepository : IClienteRepositorio
    {
        private readonly ClienteDao _clientDao = new();

        public List<Cliente> BuscarTodosClientes()
        {
            //var listaDeClientes = _clientDao.DaoBuscarTodosClientes();

            //if(listaDeClientes.Count == 0)
            //    throw new Exception("Não existe nenhum cliente cadastrado.");

            return _clientDao.DaoBuscarTodosClientes();
        }

        public Cliente BuscarClientePorCpf()
        {
            throw new System.NotImplementedException();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public void AtualizarCliente(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarCliente(string cpf)
        {
            throw new System.NotImplementedException();
        }
    }
}
