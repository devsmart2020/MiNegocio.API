using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;
using MiNegocio.Core.ReportsEntities;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentaRepository _repository;

        public VentasController(IVentaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await _repository.Get();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tbventa>> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tbventa>> Post(Tbventa entity)
        {
            if (entity != null)
            {              
                Tbventa model = await _repository.Post(entity);
                if (model != null)
                {
                    return CreatedAtAction("Get", new { id = entity.IdVenta }, entity);

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

        [HttpPut("{id}")]
        public async Task<ActionResult<Tbventa>> Put(int id, Tbventa entity)
        {
            if (id != entity.IdVenta)
            {
                return BadRequest();
            }
            else
            {
                Tbventa model = await _repository.Put(id, entity);
                if (model != null)
                {
                    return Ok(model);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                if (await _repository.Delete(id))
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

        [HttpPost("Reportes/ventaxfecha")]
        public async Task<ActionResult<IEnumerable<VentasxFecha>>> VentaxFecha(VentasxFecha fechaModel)
        {
            DateTime fechaIni = fechaModel.FechaIni;
            DateTime fechaFin = fechaModel.FechaFin;
            return Ok(await _repository.VentasxFecha(fechaIni, fechaFin));
        }

        [HttpPost("Reportes/detalleventaxfecha")]
        public async Task<ActionResult<IEnumerable<VentasDetalleVentaxFecha>>> DetalleVentaxFecha(VentasDetalleVentaxFecha fechaModel)
        {
            DateTime fechaIni = fechaModel.FechaIni;
            DateTime fechaFin = fechaModel.FechaFin;
            return Ok(await _repository.DetalleVentaxFecha(fechaIni, fechaFin));
        }

        [HttpPost("Reportes/liquidacionxfecha")]
        public async Task<ActionResult<IEnumerable<VentasLiquidacionxFecha>>> LiquidacionVentaxFecha(VentasLiquidacionxFecha fechaModel)
        {
            DateTime fechaIni = fechaModel.FechaIni;
            DateTime fechaFin = fechaModel.FechaFin;
            IEnumerable<VentasLiquidacionxFecha> query = await _repository.LiquidacionVentaxFecha(fechaIni, fechaFin);
            if (query.Any())
            {
                return Ok(query);
            }
            else
            {
                return NotFound(null);
            }
        }

        [HttpPost("Reportes/remisionventa")]
        public async Task<ActionResult<IEnumerable<VentasRemisionVenta>>> RemisionVentas(VentasRemisionVenta entity)
        {
            if (entity != null)
            {
                IEnumerable<VentasRemisionVenta> remisionVenta = await _repository.RemisionVenta(entity);
                if (remisionVenta.Any())
                {
                    return Ok(remisionVenta);
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

        [HttpPost("Reportes/remisiondetalle")]
        public async Task<ActionResult<IEnumerable<VentasDetalleRemisionVenta>>> RemisionVenta(VentasDetalleRemisionVenta entity)
        {
            if (entity != null)
            {
                IEnumerable<VentasDetalleRemisionVenta> ventasDetalles = await _repository.DetalleRemision(entity);
                if (ventasDetalles.Any())
                {
                    return Ok(ventasDetalles);
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

        [HttpPost("VentaPorCliente")]
        public async Task<ActionResult<IEnumerable<VentasPorCliente>>> VentaPorCliente(VentasPorCliente entity)
        {
            if (entity != null)
            {
                return Ok(await _repository.VentaPorCliente(entity));
            }
            else
            {
                return BadRequest(null);
            }
        }
    }
}