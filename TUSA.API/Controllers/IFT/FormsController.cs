using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Models;
using TUSA.Service;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IFormsService _service;

        public FormsController(IMapper mapper, IFormsService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("GetAllForms")]
        public IActionResult GetForms()
        {
            return Ok(_mapper.Map<List<forms_model>>(_service.GetForms()));
        }
        [HttpGet("GetFormsByModule")]
        public IActionResult GetFormsByModule(int moduleId)
        {
            return Ok(_mapper.Map<List<forms_model>>(_service.GetFormsBasedoOnModule(moduleId)));
        }
        [HttpGet("GetFormsById")]
        public IActionResult GetFormsByForm(int formId)
        {
            return Ok(_mapper.Map<forms_model>(_service.GetFormsWithId(formId)));
        }
        [HttpGet("GetFormsByName")]
        public IActionResult GetFormsByName(string formName)
        {
            return Ok(_mapper.Map<List<forms_model>>(_service.GetFormsWithformName(formName)));
        }
    }
}
