using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegociosController : ControllerBase
    {
        private readonly INegocioRepository _repository;

        public NegociosController(INegocioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Tbnegocio>> GetById()
        {
            Tbnegocio tbnegocio = await _repository.GetById();
            if (tbnegocio != null)
            {
                return Ok(tbnegocio);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
