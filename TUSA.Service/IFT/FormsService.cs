using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain.Entities;

namespace TUSA.Service
{
    public interface IFormsService : IBaseService<forms_master>
    {
        IEnumerable<forms_master> GetFormsBasedoOnModule(int moduleId);
        IEnumerable<forms_master> GetForms();

        forms_master GetFormsWithId(int formId);

        forms_master GetFormsWithformName(string formName);
    }
    public class FormsService : BaseService<forms_master>,IFormsService
    {
        public FormsService(IUnitOfWork uow) : base(uow)
        {

        }
        public IEnumerable<forms_master> GetFormsBasedoOnModule(int moduleId)
        {
            return _UOW.GetRepository<forms_master>().Get(x => x.module_master.module_id == moduleId).OrderBy(x => x.form_name);
        }
        public IEnumerable<forms_master> GetForms()
        {
            return _UOW.GetRepository<forms_master>().Get(
                include: x => x.Include(x => x.module_master));
        }
        public forms_master GetFormsWithId(int formId)
        { return _UOW.GetRepository<forms_master>().Single(x => x.form_id == formId); }

        public forms_master GetFormsWithformName(string formName)
        { return _UOW.GetRepository<forms_master>().Single(x => x.form_name == formName); }
    }
}
