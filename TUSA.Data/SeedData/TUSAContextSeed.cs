using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TUSA.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TUSA.Domain.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using TUSA.Data;
using TUSA.Domain.Entities.UserMaster;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.Data.SeedData
{
    public class TUSAContextSeed
    {
        static TUSAContext _tusaContext;
        public static async System.Threading.Tasks.Task SeedAsync(TUSAContext tusaContext, int? retry = 0)
        {
            _tusaContext = tusaContext;
            role_master role_master = _tusaContext.role_master.Where(x => x.role_name == "Administrator").FirstOrDefault();
            if (role_master == null)
            {
                int roleId = -100;
                _tusaContext.role_master.Add(new role_master { role_id = roleId, role_name = "Administrator",created_date = DateTime.Now });
                //foreach (Page page in _tusaContext.Pages.ToList())
                //{
                //    _tusaContext.RolePrivileges.Add(new RolePrivilege { ID = 1, PageId = page.ID, RoleId = roleId, Privilege = page.Privilege, AddedAt = DateTime.Now });
                //}
            }
            else
            {  
                //foreach (Page page in _tusaContext.Pages.ToList())
                //{
                //    RolePrivilege rolePrivilege = _tusaContext.RolePrivileges.Where(x => x.RoleId == role_master.ID
                //    && x.PageId == page.ID).FirstOrDefault();
                //    if (rolePrivilege == null)
                //    {
                //        _tusaContext.RolePrivileges.Add(new RolePrivilege { ID = 1, PageId = page.ID, RoleId = role_master.ID, Privilege = page.Privilege, AddedAt = DateTime.Now });
                //    }
                //}
            }

            await _tusaContext.SaveChangesAsync();


            if (_tusaContext.user_master.Where(x => x.user_name == "Administrator").Count() == 0)
            {
                role_master = _tusaContext.role_master.Single(x => x.role_name == "Administrator");
                _tusaContext.user_master.Add(new user_master
                {
                   
                    user_name = "Administrator",
                    password = "$5f4dcc3b5aa765d61d8327deb882cf99"
                });

                await _tusaContext.SaveChangesAsync();
            }

           
        }

        //private static Domain.Entities.Lab.TestAction NewTestAction(int SeqNo,string Name)
        //{
        //    return new Domain.Entities.Lab.TestAction
        //    {
        //        ID = Guid.NewGuid(),
        //        AddedAt = DateTime.Now,
        //        SeqNo = SeqNo,
        //        Name = Name
        //    };
        //}

        //private static void addSequenceAttribute(HMSContext hmsContext, string EntityName, string Attribute)
        //{
        //    if (hmsContext.SequenceNo.Where(x => x.EntityName == EntityName && x.Attribute == Attribute).Count() == 0)
        //    {
        //        _hmsContext.SequenceNo.Add(new SequenceNo
        //        {
        //            ID = Guid.NewGuid(),
        //            EntityName = EntityName,
        //            Attribute = Attribute,
        //            NextNo = 1,
        //            Prefix = string.Empty
        //        });
        //        _hmsContext.SaveChanges();
        //    }
        //}

        //private static void addLookUpMaster(HMSContext hmsContext, string Name, string Code)
        //{
        //    if (hmsContext.LookUpMaster.Where(x => x.Name == Name && x.Code == Code).Count() == 0)
        //    {
        //        _hmsContext.LookUpMaster.Add(new LookUpMaster
        //        {
        //            ID = Guid.NewGuid(),
        //            Name = Name,
        //            Code = Code,
        //            AddedAt = DateTime.Now,
        //            ModifiedAt = DateTime.Now
        //        });
        //        _hmsContext.SaveChanges();
        //    }
        //}

        //public static Tuple<int, string> GetSeqNo(string EntityName, string Attribute)
        //{
        //    SequenceNo sequenceNo = _hmsContext.SequenceNo.Single(x => x.EntityName == EntityName && x.Attribute == Attribute);
        //    int seq = sequenceNo.NextNo++;
        //    return new Tuple<int, string>(seq, $"{(string.IsNullOrEmpty(sequenceNo.Prefix) ? "A" : sequenceNo.Prefix)}{seq}");
        //}
    }
}