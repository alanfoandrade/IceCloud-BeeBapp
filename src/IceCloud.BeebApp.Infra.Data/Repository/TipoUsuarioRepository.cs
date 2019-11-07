using System.Collections.Generic;
using System.Linq;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Repository
{
    public class TipoUsuarioRepository : Repository<TipoUsuario>, ITipoUsuarioRepository
    {
        public IEnumerable<TipoUsuario> GetAtivos()
        {
            return Buscar(t => t.Ativo);
        }

        public TipoUsuario GetByTipo(string tipo)
        {
            return Buscar(t => t.Tipo == tipo).FirstOrDefault();
        }
    }
}