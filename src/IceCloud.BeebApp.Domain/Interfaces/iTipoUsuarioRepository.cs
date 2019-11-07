using System.Collections.Generic;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface ITipoUsuarioRepository : IRepositoryRead<TipoUsuario>, IRepositoryWrite<TipoUsuario>
    {
        IEnumerable<TipoUsuario> GetAtivos();
        TipoUsuario GetByTipo(string tipo);
    }
}