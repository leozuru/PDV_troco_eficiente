using Microsoft.EntityFrameworkCore;
using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext = PDV.Models.AppContext;

namespace PDV.Repository
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly DbSet<T> dbSet;
        protected readonly AppContext context;

        public BaseRepository(AppContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
    }
}
