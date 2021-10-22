using System;
using AutoMapper;
using TUSA.API.Converter;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.UserMaster;
using TUSA.Domain.Models;

namespace TUSA.API
{
    public class AutoMapperProfile : Profile
    {
        private DateTime? numberToDt(DateTime dt, string time)
        {
            if (!string.IsNullOrEmpty(time))
            {
                return dt.Date.AddHours(int.Parse(time.Substring(0, 2))).AddMinutes(int.Parse(time.Substring(2, 2)));
            }
            return null;
        }
        public AutoMapperProfile()
        {
            CreateMap<Domain.Entities.LookUpValues, Domain.Models.LookUpValues>();
            CreateMap<Domain.Models.LookUpValues, Domain.Entities.LookUpValues>();


            //CreateMap<TUSA.Domain.Entities.Settings.Role, Domain.Models.Settings.RoleModel>()
            //    .ForMember(d => d.Privileges, s => s.MapFrom(x => x.RolePrivileges));
            //CreateMap<Domain.Models.Settings.RoleModel, TUSA.Domain.Entities.Settings.Role>()
            //    .ForMember(d => d.RolePrivileges, s => s.MapFrom(x => x.Privileges));

            //CreateMap<TUSA.Domain.Entities.Settings.RolePrivilege, Domain.Models.RolePrivilegeModel>()
            //    .ForMember(d => d.Name, s => s.MapFrom(x => x.Page.Name))
            //    .ForMember(d => d.DisplayName, s => s.MapFrom(x => x.Page.DisplayName))
            //    .ForMember(d => d.Module, s => s.MapFrom(x => x.Page.Group.Name));
            //CreateMap<Domain.Models.RolePrivilegeModel, TUSA.Domain.Entities.Settings.RolePrivilege>();

            //CreateMap<TUSA.Domain.Entities.Page, TUSA.Domain.Models.Page>()
            //    .ForMember(d => d.Module, s => s.MapFrom(x => x.Group.Name));

            //CreateMap<TUSA.Domain.Entities.User, TUSA.Domain.Models.UserModel>()
            //    .ForMember(d => d.Name, s => s.MapFrom(x => x.Name));
                //.ForMember(d => d.Role, s => s.MapFrom(x => x.Role.Name));

            CreateMap<TUSA.Domain.Models.UserModel, TUSA.Domain.Entities.UserMaster.user_master>();

            CreateMap<TUSA.Domain.Models.SequenceNoModel, TUSA.Domain.Entities.SequenceNo>();
            CreateMap<TUSA.Domain.Entities.SequenceNo, TUSA.Domain.Models.SequenceNoModel>();



            CreateMap(typeof(Data.Paging.Paginate<>), typeof(Models.Paginate<>)).ConvertUsing(typeof(TUSA.API.Converter.Converter<,>));


            CreateMap<Domain.Models.Settings.ChangePassword, user_master>();
            CreateMap<user_master, Domain.Models.Settings.ChangePassword>()
            .ForMember(d => d.OldPassword, s => s.MapFrom(x => x.password));


        }


    }
}
