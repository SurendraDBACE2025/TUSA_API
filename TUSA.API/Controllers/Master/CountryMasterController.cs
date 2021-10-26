using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using TUSA.Service;

namespace TUSA.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryMasterController : BaseController  
    {
        private readonly IMapper _mapper;
        private readonly ICountryMasterService _service;

        public CountryMasterController(IMapper mapper, ICountryMasterService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("GetCountrys")]
        public IActionResult GetCountrys()
        {
           List<country_master> list=  _service.GetCountryList();

            return Ok(_mapper.Map<List<country_model>>(list));
        }

    }
}
