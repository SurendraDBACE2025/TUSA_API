using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using TUSA.Data.Paging;
using TUSA.Data.Repository;

namespace TUSA.Data
{
    public interface IRepository<T> : IReadRepository<T>, IDisposable where T : Domain.Entities.BaseEntity
    {
        void Add(T entity);
        void Add(params T[] entities);
        void Add(IEnumerable<T> entities);


        void Delete(T entity);
        void Delete(object id);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);
        
        
        void Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);

        IEnumerable<Domain.Entities.ValueText> LookUpData();
        IEnumerable<Domain.Entities.ValueText> CaseCadeLookUpValues(string name, int Id);

        IEnumerable<T> GetAll(ISpecification<T> specification);

        bool HasRecords(Expression<Func<T, bool>> predicate);
        decimal SumOfDecimal(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> sumBy);
    }
}