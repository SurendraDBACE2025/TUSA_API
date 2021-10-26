using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Models;
using TUSA.Service;

namespace TUSA.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameValuePairController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly INameValuePairService _service;

        public NameValuePairController(IMapper mapper, INameValuePairService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public IActionResult GetValuePairList()
        {
            var list = _service.GetList();
            return Ok(_mapper.Map<List<name_value_pair_model>>(list));
        }


        [HttpGet]
        public IActionResult GetValuePairDetails(int fieldId)
        {
         var list=_service.GetByFieldId(fieldId);
            return Ok(_mapper.Map<List<name_value_pair_model>>(list));
        }
    }
}
