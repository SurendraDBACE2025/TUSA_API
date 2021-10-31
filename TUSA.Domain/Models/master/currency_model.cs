using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
   public class currency_model
    {
        public string currency_code { get; set; }
    
        public string? currency_symbol { get; set; }
     
        public string? currency_desc { get; set; }
        public string country_code { get; set; }
    }
}
