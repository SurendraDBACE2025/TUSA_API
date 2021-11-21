using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface ICurrencyMasterService : IBaseService<currency_master>
    {
        List<currency_master> GetCurrencyList();
        List<currency_master> GetCurrencyListByCode(string currencyCode);
        List<currency_master> GetCurrencyListByCountryCode(string countryCode);
    }
   public class CurrencyMasterService:BaseService<currency_master>, ICurrencyMasterService
    {
        public CurrencyMasterService(IUnitOfWork uow) : base(uow)
        {
           
        }
        public List<currency_master> GetCurrencyList()
        {
            return _UOW.GetRepository<currency_master>().Get(include:x=>x.Include(x=>x.country)).ToList();
        }

        public List<currency_master> GetCurrencyListByCode(string currencyCode)
        {
            return _UOW.GetRepository<currency_master>().Get(x => x.currency_code == currencyCode,
                include: x => x.Include(x => x.country)).ToList();
        }

        public List<currency_master> GetCurrencyListByCountryCode(string countryCode)
        {
            return _UOW.GetRepository<currency_master>().Get(x => x.country.country_code == countryCode,
                include: x => x.Include(x => x.country)).ToList();
        }
    }
}
