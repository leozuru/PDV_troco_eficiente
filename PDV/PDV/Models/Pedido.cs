using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            
        }

        public long IdUsuario { get; set; }

        public long IdItem { get; set; }

        public DateTime DataAbertura { get; set; } = DateTime.Now;

        public DateTime DataFechamento { get; set; }

        public bool Pago { get; set; } = false;

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdItem")]
        public Item Item { get; set; }
    }
}
