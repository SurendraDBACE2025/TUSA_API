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
            CreateMap<pdc_gm_elements_master, pdc_gm_elements_model>();
            CreateMap<pdc_gm_scopecategry, pdc_gm_scopecategry_model>();
            CreateMap<pdc_gm_header, pdc_gm_header_model>();
        }
    }
}
