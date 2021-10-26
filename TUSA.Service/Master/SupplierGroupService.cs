using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface ISupplierGroupService : IBaseService<group_master>
    {


        List<group_master> GetSuppliersList(int groupTypeId);
    }
   public class SupplierGroupService : BaseService<group_master>, ISupplierGroupService
    {
        public SupplierGroupService(IUnitOfWork uow) : base(uow)
        {

        }
        public List<group_master> GetSuppliersList(int groupTypeId)
        {
            return _UOW.GetRepository<group_master>().Get(x=>x.group_type.group_type_id== groupTypeId).ToList();
        }
    }
}
