using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaRepository  _repository;

        public MarcasController(IMarcaRepository repository)
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
        public async Task<ActionResult<Tbmarca>> GetById(int id)
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
        public async Task<ActionResult<Tbmarca>> Post(Tbmarca entity)
        {
            if (entity != null)
            {
                if (await _repository.Exists(entity.IdMarca))
                {
                    return Conflict(null);
                }
                else
                {
                    Tbmarca model = await _repository.Post(entity);
                    if (model != null)
                    {
                        return CreatedAtAction("Get", new { id = entity.IdMarca }, entity);

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
        public async Task<ActionResult<Tbmarca>> PutUsuario(int id, Tbmarca entity)
        {
            if (id != entity.IdMarca)
            {
                return BadRequest();
            }
            else
            {
                Tbmarca model = await _repository.Put(id, entity);
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
        public async Task<IActionResult> DeleteUsuario(int id)
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
    }
}
