using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using IceCloud.BeebApp.Domain.Interfaces;
using IceCloud.BeebApp.Domain.Models;
using IceCloud.BeebApp.Infra.Data.Context;

namespace IceCloud.BeebApp.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected BeebAppContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            Db = new BeebAppContext();
            DbSet = Db.Set<TEntity>();
        }

        // WRITE
        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);

            SaveChanges();
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            SaveChanges();
        }

        public virtual void Remover(Guid id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);

            SaveChanges();
        }

        // READ
        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAllPaginado(int s, int t)
        {
            return DbSet.Take(t).Skip(s);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}