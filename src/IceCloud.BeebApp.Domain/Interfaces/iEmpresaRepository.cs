using IceCloud.BeebApp.Domain.Models;
using System.Collections.Generic;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface IEmpresaRepository : IRepositoryRead<Empresa>, IRepositoryWrite<Empresa>
    {
        IEnumerable<Empresa> GetAtivos();
        Empresa GetByCnpj(string cnpj);
        Empresa GetByTel(string tel);
    }
}