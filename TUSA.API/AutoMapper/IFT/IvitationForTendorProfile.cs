using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.QuickAndRecent;
using TUSA.Domain.Models;
using TUSA.Domain.Models.IFT;

namespace TUSA.API.AutoMapper
{
    public class IvitationForTendorProfile:Profile
    {
        public IvitationForTendorProfile()
        {
            CreateMap<forms_master,forms_model>()
                 .ForMember(dest => dest.module_id, opt => opt.MapFrom(x => x.module.module_id));
            CreateMap<forms_model,forms_master>();
            CreateMap<form_details, form_details_model>();
        }
    }
}
