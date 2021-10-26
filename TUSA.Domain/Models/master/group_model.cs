using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class group_model:BaseModel
    {

        public int group_id { get; set; }
        
        public string group_name { get; set; }
        public string display_name { get; set; }
        public string group_desc { get; set; }
        public string organization_name { get; set; }
    }
}
