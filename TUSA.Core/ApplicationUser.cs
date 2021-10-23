using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace TUSA.Core
{
    public class ApplicationUser : IApplicationUser
    {
        //https://stackoverflow.com/questions/52050501/how-to-access-jwt-user-claims-in-class-library
        private readonly IHttpContextAccessor httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }

        public string UserId => this.GetUserId();
        public string StaffId => this.GetStaffId();

        private string GetUserId()
        {
            if (this.httpContextAccessor.HttpContext != null)
            {
                return this.httpContextAccessor.HttpContext
                                  .User.Claims.FirstOrDefault(x => x.Type == "UId").Value ?? "";
            }
            return "";
        }

        private string GetStaffId()
        {
            Guid Sid = Guid.Empty;
            if (this.httpContextAccessor.HttpContext != null)
            {
                return this.httpContextAccessor.HttpContext
                                                  .User.Claims.FirstOrDefault(x => x.Type == "SId").Value ?? "";

              
            }
            return "";
        }
    }
}