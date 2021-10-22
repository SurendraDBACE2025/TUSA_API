using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities.Privileges;
using TUSA.Domain.Entities.Settings;
using TUSA.Domain.Models.Settings;

namespace TUSA.API.AutoMapper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            //CreateMap<RoleModel, role_master>();
            //CreateMap<role_master, RoleModel>();
        }
    }
}
