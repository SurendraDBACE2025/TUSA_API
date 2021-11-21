using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using TUSA.Domain.Models.master;
using TUSA.Domain.Models.master.Request;
using TUSA.Service;
using TUSA.Service.Mail;

namespace TUSA.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierGroupController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISupplierGroupService _service;
        private readonly IMailService _mailService;

        public SupplierGroupController(IMapper mapper, ISupplierGroupService service,IMailService mailService)
        {
            _mapper = mapper;
            _service = service;
            _mailService = mailService;
        }
 
        [Route("GetSuppliers/{supplierTypeId}")]
        [HttpGet]
        public IActionResult GetSuppliers(int supplierTypeId)
        {

            var list = _service.GetSuppliersList(supplierTypeId);
            return Ok(_mapper.Map<List<group_model>>(list));
        }

        [Route("GetSuppliersByRole")]
        [HttpGet]
        public IActionResult GetSupplierName()
        {

            var list = _service.GetSupplier(base.UserId);
            return Ok(_mapper.Map<List<group_model>>(list));
        }
        [HttpPost("GroupAdd")]
        public IActionResult AddSupplier(group_creation_request request)
        {
            return Ok(_service.AddGroup(request));
        }

        
      
    }
}
