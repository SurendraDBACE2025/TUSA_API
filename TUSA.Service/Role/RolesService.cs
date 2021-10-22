using System;
using System.Collections.Generic;
using System.Linq;
using TUSA.Core.Result;
using TUSA.Data;
using TUSA.Data.Paging;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Service.Settings
{
    public partial interface IRolesService : IBaseService<role_master>
    {
        bool Validate(string name);
        //IEnumerable<RolePrivilege> RoleMenu(int RoleId);
        //IEnumerable<Page> Pages();
    }

    public class RolesService : BaseService<role_master>, IRolesService
    {
        public RolesService(IUnitOfWork uow) : base(uow)
        {

        }

        public override role_master Get(int id)
        {
            role_master entity = _UOW.GetRepository<role_master>().Single();
            //x => x.ID == Id);
            //entity.RolePrivileges = _UOW.GetRepository<RolePrivilege>().Get(x => x.RoleId == Id,
            //    orderBy: o => o.OrderBy(d => d.Page.Group.DisplayOrder).ThenBy(dd => dd.Page.DisplayOrder),
            //    include: i => i.Include(x => x.Page).ThenInclude(x => x.Group)).ToList();
            return entity;
        }
        public bool Validate(string name)
        {
            //role_master entity = _UOW.GetRepository<role_master>().Single(x => x.Name == name);
            //if (entity == null)
            //{
            //    return false;
            //}
            return true;
        }

        public override void Update(role_master item)
        {
            base.Update(item);
        }

        //public IEnumerable<RolePrivilege> RoleMenu(int RoleId)
        //{
        //    IEnumerable<RolePrivilege> privilege = _UOW.GetRepository<RolePrivilege>().Get(
        //        predicate: x => x.RoleId == RoleId && x.Privilege > 0,
        //        include: x => x.Include(i => i.Page).ThenInclude(o => o.Group),
        //        orderBy: o => o.OrderBy(d => d.Page.Group.DisplayOrder).ThenBy(dd => dd.Page.DisplayOrder));

        //    return privilege;
        //}



        //public IEnumerable<Page> Pages()
        //{
        //    return _UOW.GetRepository<Page>().Get(
        //        include: x => x.Include(i => i.Group),
        //        orderBy: o => o.OrderBy(d => d.Group.DisplayOrder).ThenBy(d => d.DisplayOrder));
        //}

        public override void OnBeforeUpdate_CustomValidator(role_master item, Result<role_master> executionResult)
        {
            base.OnBeforeUpdate_CustomValidator(item, executionResult);
            if (_UOW.GetRepository<role_master>().HasRecords(x => x.role_id == item.role_id))
            {
                executionResult.AddMessageItem(new MessageItem(Resource.Role_NotEditable));
            }
        }
    }

}
