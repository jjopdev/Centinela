using Centinela.Core.Entities;
using Centinela.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Centinela.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IUserRepository _userRepository;

        public UsuarioService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }        

        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _userRepository.Get();
        }

        public async Task<Usuario> Get(string id)
        {
          return await _userRepository.Get(id);
        }

        public async Task Post(Usuario usuario)
        {
            var user = await _userRepository.Get(usuario.Correo);
            if (user != null)
            {
                throw new Exception("El usuario ya existe en el sistema...");
            }
            await _userRepository.Post(usuario);
        }

        public async Task<bool> Put(Usuario usuario)
        {
           return await _userRepository.Put(usuario);
        }
        public async Task<bool> Delete(string id)
        {
            return await _userRepository.Delete(id);
        }
    }
}
