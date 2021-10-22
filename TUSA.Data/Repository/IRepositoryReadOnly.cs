using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using TUSA.Data.Paging;

namespace TUSA.Data
{
    public interface IRepositoryReadOnly<T> : IReadRepository<T> where T : Domain.Entities.BaseEntity
    {
       
    }
}