using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
   public class pdc_category_model
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public Nullable<bool> is_active { get; set; }
    }
}
