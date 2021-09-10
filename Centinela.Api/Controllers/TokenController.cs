using AutoMapper;
using Centinela.Core.DTOs;
using Centinela.Core.Interfaces;
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
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public TokenController(IConfiguration configuration, IUsuarioService usuarioService, IMapper mapper)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        
        [HttpPost]
        public async Task<IActionResult> Authentication(LoginDTO credenciales)
        {
            //if it is a valid user
            var userDTO = await IsValidUser(credenciales.Correo, credenciales.Password);
            if (userDTO != null)
            {
                var token = GenerateToken(userDTO);
                return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<UsuarioDTO> IsValidUser(string correo, string password)
        {
            var user = await _usuarioService.Get(correo);          
            var userDTO = _mapper.Map<UsuarioDTO>(user);            
            return userDTO;
        }

        private string GenerateToken(UsuarioDTO usuario)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, $"{usuario.Nombres} {usuario.Apellidos}"),
                new Claim("User", usuario.Correo),
                new Claim("Empresa", usuario.EmpresaId.ToString()),
                new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString()),
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

