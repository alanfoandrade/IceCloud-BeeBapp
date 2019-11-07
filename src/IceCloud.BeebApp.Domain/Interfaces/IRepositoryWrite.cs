using System;
using IceCloud.BeebApp.Domain.Models;

namespace IceCloud.BeebApp.Domain.Interfaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        int SaveChanges();
    }
}