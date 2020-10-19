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
    public class PerfilsController : ControllerBase
    {
        private readonly IPerfilRepository _repository;

        public PerfilsController(IPerfilRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("GetPerfil")]
        public async Task<ActionResult<Tbperfil>> GetPerfil(Tbperfil entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                Tbperfil perfil = await _repository.GetPerfil(entity);
                if (perfil != null)
                {
                    return Ok(perfil);
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

        [HttpPost("GetPerfils")]
        public async Task<ActionResult<IEnumerable<Tbperfil>>> GetPerfils()
        {
            IEnumerable<Tbperfil> perfils = await _repository.GetPerfils();
            if (perfils.Any())
            {
                return Ok(perfils);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
