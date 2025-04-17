using AutoMapper;
using TUSA.Domain.Entities;
using TUSA.Domain.Models.IFT;

namespace TUSA.API.AutoMapper.Master
{
    public class FormMasterProfile : Profile
    {
        public FormMasterProfile()
        {
            CreateMap<forms_master, forms_master_model>();
        }
    }
}
