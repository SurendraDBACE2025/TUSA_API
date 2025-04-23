using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain;
using TUSA.Domain.Models;
using TUSA.Domain.Models.IFT;
using TUSA.Domain.Models.IFT.Request;
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
            return Ok(_mapper.Map<List<forms_model>>(_service.GetFormsBasedoOnModule(moduleId,base.UserId)));
        }
        [HttpGet("GetFormsByRole")]
        public IActionResult GetFormsByRole()
        {
            return Ok(_mapper.Map<List<forms_master_model>>(_service.GetFormsBasedoOnRole( base.UserId)));
        }
        [HttpGet("GetIncompleteForms")]
        public IActionResult GetIncompleteForms()
        {
            return Ok(_mapper.Map<List<form_details_model>>(_service.GetInCompleteForms()));
        }
        [HttpGet("GetFormsById")]
        public IActionResult GetFormsByForm(int formId)
        {
            return Ok(_mapper.Map<forms_model>(_service.GetFormsWithId(formId)));
        }
        [HttpGet("GetFormsByName")]
        public IActionResult GetFormsByName(string formName)
        {
            return Ok(_mapper.Map<forms_model>(_service.GetFormsWithformName(formName)));
        }
        [HttpGet("GetAssignedformsBySupplier")]
        public IActionResult GetSupplierAssignedForms(int supplierId)
        {
            return Ok(_mapper.Map<List<forms_master_model>>(_service.GetSupplierAssignedForms(supplierId)));
        }
        [HttpGet("GetUnAssignedformsBySupplier")]
        public IActionResult GetSupplierUnAssignedForms(int supplierId)
        {
            return Ok(_mapper.Map<List<forms_master_model>>(_service.GetSupplierUnAssignedForms(supplierId)));
        }
        [HttpPost("AssignFormsToSupplier")]
        public IActionResult AssignFormsToSupplier(List<forms_assign_model_request> request)
        {
            ApiResponce responce = _service.AssignFormsToSupplier(request);
            return Ok(responce);
        }

        [HttpGet("GetMasterForms")]
        public IActionResult GetMasterForms(string? menuItem = "")
        {             
            return Ok(_mapper.Map<List<forms_master_model>>(_service.GetMasterForms(base.UserId, menuItem)));
        }

        [HttpGet("GetAssignedSuppliersByForms")]
        public IActionResult GetFormsAssignedSupplier(int formid)
        {
            return Ok(_mapper.Map<List<group_model>>(_service.GetSupplierByForms(formid)));
        }
        [HttpGet("GetUnAssignedSuppliersByForms")]
        public IActionResult GetFormsUnAssignedSupplier(int formid)
        {
            return Ok(_mapper.Map<List<group_model>>(_service.GetUnAssignedSupplierByForms(formid)));
        }
        [HttpPost("AssignSupplierToForms")]
        public IActionResult AssignSupplierForms(List<forms_assign_model_request> request)
        {
            ApiResponce responce = _service.AssignSuppliersToForm(request);
            return Ok(responce);
        }

        [HttpGet("GetFormDetails")]
        public IActionResult GetFormDetails(int formid)
        {
            return Ok(_mapper.Map<List<form_details_model>>(_service.GetAllFormDetails()));
        }
    }
}
