﻿using Microsoft.EntityFrameworkCore;
using PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppPDVContext = PDV.Models.AppPDVContext;

namespace PDV.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(AppPDVContext context) : base(context)
        {
            
        }

        public async Task<Pedido> GetById(long Id)
        {
            try
            {
                return await context.Set<Pedido>().Include(x => x.Usuario).Include(x => x.Item).Where(x => x.Id == Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Pedido>> GetByUsuario(long Id)
        {
            try
            {
                return await context.Set<Pedido>().Include(x => x.Item).Where(x => x.IdUsuario == Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Pedido>> GetList()
        {
            try
            {
                return await context.Set<Pedido>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> Insert(Pedido Pedido)
        {
            try
            {
                context.Set<Pedido>().Add(Pedido);
                await context.SaveChangesAsync();

                return Pedido.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Update(Pedido Pedido)
        {
            try
            {
                Pedido.DataFechamento = DateTime.Now;

                var entry = context.Set<Pedido>().Update(Pedido);
                entry.Property(x => x.Pago).IsModified = true;
                entry.Property(x => x.DataFechamento).IsModified = true;

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
                Pedido Pedido = await GetById(Id);

                context.Set<Pedido>().Remove(Pedido);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task FecharPedido(long id)
        {
            try
            {
                IEnumerable<Pedido> pedidos = await context.Set<Pedido>()
                                                            .Where(x => x.IdUsuario == id)
                                                            .Where(x => x.Pago == false)
                                                            .ToListAsync();

                foreach (Pedido pedido in pedidos)
                {
                    pedido.Pago = true;
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<decimal> FecharByUsuario(long id)
        {
            try
            {
                decimal troco = await context.Set<Pedido>()
                                            .Where(x => x.IdUsuario == id)
                                            .Where(x => x.Pago == false)
                                            .SumAsync(x => x.Item.Valor);

                await FecharPedido(id);

                return troco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
