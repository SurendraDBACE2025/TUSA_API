using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Models;
using TUSA.Service;

namespace TUSA.API.Controllers.ProjectModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IModuleService _service;

        public ModuleController(IMapper mapper, IModuleService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("GetModules")]
        public IActionResult GetModules()
        {
            return Ok(_mapper.Map<List<module_model>>(_service.GetModules(base.UserId)));
        }

    }
}

