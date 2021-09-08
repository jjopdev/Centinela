using Centinela.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Centinela.Api.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
       

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;        
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UsuarioDTO login)
        {
            //if it is a valid user
            var validation = await IsValidUser(login);
            if (validation)
            {
                var token = GenerateToken();
                return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<bool> IsValidUser(UsuarioDTO login)
        {
            return true;
        }

        private string GenerateToken()
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Juan Jose"),
                new Claim("User", "jortiz"),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
           
        }
    }
}

