using Domain.Interface.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Cliente : Base,  IAggregateRoot
    {
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string UltimaCompra { get; set; }
        public double Valor { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
    }
}
