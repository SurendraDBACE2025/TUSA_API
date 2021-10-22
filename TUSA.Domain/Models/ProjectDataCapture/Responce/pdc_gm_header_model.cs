using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class pdc_gm_header_model
    {
        public int headerId { get; set; }
        public string supplier_group { get; set; }
        public string project_name { get; set; }
        public Nullable<int> project_year { get; set; }
        public string category { get; set; }
        public Nullable<decimal> total_project_cost { get; set; }
        public Nullable<decimal> year_1_OnM_price { get; set; }
        public Nullable<decimal> year_2_OnM_price { get; set; }
        public Nullable<decimal> installed_capacity_dc { get; set; }
        public Nullable<decimal> installed_capacity_ac { get; set; }
        public Nullable<decimal> year_1_yield { get; set; }
        public Nullable<decimal> guaranteed_perf_ratio { get; set; }
        public Nullable<decimal> minimum_perf_ratio { get; set; }
        public Nullable<decimal> guaranteed_availability { get; set; }
        public Nullable<decimal> cod { get; set; }
        public string currency { get; set; }
        public string country { get; set; }
    }
}
