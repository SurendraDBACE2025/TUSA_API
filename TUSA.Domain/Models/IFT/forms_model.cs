using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class forms_model:BaseModel
    {
        public int form_id { get; set; }
        
        public int module_id { get; set; }
        
        public string form_name { get; set; }
        
        public string form_desc { get; set; }
        
        public string is_active { get; set; }
    }
}
