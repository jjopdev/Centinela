using AutoMapper;
using Centinela.Api.Response;
using Centinela.Core.DTOs;
using Centinela.Core.Entities;
using Centinela.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centinela.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UserController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _usuarioService.Get();
            var userDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(users);
            var response = new ApiResponse<IEnumerable<UsuarioDTO>>(userDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _usuarioService.Get(id);
            var userDTO = _mapper.Map<UsuarioDTO>(user);
            var response = new ApiResponse<UsuarioDTO>(userDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDTO userDTO)
        {                      
            var user = _mapper.Map<Usuario>(userDTO);
            await _usuarioService.Post(user);
            userDTO = _mapper.Map<UsuarioDTO>(user);
            var response = new ApiResponse<UsuarioDTO>(userDTO);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioDTO userDTO)
        {
            var user = _mapper.Map<Usuario>(userDTO);
            user.UsuarioId = id;           
            var response = new ApiResponse<bool>(await _usuarioService.Put(user));
            return Ok(response);
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {          
            var response = new ApiResponse<bool>(await _usuarioService.Delete(id));
            return Ok(response);
        }
    }
}
