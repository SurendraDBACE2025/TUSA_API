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

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickAndRecentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IQuickAndRecentService _service;

        public QuickAndRecentController(IMapper mapper, IQuickAndRecentService service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("RecentScreens")]
        public IActionResult GetRecetScreens()
        {
            var list = _service.GetRecentAccessesScreens(base.UserId);
            return Ok(_mapper.Map<List<recently_accessed_screens_model>>(list));
        }

        [HttpGet("QuickAccessableScreens")]
        public IActionResult GetQuickAccessableScreens()
        {
            return Ok(_mapper.Map<List<quick_access_screens_model>>(_service.GetQuickAccessesScreens(base.UserId)));
        }
    }
}
