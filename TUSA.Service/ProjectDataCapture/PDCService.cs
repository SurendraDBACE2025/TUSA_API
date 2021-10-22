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
    public interface IPDCService : IBaseService<pdc_gm_elements_master>
    {
        List<pdc_gm_elements_master> GetPDCElementsList(int category);
        List<pdc_gm_scopecategry> GetPDScopeCategoryList();
        List<pdc_gm_header> GetPDCHeaderList();
        pdc_dataElements_details_model GetPDCElementsListForHeader(int HeaderID);
        int SaveProjectDataHeader(pdc_data_Elements_request model);
        void SaveProjectData(int headerId, List<pdc_gm_projectData_Request> elements);
    }
    public class PDCService : BaseService<pdc_gm_elements_master>, IPDCService
    {
        public PDCService(IUnitOfWork uow) : base(uow)
        {

        }

        public List<pdc_gm_elements_master> GetPDCElementsList(int category)
        {
            return _UOW.GetRepository<pdc_gm_elements_master>().Get(x=>x.isActive == true).OrderBy(o => o.category).ThenBy(m => m.masterId).ToList();
            
        }
        public List<pdc_gm_scopecategry> GetPDScopeCategoryList()
        {
            return _UOW.GetRepository<pdc_gm_scopecategry>().Get(x => x.isActive == true).OrderBy(o => o.categoryId).ToList();
         
        }
        public List<pdc_gm_header> GetPDCHeaderList()
        {
            var spList = _UOW.GetRepository<pdc_gm_header>().Get().ToList();
          
            return spList;
        }
        public pdc_dataElements_details_model GetPDCElementsListForHeader(int HeaderID)
        {
            pdc_dataElements_details_model pdcModelList = new pdc_dataElements_details_model();
            pdc_gm_header model = _UOW.GetRepository<pdc_gm_header>().Get(h => h.headerId == HeaderID).FirstOrDefault();

            pdcModelList.HeaderId = model.headerId;
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
            pdcModelList.Year1OnMPrice = model.year_1_OnM_price;
            pdcModelList.Year1Yield = model.year_1_yield;
            pdcModelList.Year2OnMPrice = model.year_2_OnM_price;

            var elementslist = _UOW.GetRepository <pdc_gm_elements_master>().Get().ToList();
            var elementsDataList = _UOW.GetRepository <pdc_gm_project_data>().Get(h => h.headerId == HeaderID).ToList();
            var categoryList = _UOW.GetRepository <pdc_gm_scopecategry>().Get().ToList();

            List<pdc_elements_details_model> eleList = new List<pdc_elements_details_model>();
            foreach (pdc_gm_elements_master p in elementslist.OrderBy(o => o.category).ThenBy(m => m.masterId))
            {
                pdc_elements_details_model Elemodel = new pdc_elements_details_model();
                var ElemenDetails = elementsDataList.Where(o => o.masterId == p.masterId).FirstOrDefault();
                var category = categoryList.Where(c => c.categoryId == p.category).FirstOrDefault();

                Elemodel.MasterId = p.masterId;
                Elemodel.HeaderId = HeaderID;
                if (ElemenDetails != null)
                {

                    Elemodel.Price = ElemenDetails.price;
                    Elemodel.Commentary = ElemenDetails.scope_commmentary;
                    Elemodel.ShareInTotal = ElemenDetails.share_in_Total;
                    Elemodel.ModelOrType = ElemenDetails.modeltype;
                    Elemodel.TotalServiceHours = ElemenDetails.totalServiceHours;
                    Elemodel.Qty = ElemenDetails.quantity;
                }
                else { }

                Elemodel.Category = category.categoryId;
                Elemodel.CategoryName = category.categoryText;
                Elemodel.Phase = p.phase;
                Elemodel.Scope = p.scope;
                Elemodel.IsActive = p.isActive;
                Elemodel.Units = p.units;
                Elemodel.ServiceOrEquipment = p.serviceOrEquipment;


                eleList.Add(Elemodel);
            }
            pdcModelList.Elements = eleList;
            return pdcModelList;
        }

        public int SaveProjectDataHeader(pdc_data_Elements_request model)
        {
            var entity = _UOW.GetRepository<pdc_gm_header>().Get(o => o.headerId == model.headerId).FirstOrDefault(); ;
            if (entity == null)
            {
                entity = new pdc_gm_header
                {

                    category = model.category,
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
                    year_1_OnM_price = model.year1OnMPrice,
                    year_1_yield = model.year1Yield,
                    year_2_OnM_price = model.year2OnMPrice
                };
                _UOW.GetRepository<pdc_gm_header>().Add(entity);
               
            }
            else
            {
                // Update header
            }

            return entity.headerId;
        }

        public void SaveProjectData(int headerId, List<pdc_gm_projectData_Request> elements)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var element in elements.Where(e => e.price != null))
                {
                    var entity = _UOW.GetRepository<pdc_gm_project_data>().Get(o => o.headerId == headerId && o.masterId == element.masterId).FirstOrDefault();
                    if (entity == null)
                    {
                        entity = new pdc_gm_project_data
                        {
                            headerId = headerId,
                            masterId = element.masterId,
                            price = element.price,
                            scope_commmentary = element.commentary,
                            share_in_Total = element.shareInTotal,
                            modeltype = element.modelOrType,
                            quantity = element.qty,
                            totalServiceHours = element.totalServiceHours
                        };
                        _UOW.GetRepository<pdc_gm_project_data>().Add(entity);
                    }
                }
                _UOW.SaveChanges();
                scope.Complete();
            }
        }

    }
}
