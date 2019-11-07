using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllPaginado(int s, int t);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
    }
}