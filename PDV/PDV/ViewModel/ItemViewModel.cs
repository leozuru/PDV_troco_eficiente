using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.ViewModel
{
    public class ItemViewModel : Item
    {
        public ItemViewModel()
        {

        }

        public ItemViewModel(Item item)
        {
            Data = item.Data;
            Id = item.Id;
            Nome = item.Nome;
            Pedidos = item.Pedidos;
            Valor = item.Valor;

        }
    }
}
