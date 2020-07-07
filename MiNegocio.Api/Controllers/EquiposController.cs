using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly IEquipoRepository _repository;

        public EquiposController(IEquipoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _repository.Get();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tbequipo>> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tbequipo>> Post(Tbequipo entity)
        {
            if (entity != null)
            {
                Tbequipo model = await _repository.Post(entity);
                if (model != null)
                {
                    return CreatedAtAction("Get", new { id = entity.IdModelo }, entity);

                }
                else
                {
                    return Conflict(null);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tbequipo>> Put(int id, Tbequipo entity)
        {
            if (id != entity.IdModelo)
            {
                return BadRequest();
            }
            else
            {
                Tbequipo model = await _repository.Put(id, entity);
                if (model != null)
                {
                    return Ok(model);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                if (await _repository.Delete(id))
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("equipoCliente/{idCliente}")]
        public async Task<ActionResult<object>>EquipoCliente(string idCliente)
        {
            if (!string.IsNullOrEmpty(idCliente))
            {
                return Ok(await _repository.EquipoCliente(idCliente));                
            }
            else
            {
                return BadRequest();
            }
           
        }
    }
}