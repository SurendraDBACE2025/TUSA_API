
using AutoMapper;
using TUSA.Core.Result;
using TUSA.Data.Paging;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.Settings;
using TUSA.Domain.Models;
using TUSA.Domain.Models.Settings;
using TUSA.Service;
using TUSA.Service.Settings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TUSA.Domain.Entities.Privileges;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRolesService _service;

        public RoleController(IMapper mapper, IRolesService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public TUSA.API.Models.Paginate<RoleModel> GetAll()
        {
            return _mapper.Map<TUSA.API.Models.Paginate<RoleModel>>(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            role_master role = _service.Get(id);
            RoleModel roleModel = _mapper.Map<RoleModel>(role);
            return Ok(roleModel);
        }
        

        [HttpPost]
        public IActionResult Post(RoleModel model)
        {
            role_master role = _mapper.Map<Domain.Entities.Privileges.role_master>(model);
            Result<role_master> result = _service.AddNew(role);
            if (result.HasError)
            {
                return BadRequest(result);
            }
            return Ok(_mapper.Map<RoleModel>(result.ReturnValue));
        }

        [HttpPut]
        public IActionResult Put(RoleModel model)
        {
            role_master role = _mapper.Map<Domain.Entities.Privileges.role_master>(model);
          //  role.RolePrivileges = _mapper.Map<List<RolePrivilege>>(model.Privileges);
            ;
            Result<role_master> result = _service.UpdateNew(role);
            if (result.HasError)
            {
                return BadRequest(result);
            }
            return Ok(); 
        }

        [HttpGet("GetPages")]
        public IActionResult GetPages()
        {
            return Ok();
           // return Ok(_mapper.Map<IEnumerable<Domain.Models.Page>>(_service.Pages()));
        }

        [HttpGet("GetMenu/{RoleId}")]
        public IActionResult GetMenu(int RoleId)
        {
            return Ok();

            //return Ok(_service.RoleMenu(RoleId));
        }

        [HttpGet("GetMenuContent/{RoleId}")]
        public IActionResult GetMenuContent(int RoleId)
        {
            return Ok(_service.Get(RoleId).role_id);
        }

        [HttpGet("refdata")]
        public IEnumerable<Domain.Entities.ValueText> GetLookUpValues()
        {
            return _service.GetLookUpValues();
        }
    }
}
