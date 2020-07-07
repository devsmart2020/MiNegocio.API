using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditosController : ControllerBase
    {
        private readonly ICreditoRepository _repository;

        public CreditosController(ICreditoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _repository.Get();
            return Ok(entities);
        }

        [HttpPost]
        public async Task<ActionResult<Tbcredito>> Post(Tbcredito entity)
        {
            if (entity != null)
            {
                Tbcredito model = await _repository.Post(entity);
                if (model != null)
                {
                    return CreatedAtAction("Get", new { id = entity.IdCredito }, entity);

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

        [HttpGet("Reportes/creditoscliente")]
        public async Task<ActionResult<IEnumerable<CreditoClienteCartera>>> LiquidacionVentaxFecha()
        {           
            IEnumerable<CreditoClienteCartera> query = await _repository.GetCreditoClientes();
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
