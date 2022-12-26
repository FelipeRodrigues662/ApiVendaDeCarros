using ApiSqlAsp.Models;
using ApiSqlAsp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private readonly User user;

        [HttpPost("login")]
        public IActionResult Login([FromServices] TokenService tokenService)
        {
            var token = tokenService.GenerateToken(user);

            return Ok(token);
        }
    }
}
