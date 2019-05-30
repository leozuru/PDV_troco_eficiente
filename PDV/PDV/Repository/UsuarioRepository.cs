using Microsoft.EntityFrameworkCore;
using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext = PDV.Models.AppContext;

namespace PDV.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(AppContext context) : base(context)
        {

        }

        public async Task<Usuario> GetById(long Id)
        {
            try
            {
                return await context.Set<Usuario>().FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Usuario>> GetList()
        {
            try
            {
                return await context.Set<Usuario>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(Usuario usuario)
        {
            try
            {
                context.Set<Usuario>().Add(usuario);
                await context.SaveChangesAsync();

                return usuario.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Update(Usuario usuario)
        {
            try
            {
                var entry = context.Set<Usuario>().Update(usuario);
                entry.Property(x => x.Nome).IsModified = true;

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
                Usuario usuario = await GetById(Id);

                context.Set<Usuario>().Remove(usuario);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
