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
    [Authorize]
    public class SupplementController : ControllerBase
    {

        private readonly IRepositoy<Supplement> _repo;
        private readonly ISupplement _supplement;

        public SupplementController(IRepositoy<Supplement> repo, ISupplement sup)
        {
            _repo = repo;
            _supplement = sup;
        }

        [HttpGet("/api/Teste")]
        [Produces("application/json")]
        [AllowAnonymous]
        public async Task<object> CarregaTeste()
        {
            var result = _supplement.Query().OrderByDescending(p => p.id);
            return result;

        }
    }
}
