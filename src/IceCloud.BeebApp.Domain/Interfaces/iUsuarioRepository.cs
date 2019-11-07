using System.Collections.Generic;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryRead<Usuario>, IRepositoryWrite<Usuario>
    {
        IEnumerable<Usuario> GetAtivos();
        Usuario GetByCpf(string cpf);
        Usuario GetByEmail(string email);
    }
}