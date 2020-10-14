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
    public class EstadoOrdenesController : ControllerBase
    {
        private readonly IEstadoOrden _repository;

        public EstadoOrdenesController(IEstadoOrden repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbestadoorden>>> GetEstados()
        {
            IEnumerable<Tbestadoorden> estados = await _repository.GetEstados();
            if (estados.Any())
            {
                return Ok(estados);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
