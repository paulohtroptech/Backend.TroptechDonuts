using System;
using System.Collections.Generic;
using TroptechDonuts.Dominio.Entidades;
using TroptechDonuts.Dominio.Excecoes;
using TroptechDonuts.Dominio.Interfaces;
using TroptechDonuts.Infra.Data.Dao;

namespace Troptech.Donuts.Repositorio
{
    public class ClienteRepository : IClienteRepositorio
    {
        private readonly ClienteDao _clientDao = new();


        public List<Cliente> BuscarTodosClientes()
        {
            var listaDeClientes = _clientDao.DaoBuscarTodosClientes();

            if (listaDeClientes.Count == 0)
                throw new ClienteException("Ops, parece que não existe nenhum cliente cadastrado.");

            return listaDeClientes;
        }


        public Cliente BuscarClientePorCpf(string cpf)
        {
            var clienteBuscado = _clientDao.DaoBuscarClientePorCPF(cpf);

            if (clienteBuscado == null)
                throw new ClienteException("Ops, parece que esse cliente não está cadastrado.");

            return clienteBuscado;
        }


        public Cliente CadastrarCliente(Cliente cliente)
        {

            cliente.ValidarDadosCliente();

            var clienteBuscado = _clientDao.DaoBuscarClientePorCPF(cliente.Cpf);

            if (clienteBuscado != null)
                throw new ClienteException("Ops, parece que esse cliente já está cadastrado.");

            _clientDao.DaoCadastrarCliente(cliente);

            return cliente;
        }


        public void DeletarCliente(string cpf)
        {
            var clienteBuscado = _clientDao.DaoBuscarClientePorCPF(cpf);

            if (clienteBuscado == null)
                throw new ClienteException("Ops, parece que esse cliente não está cadastrado.");

            _clientDao.DaoDeletarCliente(cpf);
        }


        public Cliente AtualizarCliente(Cliente cliente)
        {
            cliente.ValidarDadosCliente();

            var clienteBuscado = _clientDao.DaoBuscarClientePorCPF(cliente.Cpf);

            if (clienteBuscado == null)
                throw new ClienteException("Ops, parece que esse cliente não está cadastrado.");

            _clientDao.DaoAtualizarCliente(cliente);

            return cliente;
        }

    }
}
