using System.Collections.Generic;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface IFormFieldService:IBaseService<field_master>
    {
        IEnumerable<field_master> GetFieldsByModule(int moduleId);
        IEnumerable<field_master> GetFieldsByForm(int formId);
        IEnumerable<field_master> GetFieldsByFormName(string formName);
    }
    class FormFieldService: BaseService<field_master>,IFormFieldService
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
    }
}
