using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain;
using TUSA.Domain.Models.master;
using TUSA.Domain.Models.master.Request;
using TUSA.Domain.Models.User.Request;
using TUSA.Domain.Models.User.Responce;
using TUSA.Service;
using TUSA.Service.Mail;

namespace TUSA.API.Controllers.NoAuth
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoAuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly IMailService _mailService;
        private readonly ISupplierGroupService _groupservice;

        public NoAuthController(IMapper mapper, IUserService service, IMailService mailService, ISupplierGroupService  groupservice)
        {
            _mapper = mapper;
            _service = service;
            _mailService = mailService;
            _groupservice = groupservice;
        }

        [HttpGet("GetPrimaryUser")]
        public IActionResult GetPendingUser(string email_id)
        {
            
            return Ok(_service.GetPrimaryUser(email_id));
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(user_request request)
        {
            ApiResponce responce = _service.UserCreation(request);

            return Ok(responce);
        }

        [HttpGet("GetPrimaryGroupDetails")]
        public IActionResult GetGroupDetails(string email_id)
        {

            return Ok(_mapper.Map<group_creation_model>(_groupservice.GetGroupDetails(email_id)));

        }
        [HttpPost("GroupUpdate")]
        public IActionResult UpdateGroup(group_user_creation_details request)
        {
            return Ok(_groupservice.UpdateGroup(request));
        }

    }
}
