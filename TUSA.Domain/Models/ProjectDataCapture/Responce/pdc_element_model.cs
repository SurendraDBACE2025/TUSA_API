using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class pdc_element_model
    {
        public int element_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public string Category_name { get; set; }
        public string element_name { get; set; }
        public int element_order_no { get; set; }
        public string phase { get; set; }
        public string units { get; set; }
        public string service_or_equipment { get; set; }
        public bool is_active { get; set; }
    }
}
