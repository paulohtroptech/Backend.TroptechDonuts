using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TroptechDonuts.Dominio.Interfaces;
using TroptechDonuts.Infra.Data.Dao;

namespace Troptech.Donuts.Repositorio
{
    public class PedidoRepository:IPedidoRepositorio
    {

        private readonly PedidoDao _pedidoDao = new();

    }
}
