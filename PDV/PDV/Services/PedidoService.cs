using PDV.Models;
using PDV.Repository;
using PDV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDV.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository pedidoRepository;

        public PedidoService(PedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public PedidoService()
        {

        }

        public async Task<PedidoViewModel> GetById(long Id)
        {
            try
            {
                PedidoViewModel pedidoViewModel = new PedidoViewModel(await pedidoRepository.GetById(Id));
                return pedidoViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IEnumerable<PedidoViewModel>> GetByUsuario(long IdUsuario)
        {
            try
            {

                List<PedidoViewModel> ListaPedidos = new List<PedidoViewModel>();

                IEnumerable<Pedido> pedidos = await pedidoRepository.GetByUsuario(IdUsuario);

                foreach (Pedido pedido in pedidos)
                {
                    ListaPedidos.Add(new PedidoViewModel(pedido));
                };

                return ListaPedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<PedidoViewModel>> GetList()
        {
            try
            {
                List<PedidoViewModel> ListaPedidos = new List<PedidoViewModel>();

                IEnumerable<Pedido> pedidos = await pedidoRepository.GetList();

                foreach (Pedido pedido in pedidos)
                {
                    ListaPedidos.Add(new PedidoViewModel(pedido));
                };

                return ListaPedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<PedidoFechadoViewModel> FecharByUsuario(long id)
        {
            try
            {
                PedidoFechadoViewModel pedidoFechadoViewModel = new PedidoFechadoViewModel
                {
                    TotalPedido = await pedidoRepository.FecharByUsuario(id)
                };

                return pedidoFechadoViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<PedidoFechadoViewModel> PagarByUsuario(PedidoFechadoViewModel pedidoFechadoViewModel)
        {
            try
            {
                pedidoFechadoViewModel.TotalPedido = await pedidoRepository.FecharByUsuario(pedidoFechadoViewModel.IdUsuario);

                pedidoFechadoViewModel.Troco = pedidoFechadoViewModel.ValorPago - pedidoFechadoViewModel.TotalPedido;

                pedidoFechadoViewModel.Notas = GerarTrocoEficiente(pedidoFechadoViewModel.ValorPago, pedidoFechadoViewModel.TotalPedido);

                return pedidoFechadoViewModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Dictionary<string, int> GerarTrocoEficiente(decimal valorPago, decimal totalPedido)
        {
            try
            {
                Dictionary<string, int> trocoEficiente = new Dictionary<string, int>
                {
                    { "100", 0 },
                    { "50", 0 },
                    { "20", 0 },
                    { "10", 0 },
                    { "0,50", 0 },
                    { "0,10", 0 },
                    { "0,05", 0 },
                    { "0,01", 0 },
                };

                decimal troco = valorPago - totalPedido;
                if (troco > 0)
                {
                    while (troco > 0)
                    {

                        if (troco >= 100)
                        {
                            troco = TratarTrocoEficiente(trocoEficiente, troco, "100");
                            continue;
                        }

                        if (troco >= 50)
                        {
                            troco = TratarTrocoEficiente(trocoEficiente, troco, "50");
                            continue;
                        }

                        if (troco >= 20)
                        {
                            troco = TratarTrocoEficiente(trocoEficiente, troco, "20");
                            continue;
                        }

                        if (troco >= 10)
                        {
                            troco = TratarTrocoEficiente(trocoEficiente, troco, "10");
                            continue;
                        }

                        if (troco >= 5)
                        {
                            troco = TratarTrocoEficiente(trocoEficiente, troco, "5");
                            continue;
                        }

                    }
                    
                }
                else
                {
                    trocoEficiente = null;
                }



                return trocoEficiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal TratarTrocoEficiente(Dictionary<string, int> trocoEficiente, decimal troco, string valor)
        {
            try
            {
                trocoEficiente.TryGetValue(valor, out int qtd);
                trocoEficiente[valor] = qtd + 1;

                return troco - Convert.ToInt32(valor);

            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public async Task<long> Insert(PedidoViewModel pedidoViewModel)
        {
            try
            {
                Pedido pedido = MontarPedido(pedidoViewModel);

                return await pedidoRepository.Insert(pedido);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Remove(long Id)
        {
            try
            {
                await pedidoRepository.Remove(Id);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(PedidoViewModel pedidoViewModel)
        {
            try
            {
                Pedido pedido = MontarPedido(pedidoViewModel);

                await pedidoRepository.Update(pedido);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Pedido MontarPedido(PedidoViewModel pedidoViewModel)
        {
            try
            {
                Pedido pedido = new Pedido()
                {
                    DataAbertura = pedidoViewModel.DataAbertura,
                    DataFechamento = pedidoViewModel.DataFechamento,
                    Id = pedidoViewModel.Id,
                    IdItem = pedidoViewModel.IdItem,
                    IdUsuario = pedidoViewModel.IdUsuario,
                    Item = pedidoViewModel.Item,
                    Pago = pedidoViewModel.Pago,
                    Usuario = pedidoViewModel.Usuario
                };

                return pedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
