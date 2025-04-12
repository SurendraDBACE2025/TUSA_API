using AutoMapper;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using TUSA.Domain.Models.master;

namespace TUSA.API.AutoMapper.Master
{
    public class FieldMasterProfile : Profile
    {
        public FieldMasterProfile() {
            CreateMap<field_master, field_model>();            
        }
    }
}
