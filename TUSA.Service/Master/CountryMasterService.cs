using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface ICountryMasterService : IBaseService<country_master>
    {


        List<country_master> GetCountryList();
        List<country_master> GetCountryList(string countryCode);
    }
    public class CountryMasterService: BaseService<country_master>, ICountryMasterService
    {
        public CountryMasterService(IUnitOfWork uow) : base(uow)
        {

        }
        public List<country_master> GetCountryList()
        {
            return _UOW.GetRepository<country_master>().Get().ToList();
        }

        public List<country_master> GetCountryList(string countryCode)
        {
            return _UOW.GetRepository<country_master>().Get(x=>x.country_code==countryCode).ToList();
        }
    }
}
