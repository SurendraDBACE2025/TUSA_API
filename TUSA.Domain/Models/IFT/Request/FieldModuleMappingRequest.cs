using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.IFT.Request
{
    public class FieldFormModuleMappingRequest
    {
        public List<field_details> field_details { get; set; }
        public int module_id { get; set; }
        public int form_id { get; set; }
        public string form_name { get; set; }
        public string form_desc { get; set; }
    }
    public class field_details
    {
        public string field_id { get; set; }
        public int field_order { get; set; }
    }
}
