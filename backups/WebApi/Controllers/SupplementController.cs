using Domain.Dto;
using Domain.Interfaces.Repository;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SupplementController : ControllerBase
    {

        private readonly IRepositoy<SupplementDto, Supplement> _repo;

        public SupplementController(IRepositoy<SupplementDto, Supplement> repo)
        {
            _repo = repo; 

        }

        [HttpGet("/api/Teste")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<object> CarregaTeste()
        {
            var result = await _repo.List();
            return result;

        }
    }
}
