using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosFijosController : ControllerBase
    {
        private readonly IInventarioFijoRepository _repository;

        public InventariosFijosController(IInventarioFijoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult<IEnumerable<Tbinventariofijo>>> GetAll(Tbinventariofijo entity)
        {
            IEnumerable<Tbinventariofijo> tbinventariofijos = await _repository.GetAll(entity);
            if (tbinventariofijos.Count() > 0)
            {
                return Ok(tbinventariofijos);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Tbinventariofijo entity)
        {
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
    }
}
