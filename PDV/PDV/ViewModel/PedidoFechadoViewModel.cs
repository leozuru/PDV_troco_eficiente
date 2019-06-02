using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.ViewModel
{
    public class PedidoFechadoViewModel
    {
        public long IdUsuario { get; set; }
        public decimal TotalPedido { get; set; }
        public decimal ValorPago { get; set; }
        public decimal Troco { get; set; }
        public Dictionary<string, int> TrocoEficiente { get; set; } = null;
    }
}
