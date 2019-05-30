using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.ViewModel
{
    public class PedidoViewModel : Pedido
    {
        public PedidoViewModel()
        {

        }

        public PedidoViewModel(Pedido pedido)
        {
            Id = pedido.Id;
            DataAbertura = pedido.DataAbertura;
            DataFechamento = pedido.DataFechamento;
            IdItem = pedido.IdItem;
            IdUsuario = pedido.IdUsuario;
            Item = pedido.Item;
            Pago = pedido.Pago;
            Usuario = pedido.Usuario;

        }
    }
}
