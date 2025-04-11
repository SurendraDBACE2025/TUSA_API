
using AutoMapper;
using TUSA.Data.Paging;
using TUSA.Domain.Models;
using TUSA.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TUSA.Domain.Models.User;
using TUSA.Domain;
using TUSA.Service.Mail;
using TUSA.Domain.Models.User.Request;
using TUSA.Domain.Models.User.Responce;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly IMailService _mailService;

        public UserController(IMapper mapper, IUserService service, IMailService mailService)
        {
            _mapper = mapper;
            _service = service;
            _mailService = mailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<UserModel>>(_service.GetUsers()));
        }

        [HttpGet("{userName}")]
        public IActionResult Get(string username)
        {
            return Ok(_mapper.Map<UserModel>(_service.Get(username)));
        }
        [HttpPost("AddPrimaryUser")]
        public IActionResult PendingUserCreation(user_creation_request request)
        {
            ApiResponce responce= _service.PendingUserCreation(request);
            
            _mailService.sendUserFormLinkAsync(request);
               
            return Ok(responce);
        }


        [HttpPost]
        public IActionResult Post(UserModel model)
        {
            _service.Add(_mapper.Map<Domain.Entities.user_master>(model));
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(UserModel model)
        {
            _service.Update(_mapper.Map<Domain.Entities.user_master>(model));
            return Ok();
        }
        //[HttpGet("GetIncompleteUsers")]
        //public IActionResult GetIncompleteUsers()
        //{
        //    return Ok(_mapper.Map<List<form_details_model>>(_service.GetInCompleteForms()));
        //}
    }
}
