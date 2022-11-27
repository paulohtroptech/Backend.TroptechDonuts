using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroptechDonuts.Dominio.Entidades;

namespace TroptechDonuts.Dominio.Interfaces
{
    public interface IClienteRepositorio
    {
        List<Cliente> BuscarTodosClientes();

        Cliente BuscarClientePorCpf(string cpf);

        Cliente CadastrarCliente(Cliente cliente);

        Cliente AtualizarCliente(Cliente cliente);

        void DeletarCliente(string cpf);
    }

}
