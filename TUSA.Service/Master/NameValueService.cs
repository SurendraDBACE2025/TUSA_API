using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities.Settings;

namespace TUSA.Service.Master
{
    public interface INameValueService : IBaseService<name_value_pair>
    {
        IEnumerable<name_value_pair> GetList();
        name_value_pair GetByFieldId(int id);
    }
    class NameValueService : BaseService<name_value_pair>, INameValueService
    {
        public NameValueService(IUnitOfWork uow) : base(uow)
        {

        }

        public IEnumerable<name_value_pair> GetList()
        {
            return _UOW.GetRepository<name_value_pair>().Get();

        }
        public name_value_pair GetByFieldId(int id)
        {
            return _UOW.GetRepository<name_value_pair>().Get(x=>x.filed_id==id).FirstOrDefault();
        }
    }
}
