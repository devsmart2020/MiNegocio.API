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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("GetUsers")]
        public async Task<ActionResult<IEnumerable<Tbusuario>>> Get()
        {
            IEnumerable<Tbusuario> usuarios = await _repository.Get();
            if (usuarios.Any())
            {
                return Ok(usuarios);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost("GetById")]
        public async Task<ActionResult<Tbusuario>> GetById(Tbusuario entity)
        {
            if (!string.IsNullOrEmpty(entity.DocId))
            {
                Tbusuario usuario = await _repository.GetById(entity);
                if (usuario != null)
                {
                    return Ok(usuario);
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
        [HttpPost("GetByIdUser")]
        public async Task<ActionResult<Tbusuario>> GetByIdUser(Tbusuario entity)
        {
            if (!string.IsNullOrEmpty(entity.User))
            {
                Tbusuario usuario = await _repository.GetByIdUser(entity);
                if (usuario != null)
                {
                    return Ok(usuario);
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

        [HttpPost]
        public async Task<ActionResult<Tbusuario>> Post(Tbusuario entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                if (await _repository.Exists(entity.DocId))
                {
                    return Conflict(entity);
                }
                else
                {
                    Tbusuario usuario = await _repository.Post(entity);
                    if (usuario != null)
                    {
                        return Ok(usuario);
                    }
                    else
                    {
                        return Conflict();
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Tbusuario>> PutUsuario(Tbusuario entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            else
            {
                Tbusuario usuario = await _repository.Put(entity);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteUsuario(Tbusuario entity)
        {
            if (entity != null)
            {
                if (await _repository.Delete(entity))
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

       [HttpPost("login")]
       public async Task<ActionResult<Tbusuario>>Login(Tbusuario entity)
       {
            if (!string.IsNullOrEmpty(entity.User) || !string.IsNullOrEmpty(entity.Pass))
            {
                Tbusuario model = await _repository.Login(entity);                
                if (model != null)
                {
                    if (ModelState.IsValid && model.Estado.Equals(1))
                    {
                        return Ok(model);
                    }
                    else
                    {
                        return Conflict(null);
                    }
                }
                else
                {
                    return NotFound(null);
                }
            }
            else
            {
                return BadRequest(null);
            }
       }

        [HttpGet("Tecnicos")]
        public async Task<ActionResult<IEnumerable<Tbusuario>>> GetTecnicos()
        {
            IEnumerable<Tbusuario> tecnicos = await _repository.GetTecnicos();
            if (tecnicos.Count() > 0)
            {
                return Ok(tecnicos);
            }
            else
            {
                return NoContent();
            }
        }
    }
}