using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSA.Domain.Entities
{
   public class pdc_category_master:BaseEntity
    {
        [Key]
        public int category_id { get; set; }
        [MaxLength(50)]
        public string category_name { get; set; }
        public Nullable<bool> is_active{ get; set; }
    }
}
