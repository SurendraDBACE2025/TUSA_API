using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;

namespace TUSA.API.AutoMapper
{
    public class masterProfile:Profile
    {
        public masterProfile()
        {   
            CreateMap<group_master, group_model>();
            CreateMap<country_master, country_model>();
            CreateMap<currency_master, currency_model>();
            CreateMap<continent_master, continent_model>();
            CreateMap<name_value_pair, name_value_pair_model>();
        }
    }
}
