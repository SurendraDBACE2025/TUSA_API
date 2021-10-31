using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class module_model:BaseModel
    {
        public int module_id { get; set; }
        public string module_name { get; set; }
        public string module_desc { get; set; }
    }
}
