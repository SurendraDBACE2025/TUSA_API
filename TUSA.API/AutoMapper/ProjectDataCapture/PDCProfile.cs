using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;

namespace TUSA.API.AutoMapper
{
    public class PDCProfile:Profile
    {
        public PDCProfile()
        {
            CreateMap<pdc_element_master, pdc_element_model>()
                 .ForMember(dest => dest.category_id, opt => opt.MapFrom(x => x.pdc_category_master.category_id))
                 .ForMember(dest => dest.Category_name, opt => opt.MapFrom(x => x.pdc_category_master.category_name));
            CreateMap<pdc_category_master, pdc_category_model>();
            CreateMap<pdc_header_data, pdc_header_model>();
            CreateMap<project_master, project_model>();
        }
    }
}
