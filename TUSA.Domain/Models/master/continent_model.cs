using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class continent_model:BaseModel
    {
        public string continent_code { get; set; }
        
        public string continent_name { get; set; }
     
        public string? continent_desc { get; set; }
    }
}
