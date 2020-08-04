using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaProductosController : ControllerBase
    {
        private readonly IVentaProductoRepository _repository;

        public VentaProductosController(IVentaProductoRepository repository)
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
        public async Task<ActionResult<Tbventaproducto>> GetById(int id)
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
        public async Task<ActionResult<Tbventaproducto>> Post(List<Tbventaproducto> entity)
        {
            if (entity != null)
            {
                bool query = await _repository.Post(entity);
                if (query)
                {
                    return Created("api/VentaProductos", query);
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
        public async Task<ActionResult<Tbventaproducto>> Put(int id, Tbventaproducto entity)
        {
            if (id != entity.IdVenta)
            {
                return BadRequest();
            }
            else
            {
                Tbventaproducto model = await _repository.Put(id, entity);
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
    }
}