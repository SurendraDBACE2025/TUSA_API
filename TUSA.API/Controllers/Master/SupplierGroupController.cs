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
    public class SupplierGroupController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISupplierGroupService _service;

        public SupplierGroupController(IMapper mapper, ISupplierGroupService service)
        {
            _mapper = mapper;
            _service = service;
        }
 
        [Route("GetSuppliers/{supplierTypeId}")]
        [HttpGet]
        public IActionResult GetSuppliers(int supplierTypeId)
        {

            var list = _service.GetSuppliersList(supplierTypeId);
            return Ok(_mapper.Map<List<group_model>>(list));
        }
    }
}
