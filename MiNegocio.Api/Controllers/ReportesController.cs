using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteRepository _repository;

        public ReportesController(IReporteRepository repository)
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
        public async Task<ActionResult<Tbreportes>> Post(Tbreportes entity)
        {
            if (entity != null)
            {
                if (await _repository.Exists(entity.IdReporte))
                {
                    return Conflict(null);
                }
                else
                {
                    Tbreportes model = await _repository.Post(entity);
                    if (model != null)
                    {
                        return CreatedAtAction("Get", new { id = entity.IdReporte }, entity);

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

        [HttpGet("{idTipoReporte}")]
        public async Task<ActionResult<List<Tbreportes>>> CmbReporte(int idTipoReporte)
        {
            if (idTipoReporte > 0)
            {
                List<Tbreportes> tbreportes = await _repository.GetByIdTr(idTipoReporte);
                if (tbreportes.Count > 0)
                {
                    return Ok(tbreportes);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();                   
            }
        }
    }
}
