using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Domain.Entities;
using TUSA.Domain.Models;
using TUSA.Domain.Models.QuickAndRecent;
using TUSA.Domain.Models.QuickAndRecent.Request;
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
            return Ok(_mapper.Map<List<form_details_model>>(list));
        }

        [HttpGet("QuickAccessableScreens")]
        public IActionResult GetQuickAccessableScreens()
        {
            return Ok(_mapper.Map<List<form_details_model>>(_service.GetQuickAccessesScreens(base.UserId)));
        }
        [HttpPost("QuickAccessable")]
        public IActionResult AddQuickAccessablescreen(QuickAccessScreenAddRequest request)
        {
            return Ok(_service.AddQuickAccessesScreens(request,base.UserId));
        }

        [HttpPost("AddFormDetails")]
        public IActionResult AddFormDetails(form_details_request request)
        {
            return Ok(_service.AddformDetails(request, base.UserId));
        }
    }
}
