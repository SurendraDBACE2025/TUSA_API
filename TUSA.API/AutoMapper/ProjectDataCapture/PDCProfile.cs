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
            CreateMap<pdc_element_master, pdc_element_model>();
            CreateMap<pdc_category_master, pdc_category_model>();
            CreateMap<pdc_header_data, pdc_header_model>();
        }
    }
}
