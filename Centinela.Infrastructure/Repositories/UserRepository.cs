using Centinela.Core.Entities;
using Centinela.Core.Interfaces;
using Centinela.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centinela.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SALRContext _context;

        public UserRepository(SALRContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> Get()
        {
            var users = await _context.Usuarios.ToListAsync();
            return users;
        }

        public async Task<Usuario> Get(int id)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == id);
            return user;
        }
        public async Task Post(Usuario usuario)
        {
            //tabla usuario
            usuario.AddDate = DateTime.Now;
            usuario.Activo = true;
            //tabla password
            usuario.PasswordUsuario.AddUserId = 14;           
            usuario.PasswordUsuario.AddDate = DateTime.Now;
            usuario.PasswordUsuario.Activo = true;
            _context.Usuarios.Add(usuario);
            await  _context.SaveChangesAsync();
        }

        public async Task<bool> Put(Usuario usuario)
        {
            var currentUser = await Get(usuario.UsuarioId);
            //tabla usuario
            currentUser.ChgDate = DateTime.Now;            
            //tabla password
            currentUser.PasswordUsuario.ChgUserId = 14;
            currentUser.PasswordUsuario.ChgDate = DateTime.Now;
            int isDone = await _context.SaveChangesAsync();
            return isDone > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var currentUser = await Get(id);
            _context.Usuarios.Remove(currentUser);
            int isDone = await _context.SaveChangesAsync();
            return isDone > 0;
        }

       
    }
}
