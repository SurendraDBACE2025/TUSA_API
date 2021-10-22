using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Models
{
   public class pdc_gm_scopecategry_model
    {
        public int categoryId { get; set; }
        public string categoryText { get; set; }
        public Nullable<int> categoryOrder { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}
