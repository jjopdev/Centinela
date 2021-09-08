using Centinela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centinela.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> Get();
        Task<Usuario> Get(string id);
        Task Post(Usuario usuario);
        Task<bool> Put(Usuario usuario);
        Task<bool> Delete(string id);
    }
}