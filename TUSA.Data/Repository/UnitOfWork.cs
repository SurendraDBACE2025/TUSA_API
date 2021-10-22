using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TUSA.Data
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork
        where TContext : DbContext, IDisposable
    {
        private Dictionary<Type, object> _repositories;
        private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction dbContextTransaction;

        public UnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : Domain.Entities.BaseEntity
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : Domain.Entities.BaseEntity
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryAsync<TEntity>(Context);
            return (IRepositoryAsync<TEntity>)_repositories[type];
        }

        public IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : Domain.Entities.BaseEntity
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryReadOnly<TEntity>(Context);
            return (IRepositoryReadOnly<TEntity>)_repositories[type];
        }

        public virtual TContext Context { get; }

        public virtual int SaveChanges()
        { 
            return Context.SaveChanges();
        } 

        public void Dispose()
        {
            Context?.Dispose();
        }

        public void BeginTrans()
        {
            dbContextTransaction = Context.Database.BeginTransaction();
        }

        public void CommitTrans()
        {
            try
            {
                Context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception)
            {
                dbContextTransaction.Rollback();
                throw;
            }
        }
        public void Rollback()
        {
            try
            { 
                dbContextTransaction.Rollback();
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}