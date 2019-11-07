using System;
using System.Collections.Generic;
using System.Linq;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public IEnumerable<Empresa> GetAtivos()
        {
            return Buscar(e => e.Ativo);
        }

        public Empresa GetByCnpj(string cnpj)
        {
            return Buscar(e => e.CNPJ == cnpj).FirstOrDefault();
        }

        public Empresa GetByTel(string tel)
        {
            return Buscar(e => e.TEL == tel).FirstOrDefault();
        }

        public override Empresa GetById(Guid id)
        {
            return Db.Empresas.AsNoTracking().Include("Enderecos").FirstOrDefault(e => e.Id == id);
        }

        public override void Remover(Guid id)
        {
            var Empresa = GetById(id);
            Empresa.SetExcluido();

            Atualizar(Empresa);
        }
    }
}