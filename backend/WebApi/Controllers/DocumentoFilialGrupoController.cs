using Domain.Dto;
using Domain.Interfaces.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using Domain.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentoFilialGrupoController : ControllerBase
    {

        private readonly IDocumentoFilialGrupoService _servico;

        public DocumentoFilialGrupoController(IDocumentoFilialGrupoService servico)
        {
            _servico = servico;
        }

        [HttpGet("List")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var result = await _servico.List();
            return Ok(result);

        }

        [HttpGet("Load/{id}")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Load([FromRoute] Guid id)
        {
            var result = await _servico.Load(id);
            return Ok(result);

        }


        [HttpPost("Page")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<IActionResult> Page([FromBody]  InputPage model)
        {
            var result = await _servico.Page(model.page, model.size, model.orderBy,model.orderDirection,model.search);
            return Ok(result);

        }



        [HttpPost("Insert")]
        [AllowAnonymous]
        public IActionResult Post([FromBody] DocumentoFilialGrupoInsertCommand model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var res = _servico.Insert(model);
            return Ok(res);            
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult Put([FromBody] DocumentoFilialGrupoUpdateCommand model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modelo = _servico.Load(model.Id);

            if (modelo == null)
            {
                return NotFound();
            }

            var res = _servico.Update(model);

            return Ok(res);
        }

        [HttpDelete("Delete/{id}")]
        [AllowAnonymous]
        public  IActionResult Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _servico.Delete(id);
            return Ok($"Registro ${id} excluido!");
        }
    }
}



/*possiveis retornos
 * 
 * 
 * //return CreatedAtAction("Get", new { id = model.Id}, model);
 * 
 */