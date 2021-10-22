
using TUSA.Core.Result;
using TUSA.Data;
using TUSA.Data.Paging;
using TUSA.Data.Repository;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TUSA.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IEnumerable<T> GetList(string orderBy);
        IPaginate<T> GetAll();
        IPaginate<T> GetAll(BaseSearch baseSearch);
        Task<IPaginate<T>> GetAllAsync();
        IEnumerable<Domain.Entities.ValueText> GetLookUpValues();
        IEnumerable<Domain.Entities.ValueText> GetCasCadeLookUpValues(string name, int Id);
        IEnumerable<T> GetAll(ISpecification<T> specification);
        IPaginate<T> GetRefAll(int id);
        T Get(int id);
        T Get(string name);
        T Get(ISpecification<T> specification);
        T Add(T item);
        T AddOnly(T item);
        Result<T> AddNew(T item);
        void OnBeforeAdd(T item, Result<T> executionResult);
        void OnBeforeAdd_CustomValidator(T item, Result<T> executionResult);
        void OnAfterAdd(T item, Result<T> executionResult);
        void Update(T item);
        Result<T> UpdateNew(T item);
        void OnBeforeUpdate(T item, Result<T> executionResult); 
        void OnBeforeUpdate_CustomValidator(T item, Result<T> executionResult);
         void OnAfterUpdate(T item, Result<T> executionResult); 
        IEnumerable<T> Search(string name);
        IEnumerable<T> Search(string code, string name);  
        DateTime TimeStamp();
    }

    public class BaseService<T> : BaseSpecification<T>, IBaseService<T> where T : BaseEntity
    {
        public IUnitOfWork _UOW;
        public ISequenceNoService _sequenceNoService;
        public BaseService(IUnitOfWork uow)
        {
            _UOW = uow;
        }
        public BaseService(IUnitOfWork uow, ISequenceNoService sequenceNoService)
        {
            _UOW = uow ?? throw new NullReferenceException();
            _sequenceNoService = sequenceNoService ?? throw new NullReferenceException();
        }
        public DateTime TimeStamp() => DateTime.Now;
        public virtual IEnumerable<T> GetList(string OrderBy)
        {
            return _UOW.GetRepository<T>().GetAllList(OrderBy);
        }
        public virtual IPaginate<T> GetRefAll(int id)
        {
            return _UOW.GetRepository<T>().GetRefList(id);
        }

        public virtual IPaginate<T> GetAll()
        {
            return _UOW.GetRepository<T>().GetList();
        }

        public virtual IPaginate<T> GetAll(BaseSearch baseSearch)
        {
            return _UOW.GetRepository<T>().GetList(index: baseSearch.Page, size: baseSearch.Size);
        }

        public async virtual Task<IPaginate<T>> GetAllAsync()
        {
            return await _UOW.GetRepositoryAsync<T>().GetListAsync();
        }

        public virtual T Add(T item)
        {
            _UOW.GetRepository<T>().Add(item);
            _UOW.SaveChanges();
            return item;
        }
        public virtual T AddOnly(T item)
        {
            _UOW.GetRepository<T>().Add(item); 
            return item;
        }
        public virtual Result<T> AddNew(T item)
        {
            Result<T> executionResult = new Result<T>(false);
            OnBeforeAdd(item, executionResult);
            if (!executionResult.HasError)
            {
                try
                {
                    _UOW.GetRepository<T>().Add(item);
                    _UOW.SaveChanges();
                    executionResult.IsSuccess = true;
                    executionResult.ReturnValue = item;
                }
                catch (Exception ex)
                {
                    executionResult.AddMessageItem(new MessageItem(ex));
                }
            }
            OnAfterAdd(item, executionResult);
            return executionResult;
        }

        public virtual void OnBeforeAdd(T item, Result<T> executionResult)
        {
            OnBeforeAdd_CustomValidator(item, executionResult);
        }

        public virtual void OnBeforeAdd_CustomValidator(T item, Result<T> executionResult)
        {

        }

        public virtual void OnAfterAdd(T item, Result<T> executionResult)
        {

        }

        public virtual void Update(T item)
        { 
            _UOW.GetRepository<T>().Update(item);
            _UOW.SaveChanges();
        }

        public virtual Result<T> UpdateNew(T item)
        {  
            Result<T> executionResult = new Result<T>(false);

            OnBeforeUpdate(item, executionResult);
            if (!executionResult.HasError)
            {
                try
                { 
                    _UOW.GetRepository<T>().Update(item);
                    _UOW.SaveChanges();
                    executionResult.IsSuccess = true;
                    executionResult.ReturnValue = item;
                }
                catch (Exception ex)
                {
                    executionResult.AddMessageItem(new MessageItem(ex));
                }
            }

            OnAfterUpdate(item, executionResult);
            return executionResult;
        }
        public virtual void OnBeforeUpdate(T item, Result<T> executionResult)
        {
            OnBeforeUpdate_CustomValidator(item, executionResult);
        }

        public virtual void OnBeforeUpdate_CustomValidator(T item, Result<T> executionResult)
        {

        }
        public virtual void OnAfterUpdate(T item, Result<T> executionResult)
        {

        }

        public virtual T Get(int id)
        {
            return _UOW.GetRepository<T>().Single();
        }

        public virtual T Get(string name)
        {
            return _UOW.GetRepository<T>().Single();
        }
        public virtual T Get(ISpecification<T> specification)
        {
            return _UOW.GetRepository<T>().GetAll(specification).FirstOrDefault();
        }
        internal Tuple<int, string> GetNextSequenceNo(string entity, string attribute)
        {
            SequenceNo sequenceNo = _UOW.GetRepository<SequenceNo>().Single(x => x.EntityName == entity && x.Attribute == attribute);

            int seq = sequenceNo.NextNo++;
            _UOW.GetRepository<SequenceNo>().Update(sequenceNo);
            return new Tuple<int, string>(seq, $"{(string.IsNullOrEmpty(sequenceNo.Prefix) ? "A" : sequenceNo.Prefix)}{seq.ToString().PadLeft(5,'0')}");
        }
        public virtual IEnumerable<T> GetAll(ISpecification<T> specification)
        {
            return _UOW.GetRepository<T>().GetAll(specification);
        }
        public virtual IEnumerable<Domain.Entities.ValueText> GetLookUpValues()
        {
            return _UOW.GetRepository<T>().LookUpData();
        }
        public IEnumerable<Domain.Entities.ValueText> GetCasCadeLookUpValues(string name, int Id)
        {
            return _UOW.GetRepository<T>().CaseCadeLookUpValues(name, Id);
        }

        public virtual IEnumerable<T> Search(string code, string name)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Search(string name)
        {
            throw new NotImplementedException();
        }
         
    }
}
