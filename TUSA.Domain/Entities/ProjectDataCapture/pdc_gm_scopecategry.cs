using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class pdc_gm_scopecategry:BaseEntity
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryText { get; set; }
        public Nullable<int> categoryOrder { get; set; }
        public Nullable<bool> isActive { get; set; }
    }
}
