using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Models
{
    public partial class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<Item> Item { get; set; }

        public virtual DbSet<Pedido> Pedido { get; set; }
        
    }
}
