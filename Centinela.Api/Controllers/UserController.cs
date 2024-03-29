﻿using AutoMapper;
using Centinela.Api.Response;
using Centinela.Core.DTOs;
using Centinela.Core.Entities;
using Centinela.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Centinela.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;
        public UserController(IUsuarioService usuarioService, IMapper mapper, IMemoryCache memoryCache)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// Obtener listado de todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(Get))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UsuarioDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            
            var cacheKey = "userlist";
            if (!_memoryCache.TryGetValue(cacheKey, out var response))
            {
                var users = await _usuarioService.Get();
                var userDTO = _mapper.Map<IEnumerable<UsuarioDTO>>(users);
                response = new ApiResponse<IEnumerable<UsuarioDTO>>(userDTO);
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };
                _memoryCache.Set(cacheKey, response, cacheExpiryOptions);
               
                
            }
            return Ok(response);
           
       
        }
        /// <summary>
        /// Obtener informacion de un usuario especifico por correo electronico
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>       
        [HttpGet("{correo}")]       
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(string correo)
        {
            

            var cacheKey = correo;
            if (!_memoryCache.TryGetValue(cacheKey, out var response))
            {
                var user = await _usuarioService.Get(correo);
                var userDTO = _mapper.Map<UsuarioDTO>(user);
                response = new ApiResponse<UsuarioDTO>(userDTO);
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };
                _memoryCache.Set(cacheKey, response, cacheExpiryOptions);


            }
            return Ok(response);         
           
        }
        /// <summary>
        /// Ingresar nuevo usuario
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(UsuarioDTO userDTO)
        {                      
            var user = _mapper.Map<Usuario>(userDTO);
            await _usuarioService.Post(user);
            userDTO = _mapper.Map<UsuarioDTO>(user);
            var response = new ApiResponse<UsuarioDTO>(userDTO);
            _memoryCache.Remove("userlist");
            
            return Ok(response);
        }

        /// <summary>
        ///  Actualizar usuario por correo electronico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, UsuarioDTO userDTO)
        {
            var user = _mapper.Map<Usuario>(userDTO);
            user.UsuarioId = id;           
            var response = new ApiResponse<bool>(await _usuarioService.Put(user));
            _memoryCache.Remove(userDTO.Correo);
            _memoryCache.Remove("userlist");
            return Ok(response);
        
        }
        /// <summary>
        /// Eliminar usuario por correo electronico
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        [HttpDelete("{correo}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(string correo)
        {          
            var response = new ApiResponse<bool>(await _usuarioService.Delete(correo));
            _memoryCache.Remove(correo);
            _memoryCache.Remove("userlist");
            return Ok(response);
        }
    }
}
