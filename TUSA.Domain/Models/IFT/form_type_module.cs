using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models.IFT
{
    public class form_type_module
    {   
        public int form_type_id { get; set; }
        public string form_type_name { get; set; }
        public string form_type_desc { get; set; }
        public string is_active { get; set; }
    }
}
