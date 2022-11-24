using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroptechDonuts.Dominio.Entidades
{
    public class Produto
    {

        public string Descricao{ get; set; }
        public Double Preco { get; set; }
        public DateTime DataValidade{ get; set; }
        public int QuantidadeEstoque { get; set; }
        public bool Ativo{ get; set; }

        public Produto()
        {

        }

        public void AtualizaQuantidadeEstoque()
        {

        }


    }
}
