﻿using Centinela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centinela.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> Get(int id);
    }
}