using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TUSA.Data.Repository;
using Microsoft.EntityFrameworkCore;
using TUSA.Data.Paging;

namespace TUSA.Data
{
    public class Repository<T> : BaseRepository<T>, IRepository<T> where T : Domain.Entities.BaseEntity
    {
        public Repository(DbContext context) : base(context)
        {
        }

        public virtual void Add(T entity)
        {
          //  entity.ID = Guid.NewGuid(); 
            _dbSet.Add(entity);
        }

        public void Add(params T[] entities)
        {
            _dbSet.AddRange(entities);
        }


        public void Add(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }


        public void Delete(T entity)
        {
            var existing = _dbSet.Find(entity);
            if (existing != null) _dbSet.Remove(existing);
        }


        public void Delete(object id)
        {
            var typeInfo = typeof(T).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<T>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null) Delete(entity);
            }
        }

        public void Delete(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }


        [Obsolete("Method is replaced by GetList")]
        public IEnumerable<T> Get()
        {
            return _dbSet.AsEnumerable();
        }

        [Obsolete("Method is replaced by GetList")] 
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }

        public virtual void Update(T entity)
        {            
            _dbSet.Update(entity);
            //_dbContext.Entry(entity).Property(x => x.AddedDate).IsModified = false;
        }

        public void Update(params T[] entities)
        {
            _dbSet.UpdateRange(entities);
        }


        public void Update(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IEnumerable<Domain.Entities.ValueText> LookUpData()
        {
            if (typeof(T).GetProperty("name", bindingAttr: BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null)
            {
                return _dbContext.Set<Domain.Entities.ValueText>().FromSqlRaw("select id Value, name Text from " + typeof(T).Name + " order by 2").AsEnumerable();
            }
            return new List<Domain.Entities.ValueText>();
        }

        public IEnumerable<Domain.Entities.ValueText> CaseCadeLookUpValues(string name, int Id)
        {
            if (typeof(T).GetProperty("name", bindingAttr: BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null
                && typeof(T).GetProperty(name, bindingAttr: BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null)
            {
                string str = string.Format("select id Value, name Text from {0} where {1}='{2}' order by 2", typeof(T).Name, name, Id);
                return _dbContext.Set<Domain.Entities.ValueText>().FromSqlRaw(str).AsEnumerable();
            }
            return new List<Domain.Entities.ValueText>();
        }

        public IEnumerable<T> GetAll(ISpecification<T> specification = null)
        {
            return ApplySpecification(specification);
        }

        private IEnumerable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public bool HasRecords(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet;
            query = query.AsNoTracking(); 

            if (predicate != null) query = query.Where(predicate);
             
            return query.Count() > 0 ? true : false;
        }
        public decimal SumOfDecimal(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> sumBy)
        {

            IQueryable<T> query = _dbSet;
            query = query.AsNoTracking();

            if (predicate != null) query = query.Where(predicate);

            return query.Sum(sumBy);
        }

        public void Single(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}