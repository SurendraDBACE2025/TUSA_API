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

        public int UserId =>int.Parse(this.GetUserId());
        public int StaffId => this.GetStaffId();

        private string GetUserId()
        {
            
                if (this.httpContextAccessor.HttpContext != null)
                {
                    var identity = this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault();
                    return this.httpContextAccessor.HttpContext
                                      .User.Claims.FirstOrDefault(x => x.Type == "UId").Value ?? "0";
                }
           
            return "0";
        }

        private int GetStaffId()
        {
            int Sid = 0;
            if (this.httpContextAccessor.HttpContext != null)
            {

                int.TryParse(this.httpContextAccessor.HttpContext
                                  .User.Claims.FirstOrDefault(x => x.Type == "SId").Value ??"0", out Sid);

            }
            return Sid;
        }
    }
}