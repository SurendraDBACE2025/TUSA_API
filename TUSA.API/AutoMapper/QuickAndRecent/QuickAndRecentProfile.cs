using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.QuickAndRecent;
using TUSA.Domain.Models;
using TUSA.Domain.Models.QuickAndRecent;

namespace TUSA.API.AutoMapper
{
    public class QuickAndRecentProfile:Profile
    {
        public QuickAndRecentProfile()
        {
           CreateMap<form_details, form_details_model>();
           // CreateMap<quick_access_screens, quick_access_screens_model>();
        }
    }
}
