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
    public interface IModuleService:IBaseService<module_master>
    {
        List<module_master> GetModules(string userId);
        module_master GetModulesById(int moduleId);
        
    }
    public class ModuleService : BaseService<module_master>,IModuleService
    {
        public ModuleService(IUnitOfWork uow) : base(uow)
        {

        }
        public List<module_master> GetModules(string userId)
        {
            List<module_master> modules = new List<module_master>();
            user_group_metrix user_Group_Metrix = _UOW.GetRepository<user_group_metrix>().Single(x => x.user_master.user_email_id == userId,
                 include: x => x.Include(x => x.group_master));
            List<group_form_access_matrix> forms = _UOW.GetRepository<group_form_access_matrix>().Get(x => x.group_id == user_Group_Metrix.group_master.group_id).ToList();
            foreach (group_form_access_matrix form in forms)
            {
               forms_master form_master = _UOW.GetRepository<forms_master>().Single(x => x.form_id == form.form_id,
                   include:x=>x.Include(x=>x.module_master));
                if (modules.Count == 0 || !modules.Any(x=>x.module_name== form_master.module_master.module_name))
                modules.Add(form_master.module_master);
            }
            return modules;
        }

        public module_master GetModulesById(int moduleId)
        {
            return _UOW.GetRepository<module_master>().Get(x=>x.module_id== moduleId).FirstOrDefault();

        }
    }
}
