using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly IModeloRepository _repository;

        public ModelosController(IModeloRepository repository)
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
        public async Task<ActionResult<Tbmodelo>> GetById(int id)
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
        public async Task<ActionResult<Tbmodelo>> Post(Tbmodelo entity)
        {
            if (entity != null)
            {
                if (await _repository.Exists(entity.IdModelo))
                {
                    return Conflict(null);
                }
                else
                {
                    Tbmodelo model = await _repository.Post(entity);
                    if (model != null)
                    {
                        return CreatedAtAction("Get", new { id = entity.IdModelo }, entity);

                    }
                    else
                    {
                        return Conflict(null);
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tbmodelo>> Put(int id, Tbmodelo entity)
        {
            if (id != entity.IdModelo)
            {
                return BadRequest();
            }
            else
            {
                Tbmodelo model = await _repository.Put(id, entity);
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

        [HttpGet("combo/{idMarca}/{idTipoEquipo}")]
        public async Task<ActionResult<List<Tbmodelo>>>ComboModelo(int idMarca, int idTipoEquipo)
        {
             return Ok(await _repository.Combo(idMarca, idTipoEquipo));
        }
    }
}