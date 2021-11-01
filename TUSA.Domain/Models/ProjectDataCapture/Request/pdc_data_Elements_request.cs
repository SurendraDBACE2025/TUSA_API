using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class pdc_data_Elements_request
    {
        public int headerId { get; set; }
        public int form_id { get; set; }
        public string? currency { get; set; }
        public string? country { get; set; }
        public string? supplier_group { get; set; }
        public int? project_year { get; set; }
        public string? project_name { get; set; }
        public decimal? total_project_cost { get; set; }
        public decimal? year1OnmPrice { get; set; }
        public decimal? year2OnmPrice { get; set; }
        public decimal? installedCapicityAC { get; set; }
        public decimal? installedCapicityDC { get; set; }
        public decimal? year1Yield { get; set; }
        public decimal? guranteedPerfRation { get; set; }
        public decimal? minimumPerfRation { get; set; }
        public decimal? guranteedAvailability { get; set; }
        public decimal? cod { get; set; }
        public List<pdc_projectData_request> Elements { get; set; }
    }
}
