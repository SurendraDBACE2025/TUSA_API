using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities.Privileges;
using TUSA.Domain.Models.Settings;

namespace TUSA.API.AutoMapper.Role
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleModel, role_master>();
            CreateMap<role_master, RoleModel>();
        }
    }
}
