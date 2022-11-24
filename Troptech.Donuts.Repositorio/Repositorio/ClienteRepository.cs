using TroptechDonuts.Dominio.Interfaces;
using TroptechDonuts.Infra.Data.Dao;

namespace Troptech.Donuts.Repositorio
{
    public class ClienteRepository : ICliente
    {
        private readonly ClienteDao _clientDao = new();
    }
}
