using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public Vendedor Vendedor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataVenda { get; set; } 
        public EnumStatusPedido StatusVenda { get; set; }
    }
}