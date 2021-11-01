using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TUSA.Data;
using TUSA.Domain.Entities;
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
        int SaveProjectDataHeader(pdc_data_Elements_request model);
        //void SaveProjectData(int headerId, List<pdc_projectData_request> elements);
        IEnumerable<project_master> GetProjects();
    }
    public class PDCService : BaseService<pdc_element_master>, IPDCService
    {
        public PDCService(IUnitOfWork uow) : base(uow)
        {

        }
        public List<pdc_element_master> GetPDCElementsByform(int formId)
        {
            List<pdc_element_master> eleList = new List<pdc_element_master>();
            List<pdc_form_category_matrix> list = _UOW.GetRepository<pdc_form_category_matrix>().Get(x => x.forms_master.form_id == formId,
                include:x=>x.Include(x=>x.pdc_category_master)).ToList();
            foreach (pdc_form_category_matrix item in list.OrderBy(x=>x.caotegory_order_no))
            {
                eleList.AddRange(_UOW.GetRepository<pdc_element_master>().Get(x => x.pdc_category_master.category_id== item.pdc_category_master.category_id && x.is_active == true,
                include: x => x.Include(x => x.pdc_category_master)).ToList());
            }
            return eleList;
        
        }
        public List<pdc_element_master> GetPDCElementsList(int categoryId)
        {
            return _UOW.GetRepository<pdc_element_master>().Get(x=>x.pdc_category_master.category_id== categoryId && x.is_active == true).OrderBy(o => o.pdc_category_master.category_id).ToList();
            
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
            return _UOW.GetRepository<project_master>().Get(include: x => x.Include(x => x.country).Include(x => x.currency));
        }
        public pdc_dataElements_details_model GetPDCElementsListForHeader(int HeaderID)
        {
            pdc_dataElements_details_model pdcModelList = new pdc_dataElements_details_model();
            pdc_header_data model = _UOW.GetRepository<pdc_header_data>().Get(h => h.header_Id == HeaderID).FirstOrDefault();

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
            pdcModelList.SupplierGroup = model.supplier_group;
            pdcModelList.TotalProjectCost = model.total_project_cost;
            pdcModelList.Year1OnMPrice = model.year_1_onm_price;
            pdcModelList.Year1Yield = model.year_1_yield;
            pdcModelList.Year2OnMPrice = model.year_2_onm_price;

            var elementslist = _UOW.GetRepository <pdc_element_master>().Get().ToList();
            var elementsDataList = _UOW.GetRepository <pdc_project_element_data>().Get(h => h.header.header_Id == HeaderID).ToList();
            var categoryList = _UOW.GetRepository <pdc_category_master>().Get().ToList();

            List<pdc_elements_details_model> eleList = new List<pdc_elements_details_model>();
            foreach (pdc_element_master p in elementslist.OrderBy(o => o.pdc_category_master.category_id))
            {
                pdc_elements_details_model Elemodel = new pdc_elements_details_model();
              //Check here
                var ElemenDetails = elementsDataList.Where(o => o.header.header_Id == p.element_id).FirstOrDefault();
                var category = categoryList.Where(c => c.category_id == p.pdc_category_master.category_id).FirstOrDefault();

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

        public int SaveProjectDataHeader(pdc_data_Elements_request model)
        {
            var headerEntity = _UOW.GetRepository<pdc_header_data>().Get(o => o.header_Id == model.headerId && o.forms_master.form_id == model.form_id).FirstOrDefault(); ;
            try
            {
               
                if (headerEntity == null)
                {
                    headerEntity = new pdc_header_data
                    {
                        forms_masterform_id = 12,
                        currency = model.currency,
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
                    foreach (var element in model.Elements.Where(e => e.unitcost != null))
                    {
                        //   var Pdc_element = _UOW.GetRepository<pdc_element_master>().Single(x => x.element_id == element.elementid);
                        var entity = new pdc_project_element_data
                        {
                            header = headerEntity,
                            elementelement_id = element.elementid,
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
                    //_UOW.GetRepository<pdc_header_data>().Add(entity);

                }
            }
            catch (Exception Ex)
            {
                return 0;
            }
            return headerEntity.header_Id;
        }

       // public void SaveProjectData(int headerId, List<pdc_projectData_request> elements)
//        {
//            using (TransactionScope scope = new TransactionScope())
//            {
//                foreach (var element in elements.Where(e => e.unitcost != null))
//                {
//                    var entity = _UOW.GetRepository<pdc_project_element_data>().Get(o => o.header.header_Id == headerId).FirstOrDefault();
//                    if (entity == null)
//                    {
//                        entity = new pdc_project_element_data
//                        {
//                            header_id = headerId,
//                            element_id=element.elementid,
//                            unit_cost = element.unitcost,
//                            scope_commmentary = element.scopecommentary,
//                            share_in_total =0,// element.shareInTotal,
//                            modal_type = element.modelType,
//                            quantity = element.quantity,
//                            total_service_hours =0,// element.totalServiceHours
//                            created_by= "hari@testmail.com"

//                        };
//    _UOW.GetRepository<pdc_project_element_data>().Add(entity);
//}
//                }
//                _UOW.SaveChanges();
//scope.Complete();
//            }
//        }

    }
}
