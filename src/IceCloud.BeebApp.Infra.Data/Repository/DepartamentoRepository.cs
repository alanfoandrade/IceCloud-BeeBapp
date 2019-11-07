using System;
using System.Collections.Generic;
using System.Linq;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Repository
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public IEnumerable<Departamento> GetAtivos()
        {
            return Buscar(d => d.Ativo);
        }

        public Departamento GetByEmpresa(Guid empresaId)
        {
            return Buscar(d => d.EmpresaId == empresaId).FirstOrDefault();
        }
    }
}