using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Service;

namespace TUSA.API.Controllers.IFT
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormFieldController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IFormsService _service;

        public FormFieldController(IMapper mapper, IFormsService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
          //  for role = _service.Get(id);
        //    RoleModel roleModel = _mapper.Map<RoleModel>(role);
            return Ok();
        }

    }
}
