using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoSerialesController : ControllerBase
    {
        private readonly IProductoSerialRepository _repository;

        public ProductoSerialesController(IProductoSerialRepository repository)
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
        public async Task<ActionResult<Tbproductoserial>> GetById(string id)
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
      
        [HttpPost("crearvarios")]
        public async Task<ActionResult<Tbproductoserial>> Post(List<Tbproductoserial> entity)
        {
            if (entity.Count > 0)
            {             
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Tbproductoserial>> Put(string id, Tbproductoserial entity)
        {
            if (id != entity.IdProducto)
            {
                return BadRequest();
            }
            else
            {
                Tbproductoserial model = await _repository.Put(id, entity);
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

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(List<string> id)
        {
            if (id.Count > 0)
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
                return NotFound();
            }        
        }

        [HttpGet("ListById/{id}")]
        public async Task<IEnumerable<Tbproductoserial>> GetListById(string id)
        {
            return await _repository.GetListById(id);
        }
    }
}
