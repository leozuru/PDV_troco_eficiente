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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        } 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ActionResult result = null;
            try
            {
                result = Ok(await usuarioService.GetList());
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
                result = Ok(await usuarioService.GetById(id));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioViewModel usuarioViewModel)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await usuarioService.Insert(usuarioViewModel));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UsuarioViewModel usuarioViewModel)
        {
            ActionResult result = null;
            try
            {
                result = Ok(await usuarioService.Update(usuarioViewModel));
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
                result = Ok(await usuarioService.Remove(id));
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }

            return result;
        }
    }
}
