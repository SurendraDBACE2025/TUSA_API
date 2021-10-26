using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TUSA.API.Models;
using TUSA.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using TUSA.Domain.Models;
using TUSA.API.Services;
using TUSA.Core.Result;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using TUSA.Domain.Entities;
using TUSA.Core.Util;
using TUSA.Domain.Models.Settings;
using TUSA.Domain.Entities;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly ITokenService _tokenService;
        public IConfiguration _configuration { get; }
        public AuthController(ILogger<AuthController> logger, IMapper mapper, IUserService service,
            IConfiguration configuration, ITokenService tokenService)
        {
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            _logger.LogDebug("AuthController entered");
            Domain.Entities.user_master entity = _service.Validate(login.Username, login.Password);
            if (entity != null)
            {
                user_login_log success = new() { user_name = entity.user_name, ip_address = "123123144", loginat = DateTime.Now };
                _service.AddUserLoginLog(success);

                List<Claim> claims = new()
                {
                
                    new Claim("UId", entity.user_name.ToString())
                };
                return Ok(new
                {
                    jwtToken = _tokenService.GenerateAccessToken(claims),
                    refreshToken = entity.refresh_token,
                    status=1,
                    //roleId = entity.RoleId,
                    //name = entity.Name,
                    //type = entity.Type
                });//Success 
                return Ok();
            }
            //Faile
            user_login_fail fail = new() { user_name = login.Username, ip_address = "123123144", loginat = DateTime.Now };
            _service.AddUserLoginFail(fail);
            _logger.LogDebug("AuthController left");
            return BadRequest();

        }

        [HttpPost]
        [Route("Refresh")]
        public IActionResult Refresh(TokenApiModel tokenApiModel)
        {

            if (tokenApiModel is null)
            {
                return BadRequest();
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;

            Result<ClaimsPrincipal> resultToken = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            if (!resultToken.HasError)
            {
                string userName = "";
                userName= resultToken.ReturnValue.Claims.FirstOrDefault(x => x.Type == "UId").Value??userName;

                Result<Domain.Entities.user_master> result = _service.Refresh(userName, refreshToken);
                if (result.HasError)
                {
                    result = new Result<Domain.Entities.user_master>();
                    result.AddMessageItem(new MessageItem(ErrMessages.Invalid_Token));
                    return BadRequest(result);
                }
                return Ok(new TokenApiModel
                {
                    AccessToken = _tokenService.GenerateAccessToken(resultToken.ReturnValue.Claims),
                    RefreshToken = result.ReturnValue.refresh_token
                });
            }
            else
            {
                return BadRequest(resultToken);
            }
        }


        [HttpPost, Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            int userId = 0;
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == "UId").Value ?? "0", out userId);

            if (userId != 0)
            {
                _service.Revoke(userId);
            }

            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdatePassword(ChangePassword model)
        {
            user_master role = _mapper.Map<user_master>(model);
            Result<user_master> executionResult = new Result<user_master>();
            role = _service.ChangePassword(model.Name);
            model.OldPassword = EncryptUtl.MD5Encrypt(model.OldPassword);
            if (role.password == model.OldPassword)
            {
                if (!(string.IsNullOrEmpty(model.NewPassword.Trim())))
                {
                    role.password = EncryptUtl.MD5Encrypt(model.NewPassword);
                    executionResult = _service.UpdateNew(role);
                }
            }
            else
            {
                return BadRequest("Current Password is not Matching , please enter Valid Password");
            }
            return Ok(_mapper.Map<ChangePassword>(executionResult.ReturnValue));
        }

        [HttpGet("Info"), Authorize] 
        public IActionResult Info()
        { 
            Claim location = User.Claims.FirstOrDefault(x => x.Type.Equals("Sid", StringComparison.OrdinalIgnoreCase));
            if (location == null || string.IsNullOrEmpty(location.Value))
            {
                return Ok(new { Location = "" });
            }

            return Ok();
          //  return Ok(_service.Info(Guid.Parse(location.Value)));
        }
        //private string GetClientIp(HttpRequestMessage request = null)
        //{
        //    request = request ? Request;

        //    if (request.Properties.ContainsKey("MS_HttpContext"))
        //    {
        //        return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
        //    }
        //    else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
        //    {
        //        RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
        //        return prop.Address;
        //    }
        //    else if (HttpContext.Current != null)
        //    {
        //        return HttpContext.Current.Request.UserHostAddress;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
