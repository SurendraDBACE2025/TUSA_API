﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Models;
using TUSA.Domain.Models.master;
using TUSA.Domain.Models.master.Request;
using TUSA.Service;
using TUSA.Service.Mail;

namespace TUSA.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimaryGroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISupplierGroupService _service;
        public PrimaryGroupController(IMapper mapper, ISupplierGroupService service)
        {
           
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        [HttpGet("GetPrimaryGroupDetails")]
        public IActionResult GetGroupDetails(string email_id)
        {

            return Ok(_mapper.Map<group_creation_model>(_service.GetGroupDetails(email_id)));

        }
        [HttpPost("GroupUpdate")]
        public IActionResult UpdateGroup(group_user_creation_details request)
        {
            return Ok(_service.UpdateGroup(request));
        }
    }
}
