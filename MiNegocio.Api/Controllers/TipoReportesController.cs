using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoReportesController : ControllerBase
    {
        private readonly ITipoReporteRepository _repository;

        public TipoReportesController(ITipoReporteRepository repository)
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
        public async Task<ActionResult<Tbtiporeporte>> Post(Tbtiporeporte entity)
        {
            if (entity != null)
            {
                if (await _repository.Exists(entity.IdTipoReporte))
                {
                    return Conflict(null);
                }
                else
                {
                    Tbtiporeporte model = await _repository.Post(entity);
                    if (model != null)
                    {
                        return CreatedAtAction("Get", new { id = entity.IdTipoReporte }, entity);

                    }
                    else
                    {
                        return Conflict(null);
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
