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
        List<pdc_element_master> GetPDCElementsList(int category);
        List<pdc_category_master> GetPDScopeCategoryList();
        List<pdc_header_data> GetPDCHeaderList();
        pdc_dataElements_details_model GetPDCElementsListForHeader(int HeaderID);
        int SaveProjectDataHeader(pdc_data_Elements_request model);
        void SaveProjectData(int headerId, List<pdc_gm_projectData_Request> elements);
    }
    public class PDCService : BaseService<pdc_element_master>, IPDCService
    {
        public PDCService(IUnitOfWork uow) : base(uow)
        {

        }

        public List<pdc_element_master> GetPDCElementsList(int category)
        {
            return _UOW.GetRepository<pdc_element_master>().Get(x=>x.is_active == true).OrderBy(o => o.category_id).ToList();
            
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
        public pdc_dataElements_details_model GetPDCElementsListForHeader(int HeaderID)
        {
            pdc_dataElements_details_model pdcModelList = new pdc_dataElements_details_model();
            pdc_header_data model = _UOW.GetRepository<pdc_header_data>().Get(h => h.header_Id == HeaderID).FirstOrDefault();

            pdcModelList.HeaderId = model.header_Id;
            pdcModelList.Currency = model.currency;
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
            var elementsDataList = _UOW.GetRepository <pdc_project_element_data>().Get(h => h.header_id == HeaderID).ToList();
            var categoryList = _UOW.GetRepository <pdc_category_master>().Get().ToList();

            List<pdc_elements_details_model> eleList = new List<pdc_elements_details_model>();
            foreach (pdc_element_master p in elementslist.OrderBy(o => o.category_id))
            {
                pdc_elements_details_model Elemodel = new pdc_elements_details_model();
              //Check here
                var ElemenDetails = elementsDataList.Where(o => o.header_id == p.element_id).FirstOrDefault();
                var category = categoryList.Where(c => c.category_id == p.category_id).FirstOrDefault();

               // Elemodel.MasterId = p.master;
                Elemodel.HeaderId = HeaderID;
                if (ElemenDetails != null)
                {

                    Elemodel.Price = ElemenDetails.unit_cost;
                    Elemodel.Commentary = ElemenDetails.scope_commmentary;
                    Elemodel.ShareInTotal = ElemenDetails.share_in_total;
                    Elemodel.ModelOrType = ElemenDetails.modeltype;
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
            var entity = _UOW.GetRepository<pdc_header_data>().Get(o => o.header_Id == model.headerId).FirstOrDefault(); ;
            if (entity == null)
            {
                entity = new pdc_header_data
                {
                    currency = model.currency,
                    cod = model.cod,
                    guaranteed_availability = model.guranteedAvailability,
                    guaranteed_perf_ratio = model.guranteedPerformance,
                    installed_capacity_ac = model.installedCapicityAC,
                    minimum_perf_ratio = model.minimumPerformance,
                    installed_capacity_dc = model.installedCapicityDC,
                    project_name = model.projectName,
                    project_year = model.projectYear,
                    supplier_group = model.supplierGroup,
                    total_project_cost = model.totalProjectCost,
                    year_1_onm_price = model.year1OnMPrice,
                    year_1_yield = model.year1Yield,
                    year_2_onm_price = model.year2OnMPrice
                };
                _UOW.GetRepository<pdc_header_data>().Add(entity);
               
            }
            else
            {
                // Update header
            }

            return entity.header_Id;
        }

        public void SaveProjectData(int headerId, List<pdc_gm_projectData_Request> elements)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var element in elements.Where(e => e.price != null))
                {
                    var entity = _UOW.GetRepository<pdc_project_element_data>().Get(o => o.header_id == headerId && o.matrix_id == element.masterId).FirstOrDefault();
                    if (entity == null)
                    {
                        entity = new pdc_project_element_data
                        {
                            header_id = headerId,
                            matrix_id = element.masterId,
                            unit_cost = element.price,
                            scope_commmentary = element.commentary,
                            share_in_total = element.shareInTotal,
                            modeltype = element.modelOrType,
                            quantity = element.qty,
                            total_service_hours = element.totalServiceHours
                        };
                        _UOW.GetRepository<pdc_project_element_data>().Add(entity);
                    }
                }
                _UOW.SaveChanges();
                scope.Complete();
            }
        }

    }
}
