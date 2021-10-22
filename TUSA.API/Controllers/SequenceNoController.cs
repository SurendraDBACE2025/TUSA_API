using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TUSA.Data.Paging;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using TUSA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequenceNoController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISequenceNoService _service;
        public SequenceNoController(IMapper mapper, ISequenceNoService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_mapper.Map<IEnumerable<SequenceNoModel>>(_service.GetList("")));
        }

        [HttpPut]
        public IActionResult Put(List<SequenceNoModel> model)
        {
            List<SequenceNo> sequenceNos = _mapper.Map<List<SequenceNo>>(model);
            return Ok(_mapper.Map<List<SequenceNo>>(_service.UpdateRange(sequenceNos)));
        }
    }
}