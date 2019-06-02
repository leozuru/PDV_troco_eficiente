using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Models
{
    public partial class AppPDVContext : DbContext
    {
        public AppPDVContext(DbContextOptions<AppPDVContext> options) : base(options)
        {

        }

        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<Item> Item { get; set; }

        public virtual DbSet<Pedido> Pedido { get; set; }
        
    }
}
