using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repository;

        public ProductosController(IProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult<IEnumerable<Tbproducto>>> GetAll(Tbproducto entity)
        {
            IEnumerable<Tbproducto> tbproductos = await _repository.Get(entity);
            if (tbproductos.Count() > 0)
            {
                return Ok(tbproductos);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tbproducto>> GetById(string id)
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
        public async Task<ActionResult> Post(Tbproducto entity)
        {
            if (entity.IdModelo == 0)
            {
                entity.IdModelo = null;
            }
            if (entity != null)
            {
                if (await _repository.Post(entity))
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
        [HttpPost("crearvarios")]
        public async Task<ActionResult<Tbproducto>> Post(List<Tbproducto> entity)
        {
            if (entity.Count > 0)
            {
                for (int i = 0; i < entity.Count; i++)
                {
                    if (await _repository.Exists(entity[i].IdProducto))
                    {
                        return Conflict(null);
                    }
                }

                bool query = await _repository.PostList(entity);
                if (query)
                {
                    return CreatedAtAction("Get", new { id = entity[0].IdProducto }, entity);
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

        [HttpPost("Update")]
        public async Task<ActionResult> Put(Tbproducto entity)
        {
            if (entity.IdProducto != default)
            {
                if (await _repository.Put(entity))
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id != string.Empty)
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

        [HttpGet("Reportes/inventariolistado")]
        public async Task<ActionResult<IEnumerable<InventarioListatoReporte>>> GetInventarioListado()
        {
            IEnumerable<InventarioListatoReporte> query = await _repository.GetInventarioListado();
            if (query.Any())
            {
                return Ok(query);
            }
            else
            {
                return NotFound(null);
            }
        }
    }
}