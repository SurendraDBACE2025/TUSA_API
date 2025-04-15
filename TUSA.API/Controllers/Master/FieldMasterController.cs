using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TUSA.Service.Mail;
using TUSA.Service;
using System.Collections.Generic;
using TUSA.Domain.Models;
using TUSA.Domain.Entities;
using TUSA.Domain.Models.master;
using TUSA.Domain.Models.IFT.Request;
using Microsoft.AspNetCore.Authorization;

namespace TUSA.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldMasterController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IFormFieldService _formFieldService;
        
        public FieldMasterController(IMapper mapper, IFormFieldService formFieldService)
        {
            _mapper = mapper;
            _formFieldService = formFieldService;
        }

        [Route("GetAllFields")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllFields()
        {

            var list = _formFieldService.GetAllFields();
            return Ok(_mapper.Map<List<field_model>>(list));
        }

        [Route("MapFieldsToModule")]
        [HttpPost]
        public IActionResult MapFieldsToModule(FieldFormModuleMappingRequest request)
        {

            var response = _formFieldService.MapFieldsToModule(request);
            return Ok(response);
        }
    }
}
