using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Pedido
    {
        public Cliente Cliente { get; set; }
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get; set; }
        public StatusPedido Status { get; set; }

        public Pedido()
        {

        }



    }
}
