using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDV.Services;
using PDV.ViewModel;

namespace PDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ActionResult result = null;
            try
            {
                result = Ok(await pedidoService.GetList());
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }


        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await pedidoService.GetById(id));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoViewModel pedidoViewModel)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await pedidoService.Insert(pedidoViewModel));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] PedidoViewModel pedidoViewModel)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await pedidoService.Update(pedidoViewModel));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await pedidoService.Remove(id));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }
    }
}
