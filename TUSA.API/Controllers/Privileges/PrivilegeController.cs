using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Data.Paging;
using TUSA.Domain.Entities.Privileges;
using TUSA.Domain.Models.Privileges;
using TUSA.Service.Privilege;

namespace TUSA.API.Controllers.Privileges
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IPrivilegeService _service;
        public IConfiguration _configuration { get; }
        public PrivilegeController(ILogger<AuthController> logger, IMapper mapper, IPrivilegeService service,
            IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            privilege_master name_pair = _service.GetByFieldId(id);
            //RoleModel roleModel = _mapper.Map<RoleModel>(role);
            // roleModel.Privileges = _mapper.Map<List<RolePrivilegeModel>>(role.RolePrivileges);
            return Ok(name_pair);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            IPaginate<privilege_master> name_pair = _service.GetAll();
            //RoleModel roleModel = _mapper.Map<RoleModel>(role);
            // roleModel.Privileges = _mapper.Map<List<RolePrivilegeModel>>(role.RolePrivileges);
            return Ok(name_pair);
        }
        [HttpPost]
        public IActionResult Post(PrivilegeModel model)
        {
            _service.Add(_mapper.Map<Domain.Entities.Privileges.privilege_master>(model));
            return Ok();
        }
        [HttpPost("RolePrivilege")]
        public IActionResult RolePrivilege(RolePrivilegeModel model)
        {
          var result=  _service.CreteRolePrivilege(_mapper.Map<Domain.Entities.Privileges.role_privilege_metrix>(model));
            return Ok(_mapper.Map<Domain.Models.Privileges.RolePrivilegeModel>(result));
        }

        [HttpPost("UserGroup")]
        public IActionResult UserGroupPrivilege(UserGroupModel model)
        {
          var result=  _service.CreteUserGroupMetrix(_mapper.Map<Domain.Entities.user_group_metrix>(model));
            return Ok(_mapper.Map<Domain.Models.Privileges.UserGroupModel>(result));
        }
    }
}
