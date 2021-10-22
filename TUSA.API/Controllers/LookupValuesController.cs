
using AutoMapper;
using TUSA.Domain.Models;
using TUSA.Service;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupValuesController : BaseController
    { 
        private readonly IMapper _mapper;
        private readonly ILookupService _service;
        public LookupValuesController(IMapper mapper, ILookupService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public LookUpValues Post(LookUpValues model)
        { 
            return _mapper.Map<LookUpValues>(_service.Add(_mapper.Map<Domain.Entities.LookUpValues>(model)));
        }
        
        [HttpGet("{code}")]
        public IEnumerable<LookUpValues> Get(string code)
        {
            return _mapper.Map<List<LookUpValues>>(_service.Search(code));
        }
    }
}
