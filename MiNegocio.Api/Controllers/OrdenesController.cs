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
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenRepository<Tborden> _repository;

        public OrdenesController(IOrdenRepository<Tborden> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Tborden entity)
        {
            if (!string.IsNullOrEmpty(entity.IdCliente))
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
