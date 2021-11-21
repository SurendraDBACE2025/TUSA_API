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
        List<forms_master> GetFormsBasedoOnModule(int moduleId, string userId);
        IEnumerable<forms_master> GetForms();

        forms_master GetFormsWithId(int formId);

        forms_master GetFormsWithformName(string formName);
    }
    public class FormsService : BaseService<forms_master>,IFormsService
    {
        public FormsService(IUnitOfWork uow) : base(uow)
        {

        }
        public List<forms_master> GetFormsBasedoOnModule(int moduleId,string userId)
        {
            List<forms_master> returnlist = new List<forms_master>();
           user_group_metrix user_Group_Metrix = _UOW.GetRepository<user_group_metrix>().Single(x => x.user_master_Id == userId);
            List<group_form_access_metrix> forms = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == user_Group_Metrix.group_Id).ToList();
            List< forms_master> forms_List=_UOW.GetRepository<forms_master>().Get(x => x.module.module_id == moduleId).OrderBy(x => x.form_name).ToList();
            foreach (group_form_access_metrix form in forms)
            {
                if (forms_List.Any(x => x.form_id == form.form_id))
                    returnlist.Add(forms_List.Single(x => x.form_id == form.form_id));
            }
            return returnlist;
        }
        public IEnumerable<forms_master> GetForms()
        {
            return _UOW.GetRepository<forms_master>().Get(
                include: x => x.Include(x => x.module));
        }
        public forms_master GetFormsWithId(int formId)
        { return _UOW.GetRepository<forms_master>().Single(x => x.form_id == formId); }

        public forms_master GetFormsWithformName(string formName)
        { return _UOW.GetRepository<forms_master>().Single(x => x.form_name == formName); }
    }
}
