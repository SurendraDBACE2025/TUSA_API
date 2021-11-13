using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Core.Util;
using TUSA.Data;
using TUSA.Domain.Entities;
using TUSA.Domain.Models.master.Request;

namespace TUSA.Service
{
    public interface ISupplierGroupService : IBaseService<group_master>
    {
        pending_groups AddGroup(group_creation_request request);
        pending_groups UpdateGroup(group_user_creation_details request);
        List<group_master> GetSuppliersList(int groupTypeId);

         pending_groups GetGroupDetails(string email_id);
        List<group_master> GetSupplier(string UserId);
    }
   public class SupplierGroupService : BaseService<group_master>, ISupplierGroupService
    {
        public SupplierGroupService(IUnitOfWork uow) : base(uow)
        {

        }
    public List<group_master> GetSupplier(string UserId)
    {
            user_group_metrix ugm = _UOW.GetRepository<user_group_metrix>().Single(x => x.user.user_name == UserId,
                include: x => x.Include(x => x.group).ThenInclude(x=>x.group_type));
            if (ugm.group.group_type.group_type_name.ToUpper() == "SUPPLIER")
            {
                return _UOW.GetRepository<group_master>().Get(x => x.group_id == ugm.group.group_id).ToList();
            }
            else
            {
                return _UOW.GetRepository<group_master>().Get(x => x.group_type.group_type_name.ToUpper()== "SUPPLIER").ToList();
            }
    }
    public List<group_master> GetSuppliersList(int groupTypeId)
        {
            return _UOW.GetRepository<group_master>().Get(x=>x.group_type.group_type_id== groupTypeId).ToList();
        }
        public pending_groups GetGroupDetails(string email_id)
        { return _UOW.GetRepository<pending_groups>().Single(x => x.email_Id == email_id); }

        public pending_groups UpdateGroup(group_user_creation_details request)
        {
            pending_groups group = new pending_groups();
            pending_groups pending_Groups = _UOW.GetRepository<pending_groups>().Get(x => x.email_Id == request.email_id).FirstOrDefault();
            user_master user_Master = new user_master();
            user_Master.email_address = request.email_id;
            user_Master.contact_number = request.contact_number;
            user_Master.first_name = request.first_name;
            user_Master.last_name = request.last_name;
            user_Master.password = EncryptUtl.MD5Encrypt(request.password);
            user_Master.user_name = request.email_id;
            _UOW.GetRepository<user_master>().Add(user_Master);

            group_master group_Master = new group_master();
            group_Master.display_name = request.group_name;
            group_Master.group_desc = request.group_desc;
            group_Master.group_name = request.group_name;
            group_Master.group_type.group_type_id = 3;
            group_Master.is_active = "Y";
            group_Master.organization_name = request.organization_name;
            group_Master.created_by = user_Master.user_name;
            _UOW.GetRepository<group_master>().Add(group_Master);

            user_group_metrix ugm = new user_group_metrix();
            ugm.group = group_Master;
            ugm.role.role_id = 1;
            ugm.user = user_Master;
            _UOW.GetRepository<user_group_metrix>().Add(ugm);

            group.is_activated = true;
            _UOW.GetRepository<pending_groups>().Update(group);
            _UOW.SaveChanges();

            return group;
        }
        public pending_groups AddGroup(group_creation_request request)
        {
            pending_groups group = new pending_groups();
            if (_UOW.GetRepository<user_master>().Get(x => x.user_name == request.email_Id).FirstOrDefault() != null)
            {
                group.ID = -1;
                return group;
            }
            //   Mail.IMailService _mailservice=new Im
            // pending_groups group = new pending_groups();
            if (_UOW.GetRepository<pending_groups>().Get(x => x.email_Id == request.email_Id).FirstOrDefault() != null)
            {
                group.ID = -1;
                return group;
            }
            try
            {   group.email_Id = request.email_Id;
                group.group_Name = request.group_Name;
                group.organization_Name = request.organization_Name;
              
                group.contact_Last_Name = request.contact_Last_Name;
                group.contact_First_Name = request.contact_First_Name;
                group.is_activated = false;
             //   group.mail_status = false;
                _UOW.GetRepository<pending_groups>().Add(group);
            }
            catch (Exception Ex)
            {
                group.ID = -2;
                return group;
            }
            _UOW.SaveChanges();
            return group;

        }
    }
}
