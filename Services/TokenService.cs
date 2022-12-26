using ApiSqlAsp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiSqlAsp.Services
{
    public class TokenService
    {
        public string GenerateToken(User user)
        {
            //Instancia Para Gerar o Token
            var tokenHandler = new JwtSecurityTokenHandler();
            // Pegamos a Chave e convertemos para Binário
            var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
            // Criei uma especificação do token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, value:"rodrigues"),
                    //new (ClaimTypes.Role, value:"user"),
                    new Claim(ClaimTypes.Role, value:"admin")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            // Criei o Token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // Retornei o token
            return tokenHandler.WriteToken(token);
        }
    }
}
