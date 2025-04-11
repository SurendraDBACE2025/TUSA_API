using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUSA.Core.Result;
using TUSA.Domain.Models;
using TUSA.Service;

namespace TUSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDCController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IPDCService _service;

        public PDCController(IMapper mapper, IPDCService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [Route("GetPDCElements")]
        [HttpGet]
        public IActionResult GetPDCElementsList(int categoryId)
        {
          var list = _service.GetPDCElementsList(categoryId);
          return Ok(_mapper.Map<List<pdc_element_model>>(list));
        }
        [Route("GetPDCElementsByForm")]
        [HttpGet]
        public IActionResult GetPDCElementsByForm(int formId)
        {
            var list = _service.GetPDCElementsByform(formId);
            List<pdc_element_model> modellist = _mapper.Map<List<pdc_element_model>>(list);
            pdc_element_category_model returnModel = new pdc_element_category_model();
            returnModel.pdc_element_model = modellist;
            returnModel.pdc_category_model = new List<pdc_category_model>();
            
            foreach (Domain.Entities.pdc_element_master item in list)
            {
                if(!returnModel.pdc_category_model.Any(x=>x.category_id==item.category.category_id))
                    returnModel.pdc_category_model.Add(new pdc_category_model()
                    {
                        category_id = item.category.category_id,
                        category_name = item.category.category_name
                    });
            }
            return Ok(returnModel);
        }

        [Route("GetPDCScopeCategory")]
        [HttpGet]
        public IActionResult GetPDCScopeCategoryList()
        {
            var list = _service.GetPDScopeCategoryList();
            return Ok(_mapper.Map<List<pdc_category_model>>(list));
        }

        [Route("GetPDCHeadersList")]
        [HttpGet]
        public IActionResult GetPDCHeadersList()
        {
            var list = _service.GetPDCHeaderList();
            return Ok(_mapper.Map<List<pdc_header_model>>(list));
        }

        [Route("GetPDCElementsList")]
        [HttpGet]
        public IActionResult GetPDCElementsListForHeader(int HeaderID)
        {
            var list = _service.GetPDCElementsListForHeader(HeaderID);
            return Ok(list);
              
        }

        [HttpPost]
        [Route("SaveUpdate")]
        public IActionResult Save(pdc_data_Elements_request record)
        {
          return Ok(_service.SaveProjectDataHeader(record,base.UserId));
        }

        [Route("GetProjects")]
        [HttpGet]
        public IActionResult GetProjects()
        {
            var list = _service.GetProjects();
            return Ok(_mapper.Map<List<project_model>>(list));

        }


        [Route("GetProjectsByRole")]
        [HttpGet]
        public IActionResult GetProjectsByRole()
        {
            var list = _service.GetProjectsByRole(base.UserId);
            return Ok(_mapper.Map<List<project_model>>(list));

        }


    }
}
