using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;

namespace TUSA.API.AutoMapper
{
    public class QuickAndRecentProfile:Profile
    {
        public QuickAndRecentProfile()
        {
            CreateMap<recently_accessed_screens, recently_accessed_screens_model>()
                 .ForMember(dest => dest.forms_model, opt => opt.MapFrom(x => x.forms_master));
            CreateMap<quick_access_screens, quick_access_screens_model>()
                 .ForMember(dest => dest.forms_model, opt => opt.MapFrom(x => x.forms_master));
        }
    }
}
