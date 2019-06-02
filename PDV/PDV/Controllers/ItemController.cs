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
    public class ItemController : ControllerBase
    {
        private readonly ItemService itemService;

        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ActionResult result = null;
            try
            {
                result = Ok(await itemService.GetList());
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await itemService.GetById(id));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemViewModel itemViewModel)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await itemService.Insert(itemViewModel));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ItemViewModel itemViewModel)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await itemService.Update(itemViewModel));
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
                result = Ok(await itemService.Remove(id));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }
    }
}
