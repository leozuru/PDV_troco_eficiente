using PDV.Repository;
using PDV.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PDV.Test
{
    public class TestTrocoEficiente
    {
        PedidoService pedidoService = new PedidoService();

        private readonly Dictionary<string, int> trocoEficiente20 = new Dictionary<string, int>
                {
                    { "100", 0 },
                    { "50", 0 },
                    { "20", 1 },
                    { "10", 0 },
                    { "0,50", 0 },
                    { "0,10", 0 },
                    { "0,05", 0 },
                    { "0,01", 0 },
                };

        private readonly Dictionary<string, int> trocoEficiente30 = new Dictionary<string, int>
                {
                    { "100", 0 },
                    { "50", 0 },
                    { "20", 1 },
                    { "10", 1 },
                    { "0,50", 0 },
                    { "0,10", 0 },
                    { "0,05", 0 },
                    { "0,01", 0 },
                };

        private readonly Dictionary<string, int> trocoEficiente40 = new Dictionary<string, int>
                {
                    { "100", 0 },
                    { "50", 0 },
                    { "20", 2 },
                    { "10", 0 },
                    { "0,50", 0 },
                    { "0,10", 0 },
                    { "0,05", 0 },
                    { "0,01", 0 },
                };

        private readonly Dictionary<string, int> trocoEficiente70 = new Dictionary<string, int>
                {
                    { "100", 0 },
                    { "50", 1 },
                    { "20", 1 },
                    { "10", 0 },
                    { "0,50", 0 },
                    { "0,10", 0 },
                    { "0,05", 0 },
                    { "0,01", 0 },
                };

        private readonly Dictionary<string, int> trocoEficiente80 = new Dictionary<string, int>
                {
                    { "100", 0 },
                    { "50", 1 },
                    { "20", 1 },
                    { "10", 1 },
                    { "0,50", 0 },
                    { "0,10", 0 },
                    { "0,05", 0 },
                    { "0,01", 0 },
                };

        [Theory]
        [InlineData(100,80)] // troco 20
        [InlineData(50,20)] // troco 30
        [InlineData(100,60)] // troco 40
        [InlineData(100,30)] // troco 70
        [InlineData(100,20)] // troco 80
        public void TestTroco(int valorPago, int totalPedido)
        {
            Dictionary<string, int> trocoEficiente = new Dictionary<string, int>();

            Dictionary<string, int> troco = pedidoService.GerarTrocoEficiente(valorPago, totalPedido);

            switch (valorPago - totalPedido)
            {
                case 20:
                    trocoEficiente = trocoEficiente20;
                    break;
                case 30:
                    trocoEficiente = trocoEficiente30;
                    break;
                case 40:
                    trocoEficiente = trocoEficiente40;
                    break;
                case 70:
                    trocoEficiente = trocoEficiente70;
                    break;
                case 80:
                    trocoEficiente = trocoEficiente80;
                    break;
                default:
                    Assert.False(true);
                    break;
            }

            foreach (var item in trocoEficiente)
            {
                troco.TryGetValue(item.Key, out int Nota);
                Assert.Equal(item.Value, Nota);
            }
            

        }

        [Fact]
        public void TestTroco0() //sem troco - conta maior que o valor pago
        {

            Dictionary<string, int> troco = pedidoService.GerarTrocoEficiente(30, 100);

            Assert.Null(troco);

        }

    }
}
