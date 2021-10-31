using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;

namespace TUSA.API.AutoMapper
{
    public class ModuleProfile:Profile
    {

        public ModuleProfile()
        {
            CreateMap<module_master, module_model>();
            CreateMap<module_model, module_master>();
        }
    }
}
