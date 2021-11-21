using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using TUSA.Domain.Models.master;

namespace TUSA.API.AutoMapper
{
    public class masterProfile:Profile
    {
        public masterProfile()
        {
            CreateMap<group_master, group_model>();
            CreateMap<country_master, country_model>()
                 .ForMember(dest => dest.content_code, opt => opt.MapFrom(x => x.continent.continent_code));
            CreateMap<currency_master, currency_model>()
                 .ForMember(dest => dest.country_code, opt => opt.MapFrom(x => x.country.country_code));
            CreateMap<continent_master, continent_model>();
            CreateMap<name_value_pair, name_value_pair_model>()
                 .ForMember(dest => dest.field_id, opt => opt.MapFrom(x => x.field.field_id));
            CreateMap<pending_groups, group_model>().ForMember(dest => dest.group_id, opt => opt.MapFrom(x => x.pending_group_ID))
                .ForMember(dest => dest.group_name, opt => opt.MapFrom(x => x.contact_First_Name));

            CreateMap<pending_groups, group_creation_model>();
        }
    }
}
