using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Data.Paging;
using TUSA.Domain.Entities.Settings;
using TUSA.Service.Master;

namespace TUSA.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameValueController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly INameValueService _service;
        public IConfiguration _configuration { get; }
        public NameValueController(ILogger<AuthController> logger, IMapper mapper, INameValueService service,
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
            name_value_pair name_pair = _service.GetByFieldId(id);
            //RoleModel roleModel = _mapper.Map<RoleModel>(role);
            // roleModel.Privileges = _mapper.Map<List<RolePrivilegeModel>>(role.RolePrivileges);
            return Ok(name_pair);
        }

        [HttpGet]
        public IActionResult GetList()
        {
           IPaginate<name_value_pair> name_pair = _service.GetAll();
            //RoleModel roleModel = _mapper.Map<RoleModel>(role);
            // roleModel.Privileges = _mapper.Map<List<RolePrivilegeModel>>(role.RolePrivileges);
            return Ok(name_pair);
        }
    }
}
