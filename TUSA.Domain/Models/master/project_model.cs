using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
   public class project_model
    {
        public int project_id { get; set; }
        public string project_name { get; set; }
        public string? project_desc { get; set; }
        public string? project_size { get; set; }
        public string? project_year { get; set; }
        public DateTime project_start_date { get; set; }
        public DateTime project_end_date { get; set; }
        public country_model country { get; set; }
        public currency_model currency { get; set; }
    }
}
