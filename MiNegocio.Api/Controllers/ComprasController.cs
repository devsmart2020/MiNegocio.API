using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraRepository _repository;

        public ComprasController(ICompraRepository repository)
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
        public async Task<ActionResult<Tbcompra>> GetById(int id)
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
        public async Task<ActionResult<Tbcompra>> Post(Tbcompra entity)
        {
            if (entity != null)
            {
                Tbcompra model = await _repository.Post(entity);
                if (model != null)
                {
                    return CreatedAtAction("Get", new { id = entity.IdCompra }, entity);

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
        public async Task<ActionResult<Tbcompra>> Put(int id, Tbcompra entity)
        {
            if (id != entity.IdCompra)
            {
                return BadRequest();
            }
            else
            {
                Tbcompra model = await _repository.Put(id, entity);
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

        [HttpPost("Reportes/comprasxfecha")]
        public async Task<ActionResult<IEnumerable<ComprasxFecha>>> ComprasxFecha(ComprasxFecha fechaModel)
        {
            DateTime fechaIni = fechaModel.FechaIni;
            DateTime fechaFin = fechaModel.FechaFin;
            IEnumerable<ComprasxFecha> query = await _repository.ComprasxFecha(fechaIni, fechaFin);
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