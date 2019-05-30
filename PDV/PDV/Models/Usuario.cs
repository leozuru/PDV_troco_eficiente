using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Models
{
    public class Usuario : BaseModel
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string Nome { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

    }
}
