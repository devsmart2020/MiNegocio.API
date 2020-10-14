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
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenRepository<Tborden> _repository;

        public OrdenesController(IOrdenRepository<Tborden> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Tborden>> Post(Tborden entity)
        {
            if (!string.IsNullOrEmpty(entity.IdCliente))
            {
                Tborden orden = await _repository.Post(entity);
                if (orden != null)
                {
                    return Ok(orden);
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

        [HttpPost("Remision")]
        public async Task<ActionResult<IEnumerable<OrdenRemisionCliente>>> RemisionOrden(OrdenRemisionCliente entity)
        {
            if (entity.IdOrden != default)
            {
                IEnumerable<OrdenRemisionCliente> remisionCliente = await _repository.RemisionCliente(entity);
                if (remisionCliente.Count() > 0)
                {
                    return Ok(remisionCliente);
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

        [HttpPost("GetAll")] 
        public async Task<ActionResult<IEnumerable<Tborden>>> GetOrdenes(Tborden entity)
        {
            if (entity.IdOrden != default)
            {
                IEnumerable<Tborden> ordenes = await _repository.Get(entity);
                if (ordenes.Count() > 0)
                {
                    return Ok(ordenes);
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

        [HttpPost("OrdenLocal")]
        public async Task<ActionResult<IEnumerable<OrdenRemisionLocal>>> GetOrdenLocal(OrdenRemisionLocal entity)
        {
            if (entity != null)
            {
                IEnumerable<OrdenRemisionLocal> remisionLocal = await _repository.OrdenLocal(entity);
                if (remisionLocal.Any())
                {
                    return Ok(remisionLocal);
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

        
    }
}
