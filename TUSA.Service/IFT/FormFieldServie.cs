using System;
using System.Collections.Generic;
using TUSA.Data;
using TUSA.Domain.Entities;
using TUSA.Domain.Models.IFT.Request;
using TUSA.Domain.Models.IFT.Response;

namespace TUSA.Service
{
    public interface IFormFieldService : IBaseService<field_master>
    {
        IEnumerable<field_master> GetFieldsByModule(int moduleId);
        IEnumerable<field_master> GetFieldsByForm(int formId);
        IEnumerable<field_master> GetFieldsByFormName(string formName);
        IEnumerable<field_master> GetAllFields();
        FieldFormModuleMappingResponse MapFieldsToiModule(FieldFormModuleMappingRequest request);
    }
    public class FormFieldService : BaseService<field_master>, IFormFieldService
    {
        public FormFieldService(IUnitOfWork uow) : base(uow)
        {

        }

        public IEnumerable<field_master> GetFieldsByModule(int moduleId)
        {
            return _UOW.GetRepository<field_master>().Get();
        }
        public IEnumerable<field_master> GetFieldsByForm(int formId)
        { return _UOW.GetRepository<field_master>().Get(); }
        public IEnumerable<field_master> GetFieldsByFormName(string formName)
        { return _UOW.GetRepository<field_master>().Get(); }

        public IEnumerable<field_master> GetAllFields()
        {
            return _UOW.GetRepository<field_master>().GetAllList("");
        }
        public FieldFormModuleMappingResponse MapFieldsToiModule(FieldFormModuleMappingRequest request)
        {
            FieldFormModuleMappingResponse response = new FieldFormModuleMappingResponse();
            try
            {
                foreach (var fieldItem in request.field_details)
                {
                    _UOW.GetRepository<form_field_metrix>().Add(
                        new form_field_metrix()
                        {
                            form_name = request.form_id.ToString(),
                            module_id = request.module_id,
                            field_id = fieldItem.field_id,
                            field_order = fieldItem.field_order
                        }
                        );
                }
                _UOW.SaveChanges();
                response.StatusCode = 200;
                response.Message = "Mapping Successful";
                response.IsErrorEncountered = false;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = "Error Encountered : " + ex.Message;
                response.IsErrorEncountered = false;
            }
            return response;
        }
    }
}
