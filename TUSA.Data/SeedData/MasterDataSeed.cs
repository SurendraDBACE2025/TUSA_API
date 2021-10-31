using TUSA.Core.Util;
using TUSA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Data.SeedData
{
    public class MasterDataSeed
    {
        static TUSAContext _TUSAContext;

        public static async System.Threading.Tasks.Task SeedAsync(TUSAContext TUSAContext, int? retry = 0)
        {
            _TUSAContext = TUSAContext;
            Guid branchId = Guid.NewGuid(); // Guid.Parse("5AF34CD8-3697-4F6C-98AC-FEC5DF684F7E");


            List<user_master> users = new();
            List<role_master> roles = _TUSAContext.role_master.ToList();
            int roleId = roles.FirstOrDefault().role_id;

            Random random = new();
            int number = 5;


            users.Add(new user_master
            {
                //ID =1,
                ////  Name = $"staff{i}",
                //Password = EncryptUtl.MD5Encrypt("password"),
                //RoleId = roleId,
                //NoOfWrongs = 0,
                //Type = 0,
                //AddedAt = DateTime.Now,
            });
        }
    }
}