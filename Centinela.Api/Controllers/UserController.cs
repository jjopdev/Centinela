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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.Get();
            var userDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(users);
            var response = new ApiResponse<IEnumerable<UsuarioDTO>>(userDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userRepository.Get(id);
            var userDTO = _mapper.Map<UsuarioDTO>(user);
            var response = new ApiResponse<UsuarioDTO>(userDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDTO userDTO)
        {                      
            var user = _mapper.Map<Usuario>(userDTO);
            await _userRepository.Post(user);
            userDTO = _mapper.Map<UsuarioDTO>(user);
            var response = new ApiResponse<UsuarioDTO>(userDTO);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UsuarioDTO userDTO)
        {
            var user = _mapper.Map<Usuario>(userDTO);
            user.UsuarioId = id;           
            var response = new ApiResponse<bool>(await _userRepository.Put(user));
            return Ok(response);
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {          
            var response = new ApiResponse<bool>(await _userRepository.Delete(id));
            return Ok(response);
        }
    }
}
