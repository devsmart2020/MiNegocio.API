using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaAnuladasController : ControllerBase
    {
        private readonly IVentaAnulada _repository;
        private readonly IVentaProductoRepository _ventaProductoRepository;

        public VentaAnuladasController(IVentaAnulada repository)
        {
            _repository = repository;         
        }

        [HttpPost]
        public async Task<ActionResult<int>> SerialEquiposaRestaurar(Tbventaanulada entity)
        {
            if (entity.IdVenta != default)
            {
                return Ok(await _ventaProductoRepository.CantidadEquiposEnDetalle(entity));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("AnulaVenta")]
        public async Task<ActionResult<bool>> AnularVenta(Tbventaanulada entity)
        {
            if (entity.IdVenta != default)
            {
                bool query = await _repository.Post(entity);
                if (query)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

        }



    }
}
