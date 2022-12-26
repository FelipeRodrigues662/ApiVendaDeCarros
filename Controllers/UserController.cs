using ApiSqlAsp.DataContext;
using ApiSqlAsp.Models;
using ApiSqlAsp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("v1")]
    public class UserController : ControllerBase
    {
        private User user;

        [HttpPost("accounts")]
        public async Task<IActionResult> Post(
            [FromBody] User model,
            [FromServices] ApiDataContext context)
        {
            

            await context.Users.AddAsync(model);
            await context.SaveChangesAsync();

            return Ok(model);
        }

        //[AllowAnonymous] // Libera a autorização
        [HttpPost("accounts/login")]
        public IActionResult Login([FromServices] TokenService tokenService)
        {
            var token = tokenService.GenerateToken(user);

            return Ok(token);
        }

      
    }
}
