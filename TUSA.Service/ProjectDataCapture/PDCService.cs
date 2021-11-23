using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TUSA.Data;
using TUSA.Domain;
using TUSA.Domain.Entities;
using TUSA.Domain.Entities.Privileges;
using TUSA.Domain.Entities.QuickAndRecent;
using TUSA.Domain.Models;

namespace TUSA.Service
{
    public interface IPDCService : IBaseService<pdc_element_master>
    {
        List<pdc_element_master> GetPDCElementsList(int categoryId);
        List<pdc_element_master> GetPDCElementsByform(int formId);
        List<pdc_category_master> GetPDScopeCategoryList();
        List<pdc_header_data> GetPDCHeaderList();
        pdc_dataElements_details_model GetPDCElementsListForHeader(int HeaderID);
        ApiResponce SaveProjectDataHeader(pdc_data_Elements_request model, string UserId);
        IEnumerable<project_master> GetProjects();
        List<project_master> GetProjectsByRole(string user_Id);
    }
    public class PDCService : BaseService<pdc_element_master>, IPDCService
    {
        public PDCService(IUnitOfWork uow) : base(uow)
        {

        }
        public List<pdc_element_master> GetPDCElementsByform(int formId)
        {
            List<pdc_element_master> eleList = new List<pdc_element_master>();
            List<pdc_form_category_metrix> list = _UOW.GetRepository<pdc_form_category_metrix>().Get(x => x.form.form_id == formId,
                include:x=>x.Include(x=>x.category)).ToList();
            foreach (pdc_form_category_metrix item in list.OrderBy(x=>x.caotegory_order_no))
            {
                eleList.AddRange(_UOW.GetRepository<pdc_element_master>().Get(x => x.category.category_id== item.category.category_id && x.is_active == true,
                include: x => x.Include(x => x.category)).ToList());
            }
            return eleList;
        
        }
        public List<pdc_element_master> GetPDCElementsList(int categoryId)
        {
            return _UOW.GetRepository<pdc_element_master>().Get(x=>x.category.category_id== categoryId && x.is_active == true,
                include: x => x.Include(x => x.category)).OrderBy(o => o.category.category_id).ToList();
            
        }
        public List<pdc_category_master> GetPDScopeCategoryList()
        {
            return _UOW.GetRepository<pdc_category_master>().Get(x => x.is_active == true).OrderBy(o => o.category_id).ToList();
         
        }
        public List<pdc_header_data> GetPDCHeaderList()
        {
            var spList = _UOW.GetRepository<pdc_header_data>().Get().ToList();
          
            return spList;
        }

        public IEnumerable<project_master> GetProjects()
        {
            return _UOW.GetRepository<project_master>().Get(include: x => x.Include(x => x.country).ThenInclude(x=>x.continent)
            .Include(x => x.currency).ThenInclude(x=>x.country));
        }
        public List<project_master> GetProjectsByRole(string user_Id)
        {
            List<project_master> retunList = new List<project_master>();
            user_group_metrix user_Group_Metrix = _UOW.GetRepository<user_group_metrix>().Single(x => x.user_master_Id == user_Id);
            List<group_project_access_metrix> group_Form_Access_Matrix= _UOW.GetRepository<group_project_access_metrix>().Get(x => x.group_id == user_Group_Metrix.group_Id).ToList();
            foreach (group_project_access_metrix item in group_Form_Access_Matrix)
            {
                retunList.Add(_UOW.GetRepository<project_master>().Single(x=>x.project_id==item.project_id, include: x => x.Include(x => x.country).ThenInclude(x => x.continent)
                .Include(x => x.currency).ThenInclude(x => x.country)));
            }
            return retunList;
        }
        public pdc_dataElements_details_model GetPDCElementsListForHeader(int HeaderID)
        {
            pdc_dataElements_details_model pdcModelList = new pdc_dataElements_details_model();
            pdc_header_data model = _UOW.GetRepository<pdc_header_data>().Get(h => h.header_Id == HeaderID).FirstOrDefault();
            var supplier = _UOW.GetRepository<group_master>().Single(x=>x.group_id==Convert.ToInt32( model.supplier_group));
            pdcModelList.HeaderId = model.header_Id;
            pdcModelList.Currency = model.currency;
            pdcModelList.Country = model.country;
            pdcModelList.COD = model.cod;
            pdcModelList.GuranteedAvailability = model.guaranteed_availability;
            pdcModelList.GuranteedPerformance = model.guaranteed_perf_ratio;
            pdcModelList.InstalledCapicityAC = model.installed_capacity_ac;
            pdcModelList.MinimumPerformance = model.minimum_perf_ratio;
            pdcModelList.InstalledCapicityDC = model.installed_capacity_dc;
            pdcModelList.ProjectName = model.project_name;
            pdcModelList.ProjectYear = model.project_year;
            pdcModelList.SupplierGroup = supplier.display_name;
            pdcModelList.TotalProjectCost = model.total_project_cost;
            pdcModelList.Year1OnMPrice = model.year_1_onm_price;
            pdcModelList.Year1Yield = model.year_1_yield;
            pdcModelList.Year2OnMPrice = model.year_2_onm_price;

            var elementslist = _UOW.GetRepository <pdc_element_master>().Get(include:x=>x.Include(x=>x.category)).ToList();
            var elementsDataList = _UOW.GetRepository <pdc_project_element_data>().Get(h => h.header_Id == HeaderID).ToList();
            var categoryList = _UOW.GetRepository <pdc_category_master>().Get().ToList();

            List<pdc_elements_details_model> eleList = new List<pdc_elements_details_model>();
            foreach (pdc_element_master p in elementslist.OrderBy(o => o.category.category_id))
            {
                pdc_elements_details_model Elemodel = new pdc_elements_details_model();
              //Check here
                var ElemenDetails = elementsDataList.Where(o => o.element_Id == p.element_id).FirstOrDefault();
                var category = categoryList.Where(c => c.category_id == p.category.category_id).FirstOrDefault();

               // Elemodel.MasterId = p.master;
                Elemodel.HeaderId = HeaderID;
                if (ElemenDetails != null)
                {

                    Elemodel.Price = ElemenDetails.unit_cost;
                    Elemodel.Commentary = ElemenDetails.scope_commmentary;
                    Elemodel.ShareInTotal = ElemenDetails.share_in_total;
                    Elemodel.ModelType = ElemenDetails.modal_type;
                    Elemodel.TotalServiceHours = ElemenDetails.total_service_hours;
                    Elemodel.Qty = ElemenDetails.quantity;
                }
                else { }

                Elemodel.Category = category.category_id;
                Elemodel.CategoryName = category.category_name;
                Elemodel.Phase = p.phase;
               // Elemodel.Scope = p.scope;
                Elemodel.IsActive = p.is_active;
                Elemodel.Units = p.units;
                Elemodel.ServiceOrEquipment = p.service_or_equipment;


                eleList.Add(Elemodel);
            }
            pdcModelList.Elements = eleList;
            return pdcModelList;
        }

        public ApiResponce SaveProjectDataHeader(pdc_data_Elements_request model,string UserId)
        {
            var headerEntity = _UOW.GetRepository<pdc_header_data>().Get(o => o.header_Id == model.headerId && o.form_Id == model.form_id).FirstOrDefault(); ;
            try
            {
                forms_master forms_Master = _UOW.GetRepository<forms_master>().Single(x => x.form_id == model.form_id);
                if (headerEntity == null)
                {
                    headerEntity = new pdc_header_data
                    {
                        form_Id= forms_Master.form_id,
                        currency = model.currency,
                        country=model.country,
                        cod = model.cod,
                        guaranteed_availability = model.guranteedAvailability,
                        guaranteed_perf_ratio = model.guranteedPerfRation,
                        installed_capacity_ac = model.installedCapicityAC,
                        minimum_perf_ratio = model.minimumPerfRation,
                        installed_capacity_dc = model.installedCapicityDC,
                        project_name = model.project_name,
                        project_year = model.project_year,
                        supplier_group = model.supplier_group,
                        total_project_cost = model.total_project_cost,
                        year_1_onm_price = model.year1OnmPrice,
                        year_1_yield = model.year1Yield,
                        year_2_onm_price = model.year2OnmPrice
                    };
                    _UOW.BeginTrans();
                    _UOW.GetRepository<pdc_header_data>().Add(headerEntity);
                    _UOW.SaveChanges();
                    foreach (var element in model.Elements.Where(e => e.unitcost != null))
                    {
                        //   var Pdc_element = _UOW.GetRepository<pdc_element_master>().Single(x => x.element_id == element.elementid);
                        var entity = new pdc_project_element_data
                        {
                            header_Id = headerEntity.header_Id,
                            element_Id = element.elementid,
                            unit_cost = element.unitcost,
                            scope_commmentary = element.scopecommentary,
                            share_in_total = element.shareInTotal == null ? 0 : element.shareInTotal,
                            modal_type = element.modelType,
                            quantity = element.quantity,
                            total_service_hours = element.totalServiceHours == null ? 0 : element.totalServiceHours,

                        };
                        _UOW.GetRepository<pdc_project_element_data>().Add(entity);

                    }
                    _UOW.SaveChanges();
                    _UOW.CommitTrans();

                    try
                    {
                        form_details fd=_UOW.GetRepository<form_details>().Get(x => x.form_id == model.form_id).FirstOrDefault();
                        recently_accessed_screens screen = _UOW.GetRepository<recently_accessed_screens>().Get(x => x.form_details_id == fd.id && x.user_master_Id == UserId).FirstOrDefault();
                        if (screen == null)
                        {
                            screen = new recently_accessed_screens()
                            {
                                user_master_Id = UserId,
                                form_details_id = fd.id,
                                last_accessed = DateTime.Now,
                                created_by = UserId,
                                created_date = DateTime.Now
                            };
                            _UOW.GetRepository<recently_accessed_screens>().Add(screen);
                            _UOW.SaveChanges();
                        }
                        else
                        {
                            screen.last_accessed = DateTime.Now;
                            screen.modified_by = UserId;
                            screen.modified_date = DateTime.Now;
                            _UOW.GetRepository<recently_accessed_screens>().Update(screen);
                            _UOW.SaveChanges();
                        }
                    }
                    catch { }
                }
            }
            catch (Exception Ex)
            {
                return new ApiResponce() { Status = false,Message=Ex.Message,ErrorType=false };
            }
            return new ApiResponce() { Status = true, Message ="", ErrorType = true };
        }

    }
}
