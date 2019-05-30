using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Models
{
    public class Item : BaseModel
    {
        public Item()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public ICollection<Pedido> Pedidos { get; set; }

    }
}
