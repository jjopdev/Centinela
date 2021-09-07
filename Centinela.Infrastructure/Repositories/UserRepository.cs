﻿using Centinela.Core.Entities;
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
            //usuario.Password.PasswordUsuario = usuario.PasswordUsuario;
            //usuario.Password.AddDate = DateTime.Now;           
          
            usuario.AddUserId = 14;
            usuario.AddDate = DateTime.Now;          
         
            _context.Usuarios.Add(usuario);
           await  _context.SaveChangesAsync();
        }
    }
}
