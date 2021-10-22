
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace TUSA.API.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string TypeId => User.Claims.FirstOrDefault(x => x.Type.Equals("Typ", StringComparison.OrdinalIgnoreCase)).Value ?? Guid.Empty.ToString();
        //public string StaffId => User.Claims.FirstOrDefault(x => x.Type.Equals("Sid", StringComparison.OrdinalIgnoreCase)).Value ?? Guid.Empty.ToString();
        public string DoctorId => User.Claims.FirstOrDefault(x => x.Type.Equals("Did", StringComparison.OrdinalIgnoreCase)).Value ?? Guid.Empty.ToString();
        public string UserId => User.Claims.FirstOrDefault(x => x.Type.Equals("Uid", StringComparison.OrdinalIgnoreCase)).Value ?? Guid.Empty.ToString();

        public Guid STAFFID
        {
            get
            {
                Claim location = User.Claims.FirstOrDefault(x => x.Type.Equals(GlobalConst.AUTH_STAFFID, StringComparison.OrdinalIgnoreCase));
                return location == null || string.IsNullOrEmpty(location.Value) ? Guid.Empty : Guid.Parse(location.Value);
            }
        }
        public Guid LOCATIONID
        {
            get
            {
                Claim location = User.Claims.FirstOrDefault(x => x.Type.Equals(GlobalConst.AUTH_LOCATIONID, StringComparison.OrdinalIgnoreCase));
                return location == null || string.IsNullOrEmpty(location.Value) ? Guid.Empty : Guid.Parse(location.Value);
            }
        }
        public Guid DOCTORID
        {
            get
            {
                Claim doctor = User.Claims.FirstOrDefault(x => x.Type.Equals(GlobalConst.AUTH_DOCTORID, StringComparison.OrdinalIgnoreCase));
                return doctor == null || string.IsNullOrEmpty(doctor.Value) ? Guid.Empty : Guid.Parse(doctor.Value);
            }
        }

        public override ActionResult ValidationProblem()
        {
            base.ValidationProblem();
            IOptions<ApiBehaviorOptions> options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);

        }

    }
     
}
