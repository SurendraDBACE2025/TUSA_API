using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Core.Util;
using TUSA.Data;
using TUSA.Domain;
using TUSA.Domain.Entities;
using TUSA.Domain.Models.master.Request;

namespace TUSA.Service
{
    public interface ISupplierGroupService : IBaseService<group_master>
    {
        ApiResponce AddGroup(group_creation_request request);
        ApiResponce UpdateGroup(group_user_creation_details request);
        List<group_master> GetSuppliersList(int groupTypeId);

         pending_groups GetGroupDetails(string email_id);
        List<group_master> GetSupplier(string UserId);
        ApiResponce<pending_groups> GetGroupDetailsByMailId(string email_id);
    }
   public class SupplierGroupService : BaseService<group_master>, ISupplierGroupService
    {
        public SupplierGroupService(IUnitOfWork uow) : base(uow)
        {

        }
    public List<group_master> GetSupplier(string UserId)
    {
            user_group_metrix ugm = _UOW.GetRepository<user_group_metrix>().Single(x => x.user_master_Id == UserId);
            group_master group = _UOW.GetRepository<group_master>().Single(x => x.group_id == ugm.group_Id);
            List<group_type_master> gtmList = _UOW.GetRepository<group_type_master>().Get().ToList();
            if (gtmList.Any(x => x.group_type_id == group.group_type_id && x.group_type_name == "SUPPLIER"))
            {
                return _UOW.GetRepository<group_master>().Get(x => x.group_id == ugm.group_Id).ToList();
            }
            else if (gtmList.Any(x => x.group_type_id == group.group_type_id && (x.group_type_name != "SUPPLIER")))// || x.group_type_name == "SUPPER ADMIN")))
            {
                return _UOW.GetRepository<group_master>().Get(x => x.group_type_id==3).ToList();
            }
            else if (gtmList.Any(x => x.group_type_id == group.group_type_id &&  x.group_type_name == "SUPPER ADMIN"))
            {
                return _UOW.GetRepository<group_master>().Get(x => x.group_type_id != 1).ToList();
            }
            else
            {
                return new List<group_master>();
            }
    }
    public List<group_master> GetSuppliersList(int groupTypeId)
        {
            return _UOW.GetRepository<group_master>().Get().ToList();
        }
        public pending_groups GetGroupDetails(string email_id)
        { return _UOW.GetRepository<pending_groups>().Single(x => x.email_Id == email_id); }

        public ApiResponce UpdateGroup(group_user_creation_details request)
        {
            try
            {
                pending_groups group = new pending_groups();
                pending_groups pending_Groups = _UOW.GetRepository<pending_groups>().Get(x => x.email_Id == request.email_id).FirstOrDefault();
                user_master user = _UOW.GetRepository<user_master>().Get(x => x.user_master_id == request.email_id).FirstOrDefault();
                if (user != null)
                {
                    return new ApiResponce() { Status = false, Message = "The iven email already registred, Please go for log in page", ErrorType =true };
                }
                _UOW.BeginTrans();
                user_master user_Master = new user_master();
                user_Master.user_master_id = request.email_id;
                user_Master.contact_number = request.contact_number;
                user_Master.first_name = request.contact_First_Name;
                user_Master.last_name = request.contact_Last_Name;
                user_Master.password = EncryptUtl.MD5Encrypt(request.password);
                user_Master.user_type.user_type_id = 1;
                user_Master.is_activated = "1";
                user_Master.is_active = "1";
                user_Master.is_deleted = "0";
                _UOW.GetRepository<user_master>().Add(user_Master);
                _UOW.SaveChanges();

                group_master group_Master = new group_master();
                group_Master.display_name = request.group_name;
                group_Master.group_desc = request.group_desc;
                group_Master.group_name = request.group_name;
                group_Master.group_type_id = 3;
                group_Master.is_active = "1";
                group_Master.organization_name = request.organization_name;
                group_Master.created_by = request.email_id;
                group_Master.is_deleted = "0";
                _UOW.GetRepository<group_master>().Add(group_Master);

                _UOW.SaveChanges();

                user_group_metrix ugm = new user_group_metrix();
                ugm.group_Id = group_Master.group_id;
                ugm.role_Id = 1;
                ugm.user_master_Id = request.email_id;
                _UOW.GetRepository<user_group_metrix>().Add(ugm);

                _UOW.SaveChanges();

                group = pending_Groups;
                group.is_activated = true;
                _UOW.GetRepository<pending_groups>().Update(group);
                _UOW.SaveChanges();
                _UOW.CommitTrans();
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }
            return new ApiResponce() { Status = true, Message = "", ErrorType = false };
        }
        public ApiResponce AddGroup(group_creation_request request)
        {
            pending_groups group = new pending_groups();
            if (_UOW.GetRepository<user_master>().Get(x => x.user_master_id == request.email_Id).FirstOrDefault() != null)
            {
                return new ApiResponce() { Status = false, Message = "The email address is already registred, Please go for login page", ErrorType = true };

            }
            //   Mail.IMailService _mailservice=new Im
            // pending_groups group = new pending_groups();
            if (_UOW.GetRepository<pending_groups>().Get(x => x.email_Id == request.email_Id).FirstOrDefault() != null)
            {
                return new ApiResponce() { Status = false, Message = "The email address is already registred", ErrorType = true };

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
                _UOW.SaveChanges();
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }
           
            return new ApiResponce() { Status = true, Message = "", ErrorType = false };
           

        }
        public ApiResponce<pending_groups> GetGroupDetailsByMailId(string email_id)
        {
            try
            {
                pending_groups group = new pending_groups();

                if (string.IsNullOrEmpty(email_id))
                    return new ApiResponce<pending_groups>() { Status = false, Message = "No Email Id Provided", ErrorType = false, Result = null };

                group = _UOW.GetRepository<pending_groups>().Get(x => x.email_Id == email_id).FirstOrDefault();

                return new ApiResponce<pending_groups>() { Status = true, Message = "Group Details Fetched", ErrorType = false, Result = group };
            }
            catch(Exception ex)
            {
                return new ApiResponce<pending_groups>() { Status = false, Message = "Error Encountered : " + ex.Message, ErrorType = false, Result = null };
            }
        }
    }
}
