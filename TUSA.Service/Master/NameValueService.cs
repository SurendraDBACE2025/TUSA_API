using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface INameValuePairService : IBaseService<name_value_pair>
    {
        IEnumerable<name_value_pair> GetList();
        name_value_pair GetByFieldId(int fieldid);
    }
    class NameValuePairService : BaseService<name_value_pair>, INameValuePairService
    {
        public NameValuePairService(IUnitOfWork uow) : base(uow)
        {

        }

        public IEnumerable<name_value_pair> GetList()
        {
            return _UOW.GetRepository<name_value_pair>().Get();

        }
        public name_value_pair GetByFieldId(int fieldid)
        {
            return _UOW.GetRepository<name_value_pair>().Get(x=>x.filed_master.field_id== fieldid).FirstOrDefault();
        }
    }
}
