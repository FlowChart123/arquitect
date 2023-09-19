using Entities.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        private readonly IJWTManager JWTManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TokenController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IJWTManager jWTManager)
        {
            this.JWTManager = jWTManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel Input)
        {
            if (string.IsNullOrWhiteSpace(Input.Email) || string.IsNullOrWhiteSpace(Input.Password))
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);            
            if (result.Succeeded)
            {

                var token = this.JWTManager
                    .AddClaim("UsuarioAPINumero", "1")
                    .AddClaim("EmailUsuario", Input.Email)
                    .Builder();

                //var token = this.JWTManager.GenerateToken();
                //return Ok(token);

                return Ok(token.value);

            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpGet("/api/Testar")]
        [Authorize]
        public IActionResult Teste()
        {

            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.Claims.Where(p => p.Type == "Name").FirstOrDefault().Value;

            var teste = User.Identity;
            return Ok(teste);
        }


    }
}
