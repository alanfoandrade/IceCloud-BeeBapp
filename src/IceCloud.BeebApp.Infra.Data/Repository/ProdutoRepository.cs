using System;
using System.Collections.Generic;
using System.Linq;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> GetAtivos()
        {
            return Buscar(p => p.Ativo);
        }

        public Produto GetByNome(string nome)
        {
            return Buscar(p => p.Nome == nome).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var Produto = GetById(id);
            Produto.SetExcluido();

            Atualizar(Produto);
        }
    }
}