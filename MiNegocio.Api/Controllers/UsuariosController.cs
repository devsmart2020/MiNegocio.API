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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _repository.Get();
            return Ok(usuarios);
        }

        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<Tbusuario>> GetById(string idUsuario)
        {
            var usuario = await _repository.GetById(idUsuario);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tbusuario>> Post(Tbusuario entity)
        {
            if (entity.DocId != null)
            {
                if (await _repository.Exists(entity.DocId))
                {
                    return Conflict(entity);
                }
                else
                {
                    Tbusuario usuario = await _repository.Post(entity);
                    return CreatedAtAction("GetUsuarios", new { id = usuario.DocId }, usuario);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{idUsuario}")]
        public async Task<ActionResult<Tbusuario>> PutUsuario(string idUsuario, Tbusuario entity)
        {
            if (idUsuario != entity.DocId)
            {
                return BadRequest();
            }
            else
            {
                Tbusuario usuario = await _repository.Put(idUsuario, entity);
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

        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteUsuario(string idUsuario)
        {
            if (!string.IsNullOrEmpty(idUsuario))
            {
                if (await _repository.Delete(idUsuario))
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
    }
}