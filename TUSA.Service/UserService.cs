using TUSA.Core.Result;
using TUSA.Core.Util;
using TUSA.Data;
using TUSA.Data.Paging;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using TUSA.Domain.Entities;
using System.Linq;
using TUSA.Domain.Models.User;
using TUSA.Domain.Entities.User;
using TUSA.Domain;
using TUSA.Domain.Models.User.Request;
using TUSA.Domain.Models.User.Responce;

namespace TUSA.Service
{
    public interface IUserService : IBaseService<user_master>
    {
        user_master Validate(string username, string password);
        //Domain.Entities.Setup.Staff StaffInfo(Guid Id);
        IEnumerable<user_master> GetUsers();
        void Revoke(int id);
        Result<user_master> Refresh(string id, string refreshToken);
        void AddUserLoginLog(user_login_log loginitem);
        void AddUserLoginFail(user_login_fail loginitem);
        user_master ChangePassword(string username);
        group_type_master GetUserType(string user_Id);

        ApiResponce PendingUserCreation(user_creation_request request);
        ApiResponce UserCreation(user_request request);

        ApiResponce GetPrimaryUser(string user_email);
    }

    public class UserService : BaseService<user_master>, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow)
        {

        }
        public group_type_master GetUserType(string user_Id)
        { 
           int groupid= _UOW.GetRepository<user_group_metrix>().Get(x=>x.user_master_Id==user_Id).FirstOrDefault().group_Id;
            var gtId= _UOW.GetRepository<group_master>().Get(x => x.group_id == groupid).FirstOrDefault().group_type_id;
            return _UOW.GetRepository<group_type_master>().Get(x => x.group_type_id == gtId).FirstOrDefault();
        }
        public IEnumerable<user_master> GetUsers()
        {
            return _UOW.GetRepository<user_master>().Get(include: x => x.Include(o => o.user_type));
        }
        public override user_master Add(user_master item)
        {
            item.password = EncryptUtl.MD5Encrypt(item.password);
            return base.Add(item);
        }
        public void AddUserLoginLog(user_login_log item)
        {
            _UOW.GetRepository<user_login_log>().Add(item);
            _UOW.SaveChanges();
        }
        public void AddUserLoginFail(user_login_fail item)
        {
            _UOW.GetRepository<user_login_fail>().Add(item);
            _UOW.SaveChanges();
        }

        public override void Update(user_master item)
        {
            user_master entity = _UOW.GetRepository<user_master>().Single(x => x.user_master_id == item.user_master_id);
            if (entity != null)
            {
               // entity.RoleId = item.RoleId;
                if (!(string.IsNullOrEmpty(item.password.Trim())))
                {
                    entity.password = EncryptUtl.MD5Encrypt(item.password);
                }

                base.Update(entity);
            }
        }

        public user_master Validate(string Username, string Password)
        {
            List<user_master> list = _UOW.GetRepository<user_master>().Get().ToList();
            user_master entity = _UOW.GetRepository<user_master>().Get(x => x.user_master_id == Username,
                include:x=>x.Include(x=>x.user_type)).FirstOrDefault();
            if (entity == null || entity.password != EncryptUtl.MD5Encrypt(Password))
            {
               
                return null;
            }
            entity.refresh_token = GenerateRefreshToken();
            entity.refresh_token_expiryat = DateTime.Now.AddDays(1);
            base.Update(entity);
            return entity;
        }

     
        public Result<user_master> Refresh(string id, string refreshToken)
        {
            Result<user_master> result = new Result<user_master>();
            user_master user_master = _UOW.GetRepository<user_master>().Single(x => x.user_master_id == id);
            if (user_master == null || user_master.refresh_token != refreshToken || user_master.refresh_token_expiryat <= DateTime.Now)
            {
                result.AddMessageItem(new MessageItem(Resource.RefreshToken_Invalid));
            }

            if (!result.HasError)
            {
                user_master.refresh_token = GenerateRefreshToken();
                user_master.refresh_token_expiryat = DateTime.Now.AddHours(1);
                base.Update(user_master);

                result.ReturnValue = user_master;
            }
            return result;
        }
        public void Revoke(int id)
        {
            user_master entity = _UOW.GetRepository<user_master>().Single(x => x.user_master_id == "");
            entity.refresh_token = null;
            base.Update(entity);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public user_master ChangePassword(string Username)
        {
            user_master entity = _UOW.GetRepository<user_master>().Single(x => x.user_master_id == Username);
            return entity;

        }
        public ApiResponce PendingUserCreation(user_creation_request request)
        {
            try
            {
                _UOW.BeginTrans();
                foreach (user_craetion user in request.users)
                {
                    _UOW.GetRepository<pending_users>().Add(new pending_users() { email_Id = user.email_Id, group_id = user.group_Id });
                }
                _UOW.SaveChanges();
                _UOW.CommitTrans();
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message =Ex.Message,ErrorType=false };
            }
            return new ApiResponce() { Status = true,Message="" };
        }
        public ApiResponce UserCreation(user_request request)
        {
            try
            {
               
                if (_UOW.GetRepository<user_master>().Get().Any(x => x.user_master_id == request.email_id))
                {
                    return new ApiResponce() { Status = false, Message = "The email address is already registred, Please go for login page", ErrorType = true };
                }
                else
                {
                    user_master user = new user_master();
                    user.user_master_id = request.email_id;
                    user.first_name = request.first_name;
                    user.last_name = request.last_name;
                    user.contact_number = request.contact_number;
                    user.password = EncryptUtl.MD5Encrypt(request.password);
                    user.is_activated ="1";
                    user.is_deleted = "0";
                    user.is_active = "1";
                    user.last_login_time = DateTime.MinValue;
                    user.refresh_token = "";
                    user.last_reset_attempt_time = DateTime.MinValue;
                    _UOW.GetRepository<user_master>().Add(user);
                    _UOW.SaveChanges();
                    user_group_metrix ugm = new user_group_metrix();
                    if (!_UOW.GetRepository<user_group_metrix>().Get().Any(x => x.user_master_Id == request.email_id))
                    {
                        ugm.user_master_Id = request.email_id;
                        ugm.group_Id = request.group_id;
                        ugm.role_Id = 1;
                        _UOW.GetRepository<user_group_metrix>().Add(ugm);
                        _UOW.SaveChanges();
                    }
                }
                
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }
            return new ApiResponce() { Status = true, Message = "", ErrorType = false };
        }

        public ApiResponce GetPrimaryUser(string user_email)
        {
            try
            {
                primary_user_model model = new primary_user_model();
                pending_users user = _UOW.GetRepository<pending_users>().Single(x => x.email_Id == user_email);
                if (user != null)
                {
                    group_master gm = _UOW.GetRepository<group_master>().Single(x => x.group_id == user.group_id);
                    model.email_id = user_email;
                    model.group_id = gm.group_id;
                    model.group_name = gm.group_name;
                }
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }
            return new ApiResponce() { Status = true, Message = "", ErrorType = false };
        }
    }

}
