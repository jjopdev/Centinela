using AutoMapper;
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
            return Ok(userDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userRepository.Get(id);
            var userDTO = _mapper.Map<UsuarioDTO>(user);
            return Ok(userDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDTO userDTO)
        {
            var user = _mapper.Map<Usuario>(userDTO);
            await _userRepository.Post(user);
            return Ok(user);
        }
    }
}
