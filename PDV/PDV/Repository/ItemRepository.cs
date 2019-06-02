using Microsoft.EntityFrameworkCore;
using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPDVContext = PDV.Models.AppPDVContext;

namespace PDV.Repository
{
    public class ItemRepository : BaseRepository<Item>
    {
        public ItemRepository(AppPDVContext context) : base(context)
        {

        }

        public async Task<Item> GetById(long Id)
        {
            try
            {
                return await context.Set<Item>().FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Item>> GetList()
        {
            try
            {
                return await context.Set<Item>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(Item Item)
        {
            try
            {
                context.Set<Item>().Add(Item);
                await context.SaveChangesAsync();

                return Item.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Update(Item Item)
        {
            try
            {
                var entry = context.Set<Item>().Update(Item);
                entry.Property(x => x.Nome).IsModified = true;
                entry.Property(x => x.Valor).IsModified = true;

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remove(long Id)
        {
            try
            {
                Item item = await GetById(Id);

                context.Set<Item>().Remove(item);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
