using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TUSA.Domain.Models;
using TUSA.Service;

namespace TUSA.API.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyMasterController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly ICurrencyMasterService _service;

        public CurrencyMasterController(IMapper mapper, ICurrencyMasterService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("GetList")]
        public IActionResult GetCurrencyList()
        {

            var list = _service.GetCurrencyList();
            return Ok(_mapper.Map<List<currency_model>>(list));
        }
        [HttpGet("GetListByCode")]
        public IActionResult GetCurrencyList(string currencyCode)
        {

            var list = _service.GetCurrencyListByCode(currencyCode);
            return Ok(_mapper.Map<List<currency_model>>(list));
        }
        [HttpGet("GetListByCountryCode")]
        public IActionResult GetCurrencyListByCountry(string countryCode)
        {
            var list = _service.GetCurrencyListByCountryCode(countryCode);
            return Ok(_mapper.Map<List<currency_model>>(list));
        }
    }

}
