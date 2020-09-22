using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiNegocio.Core.Entities;
using MiNegocio.Core.Interfaces;

namespace MiNegocio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioOrdenesController : ControllerBase
    {
        private readonly IUsuarioOrden _repository;

        public UsuarioOrdenesController(IUsuarioOrden repository)
        {
            _repository = repository;
        }

        [HttpPost("Crear")]
        public async Task<ActionResult> Post(Tbusuarioorden entity)
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
