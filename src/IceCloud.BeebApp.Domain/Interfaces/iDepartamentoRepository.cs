using System;
using System.Collections.Generic;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface IDepartamentoRepository : IRepositoryRead<Departamento>, IRepositoryWrite<Departamento>
    {
        IEnumerable<Departamento> GetAtivos();
        Departamento GetByEmpresa(Guid empresaId);
    }
}