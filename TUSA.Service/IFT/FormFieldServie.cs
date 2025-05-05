using System;
using System.Linq;
using System.Collections.Generic;
using TUSA.Core;
using TUSA.Data;
using TUSA.Domain.Entities;
using TUSA.Domain.Models.IFT.Request;
using TUSA.Domain.Models.IFT.Response;
using TUSA.Domain.Models.master;
using Microsoft.EntityFrameworkCore;

namespace TUSA.Service
{
    public interface IFormFieldService : IBaseService<field_master>
    {
        IEnumerable<field_master> GetFieldsByModule(int moduleId);
        IEnumerable<field_master> GetFieldsByForm(int formId);
        IEnumerable<field_master> GetFieldsByFormName(string formName);
        IEnumerable<form_subtitle_field_metrix> GetAllFields();
        FieldFormModuleMappingResponse MapFieldsToModule(FieldFormModuleMappingRequest request);
        string GetFormName(int formId);
    }
    public class FormFieldService : BaseService<field_master>, IFormFieldService
    {
        IApplicationUser _applicationUser;
        public FormFieldService(IUnitOfWork uow, IApplicationUser applicationUser) : base(uow)
        {
            _applicationUser = applicationUser;
        }

        public IEnumerable<field_master> GetFieldsByModule(int moduleId)
        {
            return _UOW.GetRepository<field_master>().Get();
        }
        public IEnumerable<field_master> GetFieldsByForm(int formId)
        {
            var formName = _UOW.GetRepository<forms_master>().Single(f => f.form_id == formId).form_name;
            List<form_field_metrix> form_Field_Metrix = _UOW.GetRepository<form_field_metrix>().Get(f => f.form_name == formName).ToList();
            return _UOW.GetRepository<field_master>().Get(f => form_Field_Metrix.Select(f => f.field_id).ToList().Contains(f.field_id.ToString())); 
        }
        public string GetFormName(int formId)
        {
            return _UOW.GetRepository<forms_master>().Single(f => f.form_id == formId).form_name;            
        }
        public IEnumerable<field_master> GetFieldsByFormName(string formName)
        { return _UOW.GetRepository<field_master>().Get(); }

        public IEnumerable<form_subtitle_field_metrix> GetAllFields()
        {
            // List<fields_model> allFields = new List<fields_model>();
            return _UOW.GetRepository<form_subtitle_field_metrix>()
                //.Get(f => f.is_active == "Yes")                
                .Get(f => f.is_active == "Yes",
                include: x => x
                .Include(x => x.field)
                .Include(x=>x.subtitle))
                .ToList();            
        }
        public FieldFormModuleMappingResponse MapFieldsToModule(FieldFormModuleMappingRequest request)
        {
            FieldFormModuleMappingResponse response = new FieldFormModuleMappingResponse();
            try
            {
                // Get the form if already exists with the given name
                var isFormExists = _UOW.GetRepository<forms_master>().Single(fm=> fm.form_name.ToUpper().Equals(request.form_name.ToUpper()));

                // Validate thr formname and return error message to choose different form name
                if (isFormExists != null)
                {
                    response.StatusCode = 500;
                    response.Message = "Error : Form Name Already Exists. Please Use Different Form Name.";
                    response.IsErrorEncountered = true;
                    return response;
                }

                // Add the new form
                _UOW.GetRepository<forms_master>().Add(
                    new forms_master()
                    {
                        form_type_id = request.form_type_id,
                        form_name = request.form_name,
                        form_desc = request.form_desc,
                        created_date = DateTime.Now,
                        created_by = (_applicationUser.UserId == "" ? "" : _applicationUser.UserId),
                        modified_date = DateTime.Now,
                        modified_by = _applicationUser.UserId == "" ? "" : _applicationUser.UserId,
                        is_active = "Yes",
                        module_id = request.module_id,
                        link = string.Format("/tusa/master-screens/{0}", request.form_name.Replace(" ","").Replace("'",""))
                    }
                    ); 

                _UOW.SaveChanges();                

                // Map the fields to the given module
                foreach (var fieldItem in request.field_details)
                {
                    if (_UOW.GetRepository<form_field_metrix>().Single(ffm => ffm.form_name.ToUpper().Equals(request.form_name.ToUpper()) && ffm.field_id == fieldItem.field_id && ffm.module_id == request.module_id) != null) continue;
                    _UOW.GetRepository<form_field_metrix>().Add(
                        new form_field_metrix()
                        {
                            form_name = request.form_name,
                            module_id = request.module_id,
                            field_id = fieldItem.field_id,
                            field_order = fieldItem.field_order,
                            created_date = DateTime.Now,
                            created_by = (_applicationUser.UserId == "" ? "" : _applicationUser.UserId),
                            modified_date = DateTime.Now,
                            modified_by = _applicationUser.UserId == "" ? "" : _applicationUser.UserId,
                            is_active = "Yes",
                            nullable = "Yes",
                            comments_available = "No",
                            field_design_type = "Text"
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
                response.IsErrorEncountered = true;
            }
            return response;
        }
    }
}
