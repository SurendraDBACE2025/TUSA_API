
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
        public string UserId => User.Claims.FirstOrDefault(x => x.Type.Equals("Uid", StringComparison.OrdinalIgnoreCase)).Value ?? Guid.Empty.ToString();
       // public string UserType => User.Claims.FirstOrDefault(x => x.Type.Equals("UType", StringComparison.OrdinalIgnoreCase)).Value ?? Guid.Empty.ToString();

        public override ActionResult ValidationProblem()
        {
            base.ValidationProblem();
            IOptions<ApiBehaviorOptions> options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);

        }

    }
     
}
