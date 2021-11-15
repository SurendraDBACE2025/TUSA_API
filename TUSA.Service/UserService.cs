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
        //dynamic Info(Guid Id);
    }

    public class UserService : BaseService<user_master>, IUserService
    {
        public UserService(IUnitOfWork uow) : base(uow)
        {

        }

        public IEnumerable<user_master> GetUsers()
        {
            return _UOW.GetRepository<user_master>().Get(include: x => x.Include(o => o.user_type_master));
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
            user_master entity = _UOW.GetRepository<user_master>().Single(x => x.user_email_id == item.user_email_id);
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
            user_master entity = _UOW.GetRepository<user_master>().Single(x => x.user_email_id == Username);
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
            user_master user_master = _UOW.GetRepository<user_master>().Single(x => x.user_email_id == id);
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
            user_master entity = _UOW.GetRepository<user_master>().Single(x => x.user_email_id == "");
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
            user_master entity = _UOW.GetRepository<user_master>().Single(x => x.user_email_id == Username);
            return entity;
        }
    }

}
