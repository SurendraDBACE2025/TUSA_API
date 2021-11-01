using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class pdc_dataElements_details_model
    {
        public int HeaderId { get; set; }
        public string SupplierGroup { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public int? ProjectYear { get; set; }
        public string ProjectName { get; set; }
        public decimal? TotalProjectCost { get; set; }
        public decimal? Year1OnMPrice { get; set; }
        public decimal? Year2OnMPrice { get; set; }
        public decimal? InstalledCapicityAC { get; set; }
        public decimal? InstalledCapicityDC { get; set; }
        public decimal? Year1Yield { get; set; }
        public decimal? GuranteedPerformance { get; set; }
        public decimal? MinimumPerformance { get; set; }
        public decimal? GuranteedAvailability { get; set; }
        public decimal? COD { get; set; }
        public List<pdc_elements_details_model> Elements { get; set; }
    }
}
