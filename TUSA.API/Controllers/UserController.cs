
using AutoMapper;
using TUSA.Data.Paging;
using TUSA.Domain.Models;
using TUSA.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserController(IMapper mapper, IUserService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<UserModel>>(_service.GetUsers()));
        }

        [HttpGet("{userName}")]
        public IActionResult Get(string userName)
        {
            return Ok(_mapper.Map<UserModel>(_service.Get(userName)));
        }
        [HttpPost]
        public IActionResult Post(UserModel model)
        {
            _service.Add(_mapper.Map<Domain.Entities.UserMaster.user_master>(model));
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(UserModel model)
        {
            _service.Update(_mapper.Map<Domain.Entities.UserMaster.user_master>(model));
            return Ok();
        }
    }
}
