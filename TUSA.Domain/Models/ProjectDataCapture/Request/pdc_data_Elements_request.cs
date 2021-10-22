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
        public string currency { get; set; }
        public string supplierGroup { get; set; }
        public int? projectYear { get; set; }
        public string projectName { get; set; }
        public string category { get; set; }
        public decimal? totalProjectCost { get; set; }
        public decimal? year1OnMPrice { get; set; }
        public decimal? year2OnMPrice { get; set; }
        public decimal? installedCapicityAC { get; set; }
        public decimal? installedCapicityDC { get; set; }
        public decimal? year1Yield { get; set; }
        public decimal? guranteedPerformance { get; set; }
        public decimal? minimumPerformance { get; set; }
        public decimal? guranteedAvailability { get; set; }
        public decimal? cod { get; set; }
        public List<pdc_gm_projectData_Request> Elements { get; set; }
    }
}
