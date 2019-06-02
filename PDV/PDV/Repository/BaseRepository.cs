using Microsoft.EntityFrameworkCore;
using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPDVContext = PDV.Models.AppPDVContext;

namespace PDV.Repository
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly DbSet<T> dbSet;
        protected readonly AppPDVContext context;

        public BaseRepository(AppPDVContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
    }
}
