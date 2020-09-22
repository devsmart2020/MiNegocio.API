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
        public async Task<ActionResult<OrdenRemisionCliente>> RemisionOrden(OrdenRemisionCliente entity)
        {
            if (entity.IdOrden != default)
            {
                OrdenRemisionCliente remisionCliente = await _repository.RemisionCliente(entity);
                if (remisionCliente.IdOrden != default)
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
        
    }
}
