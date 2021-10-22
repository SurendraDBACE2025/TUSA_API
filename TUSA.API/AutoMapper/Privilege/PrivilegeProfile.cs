using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities.Privileges;
using TUSA.Domain.Models.Privileges;

namespace TUSA.API.AutoMapper.Privilege
{
    public class PrivilegeProfile:Profile
    {
        public PrivilegeProfile()
        {
            CreateMap<PrivilegeModel, privilege_master>();
            CreateMap<role_master, PrivilegeModel>();
            CreateMap<RolePrivilegeModel, role_privilege_metrix>();
            CreateMap<role_privilege_metrix, RolePrivilegeModel>();
            CreateMap<UserGroupModel, user_group_metrix>();
            CreateMap<user_group_metrix, UserGroupModel>();
        }
    }
}
