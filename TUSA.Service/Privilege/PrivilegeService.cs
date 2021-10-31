using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Core.Result;
using TUSA.Data;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Service.Privilege
{
    public interface IPrivilegeService : IBaseService<privilege_master>
    {
        privilege_master GetByFieldId(int id);

        Result<role_privilege_metrix> CreteRolePrivilege(role_privilege_metrix rolePrivilege);
        Result<user_group_metrix> CreteUserGroupMetrix(user_group_metrix userGroup);

    }
    public class PrivilegeService : BaseService<privilege_master>, IPrivilegeService
    {
        public PrivilegeService(IUnitOfWork uow) : base(uow)
        {

        }
        public privilege_master GetByFieldId(int id)
        {
            return _UOW.GetRepository<privilege_master>().Get(x => x.privilege_id == id).FirstOrDefault();
        }
        public Result<role_privilege_metrix> CreteRolePrivilege(role_privilege_metrix rolePrivilege)
        {
            Result<role_privilege_metrix> result = new();
          _UOW.GetRepository<role_privilege_metrix>().Add(rolePrivilege);

            return result;
        }
        public Result<user_group_metrix> CreteUserGroupMetrix(user_group_metrix userGroup)
        {
            Result<user_group_metrix> result = new();
            _UOW.GetRepository<user_group_metrix>().Add(userGroup);

            return result;
        }
    }
}
