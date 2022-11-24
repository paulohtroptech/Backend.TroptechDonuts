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

        Cliente BuscarClientePorCpf();

        void CadastrarCliente(Cliente cliente);

        void AtualizarCliente(Cliente cliente);

        void DeletarCliente(string cpf);

    }

}
