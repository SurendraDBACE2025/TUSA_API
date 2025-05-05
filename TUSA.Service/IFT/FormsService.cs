using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSA.Data;
using TUSA.Domain;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.QuickAndRecent;
using TUSA.Domain.Models.IFT.Request;

namespace TUSA.Service
{
    public interface IFormsService : IBaseService<forms_master>
    {
        List<forms_master> GetFormsBasedoOnModule(int moduleId, string userId);
        List<forms_master> GetFormsBasedoOnRole(string userId);
        List<forms_master> GetSupplierAssignedForms(int supplierId);
        List<forms_master> GetSupplierUnAssignedForms(int supplierId);
        List<form_details> GetInCompleteForms();
        List<form_details> GetAllFormDetails();
        IEnumerable<forms_master> GetForms();
        IEnumerable<form_type_master> GetFormTypes();
        forms_master GetFormsWithId(int formId);
        forms_master GetFormsWithformName(string formName);
        ApiResponce AssignFormsToSupplier(List<forms_assign_model_request> request);
        List<group_master> GetSupplierByForms(int formId);
        List<group_master> GetUnAssignedSupplierByForms(int formId);
        ApiResponce AssignSuppliersToForm(List<forms_assign_model_request> request);
        List<forms_master> GetMasterForms(string UserId, string? menuItem);
    }
    public class FormsService : BaseService<forms_master>, IFormsService
    {
        public FormsService(IUnitOfWork uow) : base(uow)
        {

        }
        public List<forms_master> GetFormsBasedoOnRole(string userId)
        {
            // List<form_details> returnlist = new List<form_details>();
            List<forms_master> returnlist = new List<forms_master>();
            user_group_metrix user_Group_Metrix = _UOW.GetRepository<user_group_metrix>().Single(x => x.user_master_Id == userId);
            group_master group_Master = _UOW.GetRepository<group_master>().Single(g => g.group_id == user_Group_Metrix.group_Id);
            List<group_form_access_metrix> forms = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == user_Group_Metrix.group_Id).ToList();
            List<forms_master> forms_List = _UOW.GetRepository<forms_master>().Get().ToList();
            // List<form_details> forms_details = _UOW.GetRepository<form_details>().Get().ToList();
            foreach (group_form_access_metrix form in forms)
            {
                if (form.form_id == 0)
                {
                    // returnlist.AddRange(forms_details);
                    returnlist.AddRange(forms_List);
                }
                else
                {
                    //if (forms_details.Any(x => x.form_id == form.form_id))
                    //    returnlist.Add(forms_details.Single(x => x.form_id == form.form_id));
                    if (forms_List.Any(x => x.form_id == form.form_id && x.module_id < 4))
                        returnlist.Add(forms_List.Single(x => x.form_id == form.form_id));
                }
            }
            return returnlist;
        }
        public List<forms_master> GetFormsBasedoOnModule(int moduleId, string userId)
        {
            List<forms_master> returnlist = new List<forms_master>();
            user_group_metrix user_Group_Metrix = _UOW.GetRepository<user_group_metrix>().Single(x => x.user_master_Id == userId);
            List<group_form_access_metrix> forms = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == user_Group_Metrix.group_Id).ToList();
            List<forms_master> forms_List = _UOW.GetRepository<forms_master>().Get(x => x.module.module_id == moduleId).OrderBy(x => x.form_name).ToList();
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
        public IEnumerable<form_type_master> GetFormTypes()
        {
            return _UOW.GetRepository<form_type_master>().Get();
        }
        public forms_master GetFormsWithId(int formId)
        { return _UOW.GetRepository<forms_master>().Single(x => x.form_id == formId); }

        public forms_master GetFormsWithformName(string formName)
        { return _UOW.GetRepository<forms_master>().Single(x => x.form_name == formName); }

        public List<form_details> GetInCompleteForms()
        {
            List<form_details> returnlist = new List<form_details>();
            foreach (forms_master master in _UOW.GetRepository<forms_master>().Get().ToList())
            {
                if (!_UOW.GetRepository<form_details>().Get().Any(x => x.form_id == master.form_id))
                {
                    returnlist.Add(new form_details() { form_id = master.form_id,
                        form_name = master.form_name });
                }
            }
            return returnlist;
        }

        public List<form_details> GetAllFormDetails()
        {
            return _UOW.GetRepository<form_details>().Get().ToList();
        }
        public List<forms_master> GetSupplierAssignedForms(int supplierId)
        {
            List<forms_master> returnlist = new List<forms_master>();
            List<group_form_access_metrix> forms = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == supplierId && x.is_active == "Yes").ToList();
            List<forms_master> forms_List = _UOW.GetRepository<forms_master>().Get().ToList();
            // List<form_details> forms_details = _UOW.GetRepository<form_details>().Get().ToList();
            foreach (group_form_access_metrix form in forms)
            {
                if (forms_List.Any(x => x.form_id == form.form_id))
                    returnlist.Add(forms_List.Where(x => x.form_id == form.form_id).FirstOrDefault());
            }
            return returnlist;
        }
        public List<forms_master> GetSupplierUnAssignedForms(int supplierId)
        {
            List<forms_master> returnlist = new List<forms_master>();
            List<group_form_access_metrix> forms = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == supplierId && x.is_active == "Yes").ToList();
            List<forms_master> forms_List = _UOW.GetRepository<forms_master>().Get().ToList();
            // List<form_details> forms_details = _UOW.GetRepository<form_details>().Get().ToList();

            foreach (forms_master form in forms_List)
            {
                if (!forms.Any(x => x.form_id == form.form_id))
                {
                    //   form_details formdetls = forms_details.Where(x => x.form_id == form.form_id).FirstOrDefault();
                    returnlist.Add(form);
                }
            }
            return returnlist;
        }

        public ApiResponce AssignFormsToSupplier(List<forms_assign_model_request> request)
        {
            if (request == null || (request != null && !request.Any()))
                return new ApiResponce() { Status = false, Message = "No changes were made", ErrorType = false };
            try
            {                
                foreach (forms_assign_model_request item in request)
                {
                    List<group_form_access_metrix> metrixs = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == item.group_id && x.form_id == item.form_id).ToList();
                    if (item.Action.Equals("Add"))
                    {
                        if (!metrixs.Any(x => x.form_id == item.form_id && x.group_id == item.group_id))
                        {
                            _UOW.GetRepository<group_form_access_metrix>().Add(new group_form_access_metrix() { form_id = item.form_id, group_id = item.group_id, is_active = "Yes" });
                        }
                    }
                    else if (item.Action.Equals("Remove"))
                    {
                        if (request.Any(x => x.form_id == item.form_id && x.group_id == item.group_id))
                        {
                            group_form_access_metrix fam = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == item.group_id && x.form_id == item.form_id).FirstOrDefault();
                            //item.is_active = "No";
                            _UOW.GetRepository<group_form_access_metrix>().Delete(fam);
                        }
                    }
                }

                _UOW.SaveChanges();
            }

            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }

            return new ApiResponce() { Status = true, Message = "", ErrorType = false };

        }
        public List<forms_master> GetMasterForms(string UserId, string? menuItem)
        {
            List<string> requiredModules = new List<string>() { "Master Forms", "Manage Suppliers" };           
            List<forms_master> returnlist = new List<forms_master>();
            List<module_master> module_Masters = _UOW.GetRepository<module_master>().Get(m => requiredModules.Contains(m.module_name)).ToList();
            List<forms_master> forms = _UOW.GetRepository<forms_master>().Get(x => x.module.module_id == 4).ToList();            
            user_group_metrix ugm = _UOW.GetRepository<user_group_metrix>().Single(x => x.user_master_Id == UserId);
            group_master group = _UOW.GetRepository<group_master>().Single(x => x.group_id == ugm.group_Id);
            List<group_form_access_metrix> group_Form_Access_Metrix = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == ugm.group_Id).ToList();
            List<group_type_master> gtmList = _UOW.GetRepository<group_type_master>().Get().ToList();
            if (gtmList.Any(x => x.group_type_id == group.group_type_id && x.group_type_name == "SUPPLIER"))
            {
                forms = _UOW.GetRepository<forms_master>().Get(x => module_Masters.Select(mm => mm.module_id).ToList().Contains(x.module.module_id) && group_Form_Access_Metrix.Select(ga => ga.form_id).ToList().Contains(x.form_id)).ToList(); // && x.form_name== "User Registration").ToList();
            }
            else if (gtmList.Any(x => x.group_type_id == group.group_type_id && (x.group_type_name != "SUPPLIER")))// || x.group_type_name == "SUPPER ADMIN")))
            {
                int requiredModuleId = (!string.IsNullOrEmpty(menuItem) && menuItem.ToUpper().Equals("MS")) ?
                    module_Masters.Single(mm => mm.module_name.Equals("Manage Suppliers")).module_id
                    : module_Masters.Single(mm => mm.module_name.Equals("Master Forms")).module_id;
                forms = _UOW.GetRepository<forms_master>().Get(x => x.module.module_id == requiredModuleId).ToList();
            }

            List<forms_master> forms_details = _UOW.GetRepository<forms_master>().Get().ToList();
            foreach (forms_master form in forms)
            {
                if (forms_details.Any(x => x.form_id == form.form_id))
                {
                     returnlist.Add(forms_details.Where(x => x.form_id == form.form_id).FirstOrDefault());
                }
            }
            return returnlist;
        }
        public List<group_master> GetSupplierByForms(int formId) {
            List<group_master> returnlist = new List<group_master>();
            List<group_form_access_metrix> forms = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.form_id == formId && x.is_active == "Yes").ToList();
            List<group_master> group_List = _UOW.GetRepository<group_master>().Get(x=>x.group_type_id==3).ToList();
            foreach (group_form_access_metrix form in forms)
            {
                if (group_List.Any(x => x.group_id == form.group_id) && !returnlist.Any(x => x.group_id == form.group_id))
                    returnlist.Add(group_List.Where(x => x.group_id == form.group_id).FirstOrDefault());
            }
            return returnlist;
        }
        public List<group_master> GetUnAssignedSupplierByForms(int formId) {

            List<group_master> returnlist = new List<group_master>();
            List<group_form_access_metrix> groups = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.form_id == formId && x.is_active == "Yes").ToList();
            List<group_master> group_List = _UOW.GetRepository<group_master>().Get(x => x.group_type_id == 3).ToList();

            foreach (group_master group in group_List)
            {

                if (!groups.Any(x => x.group_id == group.group_id))
                {
                    //   form_details formdetls = forms_details.Where(x => x.form_id == form.form_id).FirstOrDefault();
                    returnlist.Add(group);
                }
            }
            return returnlist;
        }
        public ApiResponce AssignSuppliersToForm(List<forms_assign_model_request> request)
        {
            if (request == null || (request != null && !request.Any()))
                return new ApiResponce() { Status = false, Message = "No changes were made", ErrorType = false };

            try
            {               
                
                foreach (forms_assign_model_request item in request)
                {
                    List<group_form_access_metrix> metrixs = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == item.group_id && x.form_id == item.form_id).ToList();
                    if (item.Action.Equals("Add"))
                    {
                        if (!metrixs.Any(x => x.form_id == item.form_id && x.group_id == item.group_id))
                        {
                            _UOW.GetRepository<group_form_access_metrix>().Add(new group_form_access_metrix() { form_id = item.form_id, group_id = item.group_id, is_active = "Yes" });
                        }
                    }
                    else if(item.Action.Equals("Remove"))
                    {
                        if (request.Any(x => x.form_id == item.form_id && x.group_id == item.group_id))
                        {
                            group_form_access_metrix fam = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == item.group_id && x.form_id == item.form_id).FirstOrDefault();
                            //item.is_active = "No";
                            _UOW.GetRepository<group_form_access_metrix>().Delete(fam);
                        }
                    }
                }
                _UOW.SaveChanges();
                //foreach (group_form_access_metrix item in metrixs)
                //{
                //    if (request.Any(x => x.form_id == item.form_id && x.group_id == item.group_id))
                //    {
                //        group_form_access_metrix fam = _UOW.GetRepository<group_form_access_metrix>().Get(x => x.group_id == item.group_id && x.form_id == item.form_id).FirstOrDefault();
                //        //item.is_active = "No";
                //        _UOW.GetRepository<group_form_access_metrix>().Delete(fam);
                //    }
                //}
                //_UOW.SaveChanges();
            }

            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false, Message = Ex.Message, ErrorType = false };
            }

            return new ApiResponce() { Status = true, Message = "", ErrorType = false };

        }
    }
}
