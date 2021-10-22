using System;
using Microsoft.EntityFrameworkCore;

namespace TUSA.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : Domain.Entities.BaseEntity;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : Domain.Entities.BaseEntity;
        IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : Domain.Entities.BaseEntity;

        int SaveChanges();
        void BeginTrans();
        void CommitTrans();
        void Rollback();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext Context { get; }
    }
}