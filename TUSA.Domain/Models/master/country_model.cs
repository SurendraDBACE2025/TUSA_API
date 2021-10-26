using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
    public class country_model:BaseModel
    {
        public string country_code { get; set; }
        
        public string country_name { get; set; }
        public string content_code { get; set; }

        public continent_model content { get; set; }
    }
}
